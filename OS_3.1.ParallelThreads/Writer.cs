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
        /// Очередь из сообщений
        /// </summary>
        Queue<string> messages;
        /// <summary>
        /// Куда выводим состояние потока
        /// </summary>
        TextBox output;

        TextBox bufferOutput;
        /// <summary>
        /// Количество сообщений, которые пишет читатель
        /// </summary>
        const int messageCount = 5;
        int num;

        public Writer(Queue<string> messages, TextBox output, TextBox bufferOutput, int num)
        {
            this.messages = messages;
            this.output = output;
            this.bufferOutput = bufferOutput;
            this.num = num;
        }

        public void Write()
        {
            lock(output)
            { output.Invoke(new Action(() => output.Text += "Создан писатель " + num.ToString() + Environment.NewLine)); }
            int i = 0;
            while (i<messageCount)
            {
                lock(output)
                {
                    if(messages.Count>=MyBuffer.maxCapacity)
                        output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " попытался положить число в заполненный буфер" + Environment.NewLine));
                    string msgToWrite = "П" + num.ToString() + " :" + (new Random().Next(1000)).ToString();
                    messages.Enqueue(msgToWrite);
                    lock(bufferOutput)
                    {
                        bufferOutput.Invoke(new Action(() => bufferOutput.Text += msgToWrite+Environment.NewLine));
                    }
                    output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " положил сообщение: "+msgToWrite + Environment.NewLine));
                    ++i;
                    Thread.Sleep(200);
                }
                Thread.Sleep(new Random().Next(500, 1500));
            }
            lock (output)
            { output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() +" прекратил работу"+ Environment.NewLine)); }
        }
    }
}
