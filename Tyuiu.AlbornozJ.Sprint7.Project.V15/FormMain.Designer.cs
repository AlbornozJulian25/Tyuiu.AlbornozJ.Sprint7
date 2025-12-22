namespace Tyuiu.AlbornozJ.Sprint7.Project.V15
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuStripMain_AJ = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            загрузитьДоговорыToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            руководствоToolStripMenuItem = new ToolStripMenuItem();
            toolStripMain_AJ = new ToolStrip();
            toolStripButtonLoad_AJ = new ToolStripButton();
            toolStripButtonStats_AJ = new ToolStripButton();
            toolStripButtonSearch_AJ = new ToolStripButton();
            toolStripButtonChart_AJ = new ToolStripButton();
            dataGridViewContracts_AJ = new DataGridView();
            panelStatistics_AJ = new Panel();
            labelTotal_AJ = new Label();
            labelAverage_AJ = new Label();
            menuStripMain_AJ.SuspendLayout();
            toolStripMain_AJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContracts_AJ).BeginInit();
            panelStatistics_AJ.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain_AJ
            // 
            menuStripMain_AJ.ImageScalingSize = new Size(20, 20);
            menuStripMain_AJ.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, справкаToolStripMenuItem });
            menuStripMain_AJ.Location = new Point(0, 0);
            menuStripMain_AJ.Name = "menuStripMain_AJ";
            menuStripMain_AJ.Size = new Size(800, 28);
            menuStripMain_AJ.TabIndex = 0;
            menuStripMain_AJ.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { загрузитьДоговорыToolStripMenuItem, сохранитьToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem, руководствоToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // загрузитьДоговорыToolStripMenuItem
            // 
            загрузитьДоговорыToolStripMenuItem.Name = "загрузитьДоговорыToolStripMenuItem";
            загрузитьДоговорыToolStripMenuItem.Size = new Size(233, 26);
            загрузитьДоговорыToolStripMenuItem.Text = "Загрузить договоры";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(233, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(230, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(233, 26);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(224, 26);
            оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // руководствоToolStripMenuItem
            // 
            руководствоToolStripMenuItem.Name = "руководствоToolStripMenuItem";
            руководствоToolStripMenuItem.Size = new Size(224, 26);
            руководствоToolStripMenuItem.Text = "Руководство";
            // 
            // toolStripMain_AJ
            // 
            toolStripMain_AJ.ImageScalingSize = new Size(20, 20);
            toolStripMain_AJ.Items.AddRange(new ToolStripItem[] { toolStripButtonLoad_AJ, toolStripButtonStats_AJ, toolStripButtonSearch_AJ, toolStripButtonChart_AJ });
            toolStripMain_AJ.Location = new Point(0, 28);
            toolStripMain_AJ.Name = "toolStripMain_AJ";
            toolStripMain_AJ.Size = new Size(800, 27);
            toolStripMain_AJ.TabIndex = 1;
            toolStripMain_AJ.Text = "toolStrip1";
            // 
            // toolStripButtonLoad_AJ
            // 
            toolStripButtonLoad_AJ.Image = (Image)resources.GetObject("toolStripButtonLoad_AJ.Image");
            toolStripButtonLoad_AJ.ImageTransparentColor = Color.Magenta;
            toolStripButtonLoad_AJ.Name = "toolStripButtonLoad_AJ";
            toolStripButtonLoad_AJ.Size = new Size(101, 24);
            toolStripButtonLoad_AJ.Text = "Загрузить";
            // 
            // toolStripButtonStats_AJ
            // 
            toolStripButtonStats_AJ.Image = (Image)resources.GetObject("toolStripButtonStats_AJ.Image");
            toolStripButtonStats_AJ.ImageTransparentColor = Color.Magenta;
            toolStripButtonStats_AJ.Name = "toolStripButtonStats_AJ";
            toolStripButtonStats_AJ.Size = new Size(108, 24);
            toolStripButtonStats_AJ.Text = "Статистика";
            // 
            // toolStripButtonSearch_AJ
            // 
            toolStripButtonSearch_AJ.Image = (Image)resources.GetObject("toolStripButtonSearch_AJ.Image");
            toolStripButtonSearch_AJ.ImageTransparentColor = Color.Magenta;
            toolStripButtonSearch_AJ.Name = "toolStripButtonSearch_AJ";
            toolStripButtonSearch_AJ.Size = new Size(76, 24);
            toolStripButtonSearch_AJ.Text = "Поиск";
            // 
            // toolStripButtonChart_AJ
            // 
            toolStripButtonChart_AJ.Image = (Image)resources.GetObject("toolStripButtonChart_AJ.Image");
            toolStripButtonChart_AJ.ImageTransparentColor = Color.Magenta;
            toolStripButtonChart_AJ.Name = "toolStripButtonChart_AJ";
            toolStripButtonChart_AJ.Size = new Size(83, 24);
            toolStripButtonChart_AJ.Text = "График";
            // 
            // dataGridViewContracts_AJ
            // 
            dataGridViewContracts_AJ.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContracts_AJ.Dock = DockStyle.Fill;
            dataGridViewContracts_AJ.Location = new Point(0, 55);
            dataGridViewContracts_AJ.Name = "dataGridViewContracts_AJ";
            dataGridViewContracts_AJ.RowHeadersWidth = 51;
            dataGridViewContracts_AJ.Size = new Size(800, 395);
            dataGridViewContracts_AJ.TabIndex = 2;
            dataGridViewContracts_AJ.CellContentClick += dataGridViewContracts_AJ_CellContentClick;
            // 
            // panelStatistics_AJ
            // 
            panelStatistics_AJ.Controls.Add(labelAverage_AJ);
            panelStatistics_AJ.Controls.Add(labelTotal_AJ);
            panelStatistics_AJ.Dock = DockStyle.Bottom;
            panelStatistics_AJ.Location = new Point(0, 350);
            panelStatistics_AJ.Name = "panelStatistics_AJ";
            panelStatistics_AJ.Size = new Size(800, 100);
            panelStatistics_AJ.TabIndex = 3;
            panelStatistics_AJ.Paint += panelStatistics_AJ_Paint;
            // 
            // labelTotal_AJ
            // 
            labelTotal_AJ.AutoSize = true;
            labelTotal_AJ.Location = new Point(326, 50);
            labelTotal_AJ.Name = "labelTotal_AJ";
            labelTotal_AJ.Size = new Size(120, 20);
            labelTotal_AJ.TabIndex = 0;
            labelTotal_AJ.Text = "Общая сумма: 0\r\n";
            // 
            // labelAverage_AJ
            // 
            labelAverage_AJ.AutoSize = true;
            labelAverage_AJ.Location = new Point(573, 50);
            labelAverage_AJ.Name = "labelAverage_AJ";
            labelAverage_AJ.Size = new Size(131, 20);
            labelAverage_AJ.TabIndex = 1;
            labelAverage_AJ.Text = "Средняя сумма: 0\r\n";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelStatistics_AJ);
            Controls.Add(dataGridViewContracts_AJ);
            Controls.Add(toolStripMain_AJ);
            Controls.Add(menuStripMain_AJ);
            MainMenuStrip = menuStripMain_AJ;
            Name = "FormMain";
            Text = "Form1";
            Load += Form1_Load;
            menuStripMain_AJ.ResumeLayout(false);
            menuStripMain_AJ.PerformLayout();
            toolStripMain_AJ.ResumeLayout(false);
            toolStripMain_AJ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContracts_AJ).EndInit();
            panelStatistics_AJ.ResumeLayout(false);
            panelStatistics_AJ.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain_AJ;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem загрузитьДоговорыToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem руководствоToolStripMenuItem;
        private ToolStrip toolStripMain_AJ;
        private ToolStripButton toolStripButtonLoad_AJ;
        private ToolStripButton toolStripButtonStats_AJ;
        private ToolStripButton toolStripButtonSearch_AJ;
        private ToolStripButton toolStripButtonChart_AJ;
        private DataGridView dataGridViewContracts_AJ;
        private Panel panelStatistics_AJ;
        private Label labelTotal_AJ;
        private Label labelAverage_AJ;
    }
}
