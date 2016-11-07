using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OS_3._1.ParallelThreads
{
    public partial class ReadersWriters : Form
    {
        MyBuffer buffer; 
        ThreadCreator threadCreator;
        int max = 10;
        Thread workingThread; //поток, осуществляющий работу

        public ReadersWriters()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка нажатия "старт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            ///Созжаем экземпляры буфера и создателя потоков
            buffer = new MyBuffer(tb_messages, tb_readers, tb_writers);
            threadCreator = new ThreadCreator(buffer, tb_readers, tb_writers);
            workingThread = new Thread(new ThreadStart(threadCreator.Run));
            workingThread.Start(); //заускаем поток 
            //переводим состояния клавиш
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            btn_pause.Enabled = true;
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if(btn_pause.Text=="Пауза")
            {
                workingThread.Suspend();
                threadCreator.Pause();
                btn_stop.Enabled = false;
                btn_pause.Text = "Продолжить";
            }
            else
            {
                workingThread.Resume();
                threadCreator.Resume();
                btn_stop.Enabled = true;
                btn_pause.Text = "Пауза";
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            workingThread.Abort();
            threadCreator.Stop();
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            btn_pause.Enabled = false;
            tb_messages.Text = "";
            tb_readers.Text = "";
            tb_writers.Text = "";
        }

        private void ReadersWriters_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_stop.PerformClick();
        }

        private void ReadersWriters_Load(object sender, EventArgs e)
        {
            
        }
    }
}
