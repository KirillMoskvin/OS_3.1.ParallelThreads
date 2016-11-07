using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OS_3._1.ParallelThreads
{
    class ThreadCreator
    {
        /// <summary>
        /// Буфер
        /// </summary>
        MyBuffer buff;
        // <summary>
        /// Количество читателей
        /// </summary>
        int numReaders = 0;
        /// <summary>
        /// Количество писателей
        /// </summary>
        int numWriters = 0;
        /// <summary>
        /// Списки потоков-читателей и писателей
        /// </summary>
        List<Thread> readersThreads;
        List<Thread> writersThreads;

        /// <summary>
        /// Текстбоксы для читателей и писателей
        /// </summary>
        TextBox tbReaders, tbWriters;

        public ThreadCreator(MyBuffer buff, TextBox tbReaders, TextBox tbWriters)
        {
            this.buff = buff;
            this.tbReaders = tbReaders;
            this.tbWriters = tbWriters;
            readersThreads = new List<Thread>();
            writersThreads = new List<Thread>();
        }

        /// <summary>
        /// Омновной метод работы, создающий читателей и писателей
        /// </summary>
        public void Run()
        {
            Random rnd = new Random();
            int rdCount = 1, wrCount = 1; ;
            while (true)
            {
                if (rnd.Next(2) == 0)
                {
                    Writer writer = new Writer(tbWriters, buff, wrCount);
                    wrCount++;
                    Thread writerThread = new Thread(writer.Write);
                    writersThreads.Add(writerThread);
                    writerThread.Start();
                }
                else
                {
                    Reader reader = new Reader(tbReaders, buff, rdCount);
                    rdCount++;
                    Thread readerThread = new Thread(reader.Read);
                    readersThreads.Add(readerThread);
                    readerThread.Start();
                }
                Thread.Sleep(rnd.Next(2000, 4000));
            }
        }
        /// <summary>
        /// Завершение работы
        /// </summary>
        public void Stop()
        {
            for (int i = 0; i < readersThreads.Count; i++)
                readersThreads[i].Abort();
            for (int i = 0; i < writersThreads.Count; i++)
                writersThreads[i].Abort();
            buff.Clear();
        }

        /// <summary>
        /// Продолжение работы
        /// </summary>
        public void Resume()
        {
            for (int i = 0; i < readersThreads.Count; i++)
            {
                if (readersThreads[i].ThreadState == ThreadState.Suspended)
                    readersThreads[i].Resume();
            }
            for (int i = 0; i < writersThreads.Count; i++)
            {
                if (writersThreads[i].ThreadState == ThreadState.Suspended)
                    writersThreads[i].Resume();
            }
        }
        /// <summary>
        /// Приостановка работы
        /// </summary>
        public void Pause()
        {
            for (int i = 0; i < readersThreads.Count; i++)
            {
                if (readersThreads[i].ThreadState == ThreadState.Running || readersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    readersThreads[i].Suspend();
            }
            for (int i = 0; i < writersThreads.Count; i++)
            {
                if (writersThreads[i].ThreadState == ThreadState.Running || writersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    writersThreads[i].Suspend();
            }
        }
    }
}
