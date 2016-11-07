using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace OS_3._1.ParallelThreads
{
    class Writer
    {
        /// <summary>
        /// Буфер
        /// </summary>
        MyBuffer buff;

        /// <summary>
        /// Куда выводим состояние потока
        /// </summary>
        TextBox output;

        /// <summary>
        /// Количество сообщений, которые пишет читатель
        /// </summary>
        const int messageCount = 5;
        int num;

        public Writer(TextBox output, MyBuffer buff, int num)
        {
            this.output = output;
            this.buff = buff;
            this.num = num;
        }

        /// <summary>
        /// Жизненный цикл писателя
        /// </summary>
        public void Write()
        {
            int messagesWrite = 0;
            output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " начал работу"  + Environment.NewLine));
            while (messagesWrite < messageCount)
            {
                messagesWrite++;
                string message = "П"+num.ToString()+" :" + new Random().Next(1000).ToString();
                if (buff.Write(message))
                    output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " положил сообщение" + message + Environment.NewLine));
                else
                    output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " попытался положить сообщение в заполненный" + Environment.NewLine));
                Thread.Sleep(new Random().Next(500, 1500));
            }
            output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " завершил работу"  + Environment.NewLine));
        }
    }
}
