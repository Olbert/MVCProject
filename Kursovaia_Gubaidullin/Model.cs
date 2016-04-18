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
    public class Model
    {
        public class Message
        {

            public int AnswersNUM = 0;
            public string question;
            public Answers[] answers;

            public class Answers
            {
                public String text;
                public int next;
                public Answers(string[] str)
                {
                    this.text = str[0];
                    this.next = Convert.ToInt32(str[1]);
                }
            }

            public string[] GetAllAnswers()
            {
                string[] str = new string[answers.Length];
                for (int i = 0; i < answers.Length; i++)
                    str[i] = answers[i].text;

                return str;
            }
            public Message(string[] str)
            {
                this.question = str[0];
                this.answers = new Answers[str.Length - 1];
                for (int i = 0; i < str.Length-1; i++)
                {
                    this.answers[i] = new Answers(str[i + 1].Split('#'));
                }

            }

        }


        public Message GetFirst()
        {
            Memory.LoadFile();
            return GetNext(0);

        }

        public Message GetNext(int skip)
        {
            Message m = Memory.GetMessage(skip);
            if (m != null)
                return m;
            else return m;
                //а что если первого нет?
        }

        public bool EOF()
        {
            return Memory.EOF();
        }

    }
}
