using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
kgghkgjfjhghjfhfggjkghjghghjgkhghgh
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int dahdaj = 384738;
        int trys;
        int _try;
        double m = 0;
        double s = 0;
        public Form1()
        {
            InitializeComponent();               
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            info.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            label3.Visible = false;            
        }
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult res = MessageBox.Show("Вы ловкач!\n\nПоздравляю!\nВы выиграли!\n\nХотите продолжить?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) this.Close();
                else _try = trys;
            }           

            info.Text = "Попытка " + (trys - _try + 1) + " из " + trys;
        }       
       
        private async void label1_MouseEnter(object sender, EventArgs e)
        {
            await Task.Delay(10);

            Point point = new Point(new Random().Next(0, this.Size.Width - label1.Width - 100),
                                    new Random().Next(20, this.Size.Height - label1.Height - 150));

            label1.Location = point;

            _try--;
            if (_try == (int)(trys * 2 / 3))
            {
                DialogResult result = MessageBox.Show("Что то у вас не очень получается!\nПродолжить?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) this.Close();
            }
            else
            if (_try == (int)(trys / 3))
            {
                DialogResult result = MessageBox.Show("Все еще надеетесь, что получится?\nДумаете стоит продолжить?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) this.Close();
            }
            if (_try == 0)
            {
                DialogResult result = MessageBox.Show("Мне кажется, хватит!\nВы проиграли!", "", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel) this.Close();
                else
                if (result == DialogResult.Retry)
                {
                    _try = trys;
                    info.Text = "Попытка " + (trys - _try + 1) + " из " + trys;
                }
            }
            info.Text = "Попытка " + (trys - _try + 1) + " из " + trys;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyValue >= 48 && e.KeyValue <= 57) || e.KeyValue == 190 || e.KeyValue == 8 ||
                e.KeyValue == 191 || e.KeyValue == 14 || e.KeyValue == 37 || e.KeyValue == 39 || e.KeyValue == 46))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                trys = Convert.ToInt32(textBox1.Text);
                _try = trys;
                info.Text = "Попытка " + (trys - _try + 1) + " из " + trys;
                info.Visible = true;
                label1.Visible = true;
                button1.Visible = true;
                label3.Visible = true;
                label2.Visible = false;
                textBox1.Visible = false;

                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Пауза")
            {
                button1.Text = "Продолжить";
                timer1.Stop();
                label1.Visible = false;
            }
            else if (button1.Text == "Продолжить")
            {
                button1.Text = "Пауза";
                timer1.Start();
                label1.Visible = true;
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m < 60)
            {
                if (s < 60)
                {
                    s += 0.5;
                }
                else
                {
                    s = 0;
                    m += 0.5;
                }
            }
            else
            {
                MessageBox.Show("Вы безнадежны!!!", "", MessageBoxButtons.OK);
                if (DialogResult == DialogResult.OK) this.Close();
            }
            string time_s;
            string time_m;

            if (s < 10)
            {
                time_s = ":0" + s;
            }
            else time_s = ":" + s;
            if (m < 10)
            {
                time_m = ":0" + m;
            }
            else time_m = ":" + m;
            
            label3.Text = "00" + time_m + time_s;
        }
    }
}
