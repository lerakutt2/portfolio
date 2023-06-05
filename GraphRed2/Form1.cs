using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphRed2
{
    public partial class Form1 : Form
    {
        bool r_clicked = true;
        bool t_clicked = false;
        bool e_clicked = false;
        int index;
        Point startPoint;
        Graphics g;
        bool mousedown = false;
        Figure f;
        List<Figure> fs = new List<Figure>();
        Point[] p = new Point[2];
        Point[] points = new Point[2];
        public void Redraw()
        {
            for (int i = 0; i < fs.Count; i++)
            {
                fs[i].Draw(g);
            }
        }
        public Color SelectedColor()
        {
            if (borderColor.SelectedItem.ToString() == "Белый") return Color.White;
            else if (borderColor.SelectedItem.ToString() == "Красный") return Color.Red;
            else if (borderColor.SelectedItem.ToString() == "Оранжевый") return Color.Orange;
            else if (borderColor.SelectedItem.ToString() == "Желтый") return Color.Yellow;
            else if (borderColor.SelectedItem.ToString() == "Зеленый") return Color.Green;
            else if (borderColor.SelectedItem.ToString() == "Голубой") return Color.Blue;
            else if (borderColor.SelectedItem.ToString() == "Синий") return Color.Navy;
            else if (borderColor.SelectedItem.ToString() == "Фиолетовый") return Color.Purple;
            else if (borderColor.SelectedItem.ToString() == "Розовый") return Color.Pink;

            else return Color.Black;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            f = new Rectangle(thick.SelectedIndex, SelectedColor());
            if (!Moving.Checked && !BorderCheckBox.Checked)
            {
                g = pictureBox1.CreateGraphics();
                if (r_clicked) f = new Rectangle(thick.SelectedIndex, SelectedColor());
                else if (t_clicked) f = new Triangle(thick.SelectedIndex, SelectedColor());
                else if (e_clicked) f = new Ellipse(thick.SelectedIndex, SelectedColor());
                fs.Add(f);
                p[0] = new Point(e.X, e.Y);
            }
            else if (Moving.Checked)
            {
                for (int i = 0; i < fs.Count; i++)
                {
                    if (fs[i].HasInside(new Point(e.X, e.Y)))
                    {
                        points[0] = new Point(e.X, e.Y);
                        index = i;
                        startPoint = new Point(fs[i].x, fs[i].y);
                        break;
                    }
                }
            }
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            mousedown = true;
        }


        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown && !BorderCheckBox.Checked)
            {
                if (!Moving.Checked)
                {
                    int index = fs.Count - 1;
                    p[1] = new Point(e.X, e.Y);
                    fs[index].FillPoints(p);
                    fs[index].Draw(g);
                    g.Clear(pictureBox1.BackColor);
                    fs[index].Draw(g);
                    Redraw();
                }
                else
                {
                    points[1] = new Point(e.X, e.Y);
                    fs[index].x = startPoint.X + points[1].X - points[0].X;
                    fs[index].y = startPoint.Y + points[1].Y - points[0].Y;
                    if (fs[index] is Triangle)
                    {
                        Points[] ps = points[0], new Point(fs[index].x, fs[index].y);
                        fs[index].FillPoints();
                    }
                    fs[index].Draw(g);
                    g.Clear(pictureBox1.BackColor);
                    fs[index].Draw(g);
                    Redraw();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (BorderCheckBox.Checked)
            {
                for (int i = 0; i < fs.Count; i++)
                {
                    if (fs[i].HasInside(new Point(e.X, e.Y)))
                    {
                        fs[i].lineColor = SelectedColor();
                        break;
                    }
                }
            }
            mousedown = false;
            Redraw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BorderCheckBox.Checked)
            {
                
            }
        }


        private void Rectangle_Button_Click(object sender, EventArgs e)
        {
            r_clicked = true;
            t_clicked = false;
            e_clicked = false;
        }

        private void Ellipse_Button_Click(object sender, EventArgs e)
        {
            r_clicked = false;
            t_clicked = false;
            e_clicked = true;
        }

        private void Triangle_Button_Click(object sender, EventArgs e)
        {
            r_clicked = false;
            t_clicked = true;
            e_clicked = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            fs.Clear();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void BorderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BorderCheckBox.Checked) 
            {
                Moving.Checked = false;
            }
        }

        private void Moving_CheckedChanged(object sender, EventArgs e)
        {
            if (Moving.Checked) 
            {
                BorderCheckBox.Checked = false;
            }
        }
    }
}

