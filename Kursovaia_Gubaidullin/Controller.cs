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
        [STAThread]
        void Main()
        {
            Model m = new Model();
            m = Memory.Load();
            ConectToView(m);
        }
        
        void ConectToView(Model m)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            View = new Questions();
            Application.Run(View);   
        }

        static Questions View;
        Model Model;
        string path = Directory.GetCurrentDirectory();
        string Dirpath = Directory.GetCurrentDirectory();
        string DialogPath;
        public string CCompilerPath = null, SCompilerPath = null, PCompilerPath = null;
        public bool GameTheory;
        int CurQuestion = 0, CurPart = 0, CurAnswer = 0;
        int[][] History;
       
        private void OK_Click(object sender, EventArgs e)
        {

            bool b = false;
            if (CurPart < Model.PartsNUM)
            {
                if (CurQuestion < Model.S[CurPart].QuestionsNUM)
                {
                    if (CurQuestion != Model.S[CurPart].Prog.Dir)
                    {
                        int k = 0;
                        while (k < Model.S[CurPart].M[CurQuestion].AnswersNUM && !b)
                        {
                            if (View.Answer.Text.Contains(Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer))
                            {
                                b = true;
                                History[CurPart][CurQuestion] = k;
                            }
                            k++;
                        }
                        if (GameTheory)
                        {
                            Random rnd = new Random(DateTime.Now.Millisecond);
                            int a = rnd.Next(0, 8);
                            if (a == 2)
                                RandomSelected(k - 1);
                        }
                        if (b == false)
                            MessageBox.Show("Такой ответ не поддерживается, загляните в справку");
                        else
                        {
                            ShowNextQuestion();
                        }
                    }
                    else
                    {
                        Model.S[CurPart].M[CurQuestion].R = new Model.Element.Message.Answers[1];
                        Model.S[CurPart].M[CurQuestion].R[0] = new Model.Element.Message.Answers();
                        Model.S[CurPart].M[CurQuestion].R[0].Answer = Answer.Text;
                        CurQuestion++;
                        MessageBox.Show("Диалог окончен, идет построение системы...");
                        Program Prog = new Program(Model, CurPart);
                        Prog.MakeProgram(Dirpath);
                        MessageBox.Show("Система построена");
                        CurPart++;
                    }
                }
            }
        }

        void RandomSelected(int k)
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            int a = rnd.Next(0, 2);
            switch (a)
            {
                case 0:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Быть может лучше выбрать " + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer + "?";
                        else
                            Question.Text = "Быть может лучше выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer + "?";
                    }
                    break;
                case 1:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Лучше выбрать вариант: " + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer;
                        else
                            Question.Text = "Лучше выбрать вариант: " + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer;
                    }
                    break;
                case 2:
                    {
                        if (k < Model.S[CurPart].M[CurQuestion].R[CurAnswer].Answer.Length - 1)
                            Question.Text = "Система советует выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer + 1].Answer;
                        else
                            Question.Text = "Система советует выбрать" + Model.S[CurPart].M[CurQuestion].R[CurAnswer - 1].Answer;
                    }
                    break;
            }
            Answer.Text = "Введите ответ еще раз";

        }//А надо?
        
        private void CreateDialog_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Creator(this);
            f.Show();
        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "KUR|*.kur";
                openFileDialog1.Title = "Select a kur File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DialogPath = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            Model = new Model();
            Model = Memory.Load(DialogPath);

            Answer.Clear();
            Question.Text = Model.S[CurPart].M[CurQuestion].V;
            string[] str = new string[Model.S[CurPart].M[CurQuestion].R.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Model.S[CurPart].M[CurQuestion].R[i].Answer;
            }
            AvaliableAnswers.Items.AddRange(str);
            History = new int[Model.PartsNUM][];
            for (int i = 0; i < Model.PartsNUM; i++)
                History[i] = new int[Model.S[i].QuestionsNUM];


        }



        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Курсовая работа \n ст. 09 - 411 \n Губайдуллина Альберта\n Модель: Теория игр ", "О программе");
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Settings(this);
            f.Show();
        }

ShowNextQuestion()
        {
            CurQuestion = Model.S[CurPart].M[CurQuestion].R[CurAnswer].Next;
            Question.Text = Model.S[CurPart].M[CurQuestion].V;
            string[] str = new string[Model.S[CurPart].M[CurQuestion].R.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Model.S[CurPart].M[CurQuestion].R[i].Answer;
            }
            AvaliableAnswers.Items.AddRange(str);

        }

    }
}
