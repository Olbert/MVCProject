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

    // А МОЖЕТ ОТДЕЛЬНЫМ ПРОЕКТОМ? но что с event-ами


    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        public static EventWaitHandle END = new AutoResetEvent(false);

        public void Prepare(EventHandler CreateDialog_Click, EventHandler OpenDialog_Click, EventHandler Settings_Click, EventHandler About_Click)
        {
            this.CreateDialog.Click += CreateDialog_Click;
            this.OpenDialog.Click += OpenDialog_Click;
            this.Settings.Click += Settings_Click;
            this.About.Click += About_Click;
        }

        public int SetQuestion(string CurQuestion, string[] Answers) //стартовать асинхронно, чтобы возвращать ответ?
        {
            int n = Convert.ToInt32(QuestionNum.Text);
            n++;
            QuestionNum.Text = Convert.ToString(n);
            Question.Text = CurQuestion;

            END.WaitOne();

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
            END.Set();
        }
        
    }

}
