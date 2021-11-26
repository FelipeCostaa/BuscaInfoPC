using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Win32;
using System.Management;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace DetalhePcGrafico
{
    class InformacoesDoSistema
    {
        public string MemoriaRam { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public decimal HDD { get; set; }
        public string TIPO { get; set; }
        public bool TIPO2 { get; set; }

        public InformacoesDoSistema()
        {
            MemoriaRam = GetMem();
            OS = GetOS();
            CPU = GetCPU();
            GPU = GetGPU();
            HDD = GetHardDiskMem();
            TIPO2 = DriveIsSSD("C");
        }

        private string GetMem()
        {
            decimal memTemp = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            memTemp /= 1024 * 1024 * 1024;
            memTemp = decimal.Round(memTemp, 3);
            return memTemp.ToString();
        }
        private string GetOS()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }
        public string GetCPU()
        {
            ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            string Procname = null;

            foreach (ManagementObject moProcessor in mosProcessor.Get())
            {
                if (moProcessor["name"] != null)
                {
                    Procname = moProcessor["name"].ToString();
                }
            }
            return Procname;
        }
        public string GetGPU()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = "";
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        return graphicsCard += property.Value.ToString();
                    }
                }
            }
            return "error";
        }
        public decimal GetHardDiskMem()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                decimal totalMem = d.TotalSize;
                totalMem /= 1024 * 1024 * 1024;
                totalMem = decimal.Round(totalMem, 3);
                return totalMem;
            }
            return 0;
        }
        public bool DriveIsSSD(string drive_letter)
        {
            foreach (ManagementObject obj in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
            {
                if (obj["PNPDeviceID"].ToString().Contains("SSD"))
                {
                    foreach (ManagementObject partition in obj.GetRelated("Win32_DiskPartition"))
                        foreach (ManagementObject drive in partition.GetRelated("Win32_LogicalDisk"))
                            if (drive["Name"].ToString().StartsWith(drive_letter))
                                return true;
                }
            }
            return false;
        }
    }
}
