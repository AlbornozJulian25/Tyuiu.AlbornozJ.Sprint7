using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            labelAbout.Text = @"Программа: Управление договорной деятельностью организации
Разработчик: Albornoz Julián.
Группа: ИИПб 25-1
Дата: 2025";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}