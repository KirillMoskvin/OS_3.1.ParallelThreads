using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OS_3._1.ParallelThreads
{
    class Reader
    {
        /// <summary>
        /// Текстбокс для вывода сообщений
        /// </summary>
        TextBox output;
        /// <summary>
        /// Количество сообщений, которые читает читатель
        /// </summary>
        const int messageCount= 5;
        /// <summary>
        /// Буфер, из которого считываем
        /// </summary>
        MyBuffer buff;
        int num;

        public Reader(TextBox Output,  MyBuffer buff, int num)
        {
            output = Output;
            this.buff = buff;
            this.num = num;
        }
        /// <summary>
        /// Жизненный цикл читателя
        /// </summary>
        public void Read()
        {
            int messagesRead = 0;
            output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " начал работу"  + Environment.NewLine));
            while (messagesRead < messageCount)
            {
                messagesRead++;
                string message = "";
                if (buff.Read(out message))
                    output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " забрал сообщение" + message + Environment.NewLine));
                else
                    output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " попытался забрать сообщение, буфер был пуст" + Environment.NewLine));
                Thread.Sleep(new Random().Next(500, 1500));
            }
            output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " завершил работу"  + Environment.NewLine));
        }
    }
}
