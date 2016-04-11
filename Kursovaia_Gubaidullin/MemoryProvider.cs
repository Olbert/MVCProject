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
    public class Memory
    {
        static StreamReader sr;
        public static void Save(Model m)
        {
            // файл должен выглядеть следующим образом (как CSV таблица)
            // Вопрос;Ответ1#переход1;Ответ2#переход2;Ответ3#переход3...
            // Вопрос;Ответ1#переход1;Ответ2#переход2;Ответ3#переход3...

            //Вообще структура имеет вид конечного детерменированного автомата без циклов
        }
        public static void LoadFile()
        {

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "KUR|*.kur";
                openFileDialog1.Title = "Select a kur File";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    sr = new StreamReader(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        public static Model.Message GetMessage(int skip)
        {
            string[] str = null;
            try
            {
                for (int i = 0; i < skip + 1; i++)
                {
                    str = sr.ReadLine().Split(';');//??
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return new Model.Message(str);
        }
        public static bool EOF()
        {
            return sr.EndOfStream;
        }
    }
}

