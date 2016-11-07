namespace OS_3._1.ParallelThreads
{
    partial class ReadersWriters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb_messages = new System.Windows.Forms.TextBox();
            this.tb_readers = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tb_writers = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lbl_messages = new System.Windows.Forms.Label();
            this.lbl_readers = new System.Windows.Forms.Label();
            this.lbl_writers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_messages
            // 
            this.tb_messages.Location = new System.Drawing.Point(12, 23);
            this.tb_messages.Multiline = true;
            this.tb_messages.Name = "tb_messages";
            this.tb_messages.ReadOnly = true;
            this.tb_messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_messages.Size = new System.Drawing.Size(421, 395);
            this.tb_messages.TabIndex = 0;
            // 
            // tb_readers
            // 
            this.tb_readers.Location = new System.Drawing.Point(463, 23);
            this.tb_readers.Multiline = true;
            this.tb_readers.Name = "tb_readers";
            this.tb_readers.ReadOnly = true;
            this.tb_readers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_readers.Size = new System.Drawing.Size(293, 165);
            this.tb_readers.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tb_writers
            // 
            this.tb_writers.Location = new System.Drawing.Point(463, 247);
            this.tb_writers.Multiline = true;
            this.tb_writers.Name = "tb_writers";
            this.tb_writers.ReadOnly = true;
            this.tb_writers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_writers.Size = new System.Drawing.Size(293, 171);
            this.tb_writers.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 451);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(97, 29);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Старт";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Enabled = false;
            this.btn_pause.Location = new System.Drawing.Point(191, 451);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(81, 29);
            this.btn_pause.TabIndex = 5;
            this.btn_pause.Text = "Пауза";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(350, 451);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(83, 29);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "Стоп";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lbl_messages
            // 
            this.lbl_messages.AutoSize = true;
            this.lbl_messages.Location = new System.Drawing.Point(12, 9);
            this.lbl_messages.Name = "lbl_messages";
            this.lbl_messages.Size = new System.Drawing.Size(68, 13);
            this.lbl_messages.TabIndex = 7;
            this.lbl_messages.Text = "Сообщения:";
            // 
            // lbl_readers
            // 
            this.lbl_readers.AutoSize = true;
            this.lbl_readers.Location = new System.Drawing.Point(460, 9);
            this.lbl_readers.Name = "lbl_readers";
            this.lbl_readers.Size = new System.Drawing.Size(58, 13);
            this.lbl_readers.TabIndex = 8;
            this.lbl_readers.Text = "Читатели:";
            // 
            // lbl_writers
            // 
            this.lbl_writers.AutoSize = true;
            this.lbl_writers.Location = new System.Drawing.Point(460, 231);
            this.lbl_writers.Name = "lbl_writers";
            this.lbl_writers.Size = new System.Drawing.Size(59, 13);
            this.lbl_writers.TabIndex = 9;
            this.lbl_writers.Text = "Писатели:";
            // 
            // ReadersWriters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 511);
            this.Controls.Add(this.lbl_writers);
            this.Controls.Add(this.lbl_readers);
            this.Controls.Add(this.lbl_messages);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.tb_writers);
            this.Controls.Add(this.tb_readers);
            this.Controls.Add(this.tb_messages);
            this.Name = "ReadersWriters";
            this.Text = "Задача 1. 2.1.4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadersWriters_FormClosing);
            this.Load += new System.EventHandler(this.ReadersWriters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_messages;
        private System.Windows.Forms.TextBox tb_readers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tb_writers;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label lbl_messages;
        private System.Windows.Forms.Label lbl_readers;
        private System.Windows.Forms.Label lbl_writers;
    }
}

