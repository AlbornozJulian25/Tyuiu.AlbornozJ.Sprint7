namespace Tyuiu.AlbornozJ.Sprint7.Project.V15
{
    partial class FormAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelAbout = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxLogo).BeginInit();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(140, 12);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(280, 117);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = resources.GetString("Программа \\\"Управление договорной деятельностью организации\\\"\\r\\n\" +\r\n                      \"Версия: 1.0\\r\\n\" +\r\n                      \"Разработчик: Albornoz J.\\r\\n\" +\r\n                      \"Группа: ИИПб 25-1\\r\\n\" +\r\n                      \"Дата: 2025\\r\\n\\r\\n\" +\r\n                      \"Функции программы:\\r\\n\" +\r\n                      \"• Загрузка данных из CSV файлов\\r\\n\" +\r\n                      \"• Управление договорами и сотрудниками\\r\\n\" +\r\n                      \"• Просмотр статистики и графиков\\r\\n\" +\r\n                      \"• Сохранение изменений в файлы\\r\\n\\r\\n\" +\r\n                      \"Все данные хранятся в формате CSV.\";");
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = null;
            this.pictureBoxLogo.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(345, 120);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 151);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxLogo).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonOk;
    }
}
