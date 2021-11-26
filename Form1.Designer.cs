
namespace DetalhePcGrafico
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNome = new System.Windows.Forms.Label();
            this.labelSetor = new System.Windows.Forms.Label();
            this.labelFuncao = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxSetor = new System.Windows.Forms.TextBox();
            this.textBoxFuncao = new System.Windows.Forms.TextBox();
            this.ButtonEnviarDados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(29, 29);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(41, 13);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome: ";
            // 
            // labelSetor
            // 
            this.labelSetor.AutoSize = true;
            this.labelSetor.Location = new System.Drawing.Point(29, 63);
            this.labelSetor.Name = "labelSetor";
            this.labelSetor.Size = new System.Drawing.Size(38, 13);
            this.labelSetor.TabIndex = 1;
            this.labelSetor.Text = "Setor: ";
            // 
            // labelFuncao
            // 
            this.labelFuncao.AutoSize = true;
            this.labelFuncao.Location = new System.Drawing.Point(29, 99);
            this.labelFuncao.Name = "labelFuncao";
            this.labelFuncao.Size = new System.Drawing.Size(49, 13);
            this.labelFuncao.TabIndex = 2;
            this.labelFuncao.Text = "Função: ";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(85, 26);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(210, 20);
            this.textBoxNome.TabIndex = 3;
            // 
            // textBoxSetor
            // 
            this.textBoxSetor.Location = new System.Drawing.Point(85, 60);
            this.textBoxSetor.Name = "textBoxSetor";
            this.textBoxSetor.Size = new System.Drawing.Size(210, 20);
            this.textBoxSetor.TabIndex = 4;
            // 
            // textBoxFuncao
            // 
            this.textBoxFuncao.Location = new System.Drawing.Point(85, 96);
            this.textBoxFuncao.Name = "textBoxFuncao";
            this.textBoxFuncao.Size = new System.Drawing.Size(210, 20);
            this.textBoxFuncao.TabIndex = 5;
            // 
            // ButtonEnviarDados
            // 
            this.ButtonEnviarDados.Location = new System.Drawing.Point(113, 139);
            this.ButtonEnviarDados.Name = "ButtonEnviarDados";
            this.ButtonEnviarDados.Size = new System.Drawing.Size(119, 23);
            this.ButtonEnviarDados.TabIndex = 6;
            this.ButtonEnviarDados.Text = "Enviar Dados";
            this.ButtonEnviarDados.UseVisualStyleBackColor = true;
            this.ButtonEnviarDados.Click += new System.EventHandler(this.ButtonEnviarDados_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 174);
            this.Controls.Add(this.ButtonEnviarDados);
            this.Controls.Add(this.textBoxFuncao);
            this.Controls.Add(this.textBoxSetor);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelFuncao);
            this.Controls.Add(this.labelSetor);
            this.Controls.Add(this.labelNome);
            this.Name = "Form1";
            this.Text = "Detalhe PC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelSetor;
        private System.Windows.Forms.Label labelFuncao;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxSetor;
        private System.Windows.Forms.TextBox textBoxFuncao;
        private System.Windows.Forms.Button ButtonEnviarDados;
    }
}

