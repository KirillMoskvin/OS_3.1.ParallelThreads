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
        int max = 10;
        Thread buffThread;

        public ReadersWriters()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            buffer = new MyBuffer(tb_messages, tb_readers,  tb_writers);
            buffThread = new Thread(new ThreadStart(buffer.Run));
            buffThread.Start();
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            btn_pause.Enabled = true;
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if(btn_pause.Text=="Пауза")
            {
                buffThread.Suspend();
                buffer.Pause();
                btn_stop.Enabled = false;
                btn_pause.Text = "Продолжить";
            }
            else
            {
                buffThread.Resume();
                buffer.Resume();
                btn_stop.Enabled = true;
                btn_pause.Text = "Пауза";
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            buffThread.Abort();
            buffer.Stop();
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            btn_pause.Enabled = false;
            tb_messages.Text = "";
            tb_readers.Text = "";
            tb_writers.Text = "";
        }
    }
}
