using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Net.Mail;

namespace DetalhePcGrafico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonEnviarDados_Click(object sender, EventArgs e)
        {
            string Nome, Setor, Funcao;
            Nome = textBoxNome.Text;
            Setor = textBoxSetor.Text;
            Funcao = textBoxFuncao.Text;

            if(Nome == "" || Setor == "" || Funcao == "") // verifica se esqueceram de preencher algum campo
            {
                MessageBox.Show("Erro! Algum campo está fazio.\nAperte ENTER para fechar essa janela.");
                Application.Exit();
            }

            InformacoesDoSistema Sistema = new InformacoesDoSistema();

            //variaveis do sistema
            var ram = Sistema.MemoriaRam;
            var os = Sistema.OS;
            var cpu = Sistema.CPU;
            var gpu = Sistema.GPU;
            var hdd = Sistema.HDD;
            var tipo2 = Sistema.TIPO2;
            string tipoArmazenamento = "";

            if (tipo2 == true)
            {
                tipoArmazenamento = "SSD";
            }
            else
            {
                tipoArmazenamento = "HDD";
            }

            //enviar e-mail com as configuracoes
            try
            {
                string emailDestinatario = "seuEmail@email.com"; // email destinatario
                string titulo = "DetalhePC - " + Nome; // titulo do e-mail
                string mensagem = $"Nome: {Nome} <br>Setor: {Setor}<br>Função: {Funcao}<br><br>Memoria RAM: {ram}Gb<br>Tipo de Armazenamento: {tipoArmazenamento}<br>Armazenamento Total: {hdd}Gb<br>Sistema Operacional: {os}<br>Modelo CPU: {cpu}<br>Modelo GPU: {gpu}"; // corpo da mensagem
                string senha = "senhaDoEmail"; // senha do e-mail

                MailMessage mailMessage = new MailMessage(emailDestinatario, emailDestinatario);

                mailMessage.Subject = $"{titulo}";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = mensagem;
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailDestinatario, senha);

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                MessageBox.Show("Procedimento realizado com sucesso!\nAperte ENTER para fechar essa janela.");
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro! O procedimento não foi executado como deveria.\nAperte ENTER para fechar essa janela.");
                Application.Exit();
            }
        }
    }
}
