using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_3._1.ParallelThreads
{
    class MyBuffer
    {
        /// <summary>
        /// Максимальное коичество элементов буфера
        /// </summary>
        public static int maxCapacity = 10;
        /// <summary>
        /// Сообщения
        /// </summary>
        Queue<string> messages;
        /// <summary>
        /// Объект потока-писателя
        /// </summary>
        Writer writer;
        /// <summary>
        /// Объект потока-читателя
        /// </summary>
        Reader reader;
        /// <summary>
        /// Поток-писатель
        /// </summary>
        Thread writerThread = null;
        /// <summary>
        /// Поток-читатель
        /// </summary>
        Thread readerThread = null;
        /// <summary>
        /// Количество читателей
        /// </summary>
        int numReaders = 0;
        /// <summary>
        /// Количество писателей
        /// </summary>
        int  numWriters = 0;
        /// <summary>
        /// Текстбокс для очереди
        /// </summary>
        private TextBox outBuffer;
        /// <summary>
        /// Текстбокс для читателей
        /// </summary>
        TextBox readBuffer;
        /// <summary>
        /// текстбокс для писателей
        /// </summary>
        TextBox writeBuffer;

        public MyBuffer(TextBox output, TextBox readers, TextBox writers)
        {
            outBuffer = output;
            readBuffer = readers;
            writeBuffer = writers;
            messages = new Queue<string>();
        }

        public void Run()
        {
            Random rnd = new Random();
            while(true)
            {
                if(rnd.Next(2)==0)
                {
                    writer = new Writer(messages, writeBuffer, outBuffer, numReaders);
                    numWriters++;
                    if ((writerThread==null)|| (writerThread.ThreadState!=ThreadState.Running)&&(writerThread.ThreadState != ThreadState.WaitSleepJoin))
                    {
                        writerThread = new Thread(writer.Write);
                        writerThread.Start();
                    }
                }
                else
                {
                    reader = new Reader(messages, readBuffer, outBuffer, numWriters);
                    numReaders++;
                    if ((readerThread == null) || (readerThread.ThreadState != ThreadState.Running) && (readerThread.ThreadState != ThreadState.WaitSleepJoin))
                    {
                        readerThread = new Thread(reader.Read);
                        readerThread.Start();
                    }
                }
                Thread.Sleep(rnd.Next(1500, 3000));
            }
        }

        public void Pause()
        {
            if ((writerThread.ThreadState == ThreadState.Running) || (writerThread.ThreadState == ThreadState.WaitSleepJoin))
                writerThread.Suspend();
            if ((readerThread.ThreadState == ThreadState.Running) || (readerThread.ThreadState == ThreadState.WaitSleepJoin))
                readerThread.Suspend();
        }

        public void Stop()
        {
            readerThread.Abort();
            writerThread.Abort();
            messages.Clear();
        }

        public void Resume()
        {
            if (writerThread.ThreadState == ThreadState.Suspended)
                writerThread.Resume();
            if (readerThread.ThreadState == ThreadState.Suspended)
                readerThread.Resume();
        }
    }
}
