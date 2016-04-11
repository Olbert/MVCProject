using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaia_Gubaidullin
{
    public partial class Settings : Form
    {
        public string CompilerPath = null;
        public Settings()
        {
            // весь код (как и в Settings.Designer) был использован в куссовой
            // сохранен на случай требования внятного диалога с действиями
            InitializeComponent();
        }
        /*
        private void BrowseSharp_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "EXE|*.exe";
                openFileDialog1.Title = "Select a exe File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   ParentForm.SCompilerPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        private void BrowseCpp_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "EXE|*.exe";
                openFileDialog1.Title = "Select a exe File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ParentForm.CCompilerPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        */

    }
}
