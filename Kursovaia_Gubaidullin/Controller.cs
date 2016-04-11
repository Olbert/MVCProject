using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
namespace Kursovaia_Gubaidullin
{

    class Controller
    {


        static View view;
        Model model;
        //string path = Directory.GetCurrentDirectory();
        //string Dirpath = Directory.GetCurrentDirectory();
        //string DialogPath;
        // public string CCompilerPath = null, SCompilerPath = null, PCompilerPath = null;
        int[][] History; //возможно понадобится

        [STAThread]
        void Main()
        {
            model = new Model();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            view = new View();
            EventHandler CreateDialog = new System.EventHandler(CreateDialog_Click);
            EventHandler OpenDialog = new System.EventHandler(OpenDialog_Click);
            EventHandler Settings = new System.EventHandler(Settings_Click);
            EventHandler About = new System.EventHandler(About_Click);
            view.Prepare(CreateDialog, OpenDialog, Settings, About);
            Application.Run(view);
        }


        void Run(Model.Message m)
        {
            int num = view.SetQuestion(m.question, m.GetAllAnswers()); // получить номер ответа
            int skip = m.answers[num].next; // вычислить сколько нужно пропустить

            //действие

            while (!model.EOF()) // пока не конец диалога
            {
                m = model.GetNext(skip); // получить следующее сообщение (пропустить 'skip' сообщений)
                num = view.SetQuestion(m.question, m.GetAllAnswers());
                skip = m.answers[num].next;

                //действие

            }
        }

        internal void CreateDialog_Click(object sender, EventArgs e)
        {
            Creator f = new Creator();
            f.Show();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Курсовая работа \n ст. 09 - 411 \n Губайдуллина Альберта\n Модель: Теория игр ", "О программе");
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Form f = new Settings();
            f.Show();
        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            Model.Message m = model.GetFirst(); // получить первый вопрос
            Run(m);
        }
    }
}
