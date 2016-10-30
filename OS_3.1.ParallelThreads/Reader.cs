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
        /// Очередь из сообщений
        /// </summary>
        Queue<string> messages;
        /// <summary>
        /// Куда выводим состояние потока
        /// </summary>
        TextBox output;
        TextBox buffOutput;
        /// <summary>
        /// Количество сообщений, которые читает читатель
        /// </summary>
        const int messageCount= 5;
        int num;

        public Reader(Queue<string> messages, TextBox output, TextBox buffOutput, int num)
        {
            this.messages = messages;
            this.output = output;
            this.num = num;
            this.buffOutput = buffOutput;
        }
        /// <summary>
        /// Жизненный цикл читателя
        /// </summary>
        public void Read()
        {
            lock (output)
            { output.Invoke(new Action(() => output.Text += "Создан читатель " + num.ToString() + Environment.NewLine)); }
            int i = 0;
            while(i<messageCount)
            {
                lock(output)
                {
                    if (messages.Count == 0)
                        output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " попытался забрать сообщение, буфер был пуст" + Environment.NewLine));
                    else
                    {
                        string tmp = messages.Dequeue();
                        output.Invoke(new Action(()=> output.Text += "Читатель " + num.ToString() + " забрал сообщение"+tmp + Environment.NewLine));
                        lock(buffOutput)
                        {
                            buffOutput.Invoke(new Action(RemoveFirstLine));
                        }
                        ++i;
                        Thread.Sleep(200);
                    }
                }
                Thread.Sleep(new Random().Next(500, 1500));
            }

            lock (output)
            { output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " прекратил работу" + Environment.NewLine)); }
        }

        void RemoveFirstLine()
        {
            if (buffOutput.Lines.Length>0)
            {
                List<string> list = buffOutput.Lines.ToList();
                list.RemoveAt(0);
                buffOutput.Lines = list.ToArray();
            }
        }


    }
}
