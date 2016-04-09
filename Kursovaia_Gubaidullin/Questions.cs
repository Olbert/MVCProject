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
using System.Threading;
namespace Kursovaia_Gubaidullin
{

    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("Kursovaia.Info");
                CCompilerPath = file.ReadLine();
                SCompilerPath = file.ReadLine();
                //PCompilerPath = file.ReadLine();
                GameTheory = Convert.ToBoolean(file.ReadLine());
                file.Close();
            }
            catch (Exception ex) { }
        }

        public void Prepare()
        {

        }
        public int SetQuestion(Question CurQuestion) //стартовать асинхронно, чтобы возвращать ответ?
        {
            int n = Convert.ToInt32(QuestionNum.Text);
            n++;
            QuestionNum.Text = Convert.ToString(n);
            Question.Text = CurQuestion.Text;
            Protokol.Text += "ДС: " + Question.Text + '\n' + "Пользователь: " + Answer.Text + '\n';
            while (!OK_Click)
            {

            }
            Protokol.Text += "ДС: " + Question.Text + '\n' + "Пользователь: " + Answer.Text + '\n';
            Answer.Clear();
            AvaliableAnswers.Items.Clear();
            return AvaliableAnswers.SelectedIndex;

        }
        private void AvaliableAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Answer.Text = AvaliableAnswers.SelectedItem.ToString();

        }
       
        private void OK_Click(object sender, EventArgs e)
        {


        }
    }

}
