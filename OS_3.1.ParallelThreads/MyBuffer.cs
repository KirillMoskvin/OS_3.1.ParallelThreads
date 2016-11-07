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

        /// <summary>
        /// Чтение сообщения
        /// </summary>
        /// <param name="str">Сообщение</param>
        /// <returns>true, если чтение удалось</returns>
        public bool Read(out string str)
        {
            if (messages.Count == 0)
            {
                str = "";
                return false;
            }
            else
                lock (this)
                {
                    outBuffer.Invoke(new Action(RemoveFirstLine));
                    str = messages.Dequeue();
                }
            return true;
        }
        /// <summary>
        /// Записывает сообщение
        /// </summary>
        /// <param name="str">Сообщение</param>
        /// <returns>true, если очередь не переполнена и запись удалась</returns>
        public bool Write(string str)
        {
            if (messages.Count >= maxCapacity)
                return false;
            lock(this)
            {
                outBuffer.Invoke(new Action(() => outBuffer.Text += str + "\r\n"));
                messages.Enqueue(str);
            }
            return true;
        }

        /// <summary>
        /// Метод удаляет первую строчку из текстбокса сообщений
        /// </summary>
        void RemoveFirstLine()
        {
            if (outBuffer.Lines.Length > 0)
            {
                List<string> list = outBuffer.Lines.ToList();
                list.RemoveAt(0);
                outBuffer.Lines = list.ToArray();
            }
        }
        /// <summary>
        /// Очистка буфера
        /// </summary>
        public void Clear()
        {
            messages.Clear();
        }

        

        
    }
}
