using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Laba7
{
    public partial class Form1 : Form
    {
        int x = -1;
        int y = -1;
        Graphics g;
        Pen pen;
        bool moving = false;
        public Form1()
        {
            InitializeComponent();
            g = mainPanel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public void hidePanel()
        {
            mainPanel.Visible = false;
        }

        public void showPanel()
        {
            mainPanel.Visible = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) //кнопка new
        {
            StreamWriter File = new StreamWriter("NewFile.txt"); //файл кидается в папку source\repos\Laba7\Laba7\bin\Debug , при желании - можно указать путь в другое место
            File.Write("Hello there!");
            File.Close();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //кнопка save, файл сохраняется туда же, куда и текстовик
        {
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("NewFile.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = "Все права принадлежат лично Биллу Гейтсу \n" + "Илону Маску \n" + "А также НТУ ХПИ";
            MessageBox.Show(s, "Лабораторная работа");        }

        private void aboutProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = "В этой программе реализованы методы: \n" + "Рисования с определённым выбором цветов и последующего сохранения работы \n" + 
                "Создания текстового документа" + "А также смены цвета фона";
            MessageBox.Show(s, "Лабораторная работа");
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Green;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidePanel();
        }

        private void appearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            mainPanel.Cursor = Cursors.Cross;
        }
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            mainPanel.Cursor = Cursors.Default;
        }


    }
}
