using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kursovaia_Gubaidullin
{

    public partial class Creator : Form
    {
         bool NEW = true;
         bool CanSimpleViewed = true;
        

        public Creator()
        {
            InitializeComponent();
            SourceBox.Text += '\n' + '\n';

        }

        private void SimpleView_Click(object sender, EventArgs e)//сделано
        {
            if (NEW)
            {
                SourceBox.Visible = false;
            }
            else
            {
                if (CanSimpleViewed)
                {
                    SourceBox.Visible = false;
                }
                else
                    MessageBox.Show("Данный сценарий не может быть представлен в простом виде");
            }
        }

        private void SourceView_Click(object sender, EventArgs e)//сделано
        {
            SourceBox.Visible = true;
        }

        private void NextQuestion_Click(object sender, EventArgs e)//сделано
        {
            SourceBox.Text += QuestionBox.Text + ';';      // Вопрос
            for (int z = 0; z < SourceGrid.RowCount; z++)
            {
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[0].Value) + '#'; //Ответ
                SourceBox.Text += Convert.ToString(SourceGrid.Rows[z].Cells[1].Value) + ';'; //Переход
            }
            QuestionBox.Clear();
            SourceGrid.Rows.Clear();
        }

        private void NewDialog_Click(object sender, EventArgs e)//сделано
        {
            SourceBox.Clear();
            QuestionBox.Clear();
            SourceGrid.Rows.Clear();
            NEW = true;
        }

        private void EditDialog_Click(object sender, EventArgs e)//сделано
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "KUR|*.kur";
                openFileDialog1.Title = "Select a kur File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;
                    System.IO.StreamReader file = new System.IO.StreamReader(path, Encoding.Default);
                    SourceBox.Text = file.ReadToEnd();
                    file.Close();
                    file.Close();
                    NEW = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила заполнения см. в Документации к проекту");
        }

        private void OK_Click(object sender, EventArgs e)//сделано
        {
            
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "KUR|*.kur";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        StreamWriter w = new StreamWriter(myStream);
                        w.Write(SourceBox.Text);
                        myStream.Close();
                    }
                }
                this.Close();
            }
        }

    }

}