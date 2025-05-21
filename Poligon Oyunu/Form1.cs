using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligon_Oyunu
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int isd = 0;
        int mousePosX;
        int mouseposY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isd = 1;
            mousePosX = Control.MousePosition.X;
            mouseposY = Control.MousePosition.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isd == 1)
            {
                this.Location = new Point(this.Location.X+(Control.MousePosition.X-mousePosX),this.Location.Y+(Control.MousePosition.Y-mouseposY));
                mousePosX = Control.MousePosition.X;
                mouseposY = Control.MousePosition.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isd = 0;
        }
        int saniye = 0;
        int sonrekor = 0;
        int milisaniye = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye = Int32.Parse(mywatch.ElapsedMilliseconds.ToString()) / 1000;
            milisaniye = Int32.Parse(mywatch.ElapsedMilliseconds.ToString()) % 1000;
            
            
            label3.Text = milisaniye.ToString();
            label2.Text = saniye.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Button circle = new Button();
        Stopwatch mywatch = new Stopwatch();
        Button startbutt = new Button();
        string executeloc;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            

            startbutt.Visible = true;
            startbutt.Location = new Point(220, 150);
            startbutt.Width = 100;
            startbutt.Height = 100;
            startbutt.Text = "Basla";
            startbutt.Name = "Baslabut1";
            startbutt.BackColor = Color.Green;
            startbutt.MouseClick += Startbutt_MouseClick;
            panel2.Controls.Add(startbutt);
            panel2.Refresh();
            executeloc = Assembly.GetExecutingAssembly().Location;
            executeloc = executeloc.Replace("\\Poligon Oyunu.exe", "\\mycircle.png");
        }
        Random myrand = new Random();
        int sayim = 0;
        private void Startbutt_MouseClick(object sender, MouseEventArgs e)
        {
            sayim = 0;
            mywatch = Stopwatch.StartNew();
            mywatch.Start();
            circle.Top = myrand.Next(300);
            circle.Left = myrand.Next(500);
            circle.Width = 50;
            circle.FlatAppearance.BorderSize = 0;
            circle.BackColor = Color.Transparent;
            circle.Height = 50;
            circle.FlatStyle = FlatStyle.Flat;
            circle.Image = Image.FromFile(executeloc);
            panel2.Controls.Add(circle);
            panel2.Refresh();
            circle.MouseClick += CircleClick;
            panel2.Controls.Remove(startbutt);
        }
        
        private void CircleClick(object sender,EventArgs e)
        {
            circle.Top = myrand.Next(300);
            circle.Left = myrand.Next(500);
            sayim++;
            if(sayim >= 30)
            {
                mywatch.Stop();
                panel2.Controls.Clear();
                MessageBox.Show("Oyun Bitti Skorunuz:" + saniye.ToString() + "saniye," + milisaniye.ToString() + "milisaniye");
                panel2.Controls.Add(startbutt);
                if(sonrekor < (saniye * 1000 + milisaniye))
                {
                    sonrekor = saniye * 1000 + milisaniye;
                    label1.Text = "Son Rekor:" + saniye.ToString() + "," + milisaniye.ToString();
                    
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Text = executeloc;
            
        }
    }
}
