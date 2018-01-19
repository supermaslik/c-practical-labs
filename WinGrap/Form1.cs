using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinGrap
{
    public partial class Form1 : Form
    {
        public Graphics g; //Графика
        public Bitmap map; //Битмап
        public Brush br; //Кисть
        public int iter = 12; //Количество итераций


        public Form1()
        {
            InitializeComponent();
        }

        //Рекурсивная функция отрисовки фрактала
        public int drawTSquare(PointF A, int size, int iter)
        {
            //точка А - координата левого верхнего угла квадрата
            //size - длина стороны
            //iter - кол-во итераций

            //База рекурсии
            //Если итерация одна, просто рисуем заполненный прямоугольник
            if (iter == 1)
            {
                g.FillRectangle(br, A.X, A.Y, size, size);
                return 0;
            }

            int d = size / 4; //Вспомогательная переменная, четверть длины исходного квадрата
            PointF[] M = new PointF[4];  //Координаты левых верхних углов порожденных квадратов

            for (int i = 0; i < 4; i++)
            {
                M[i] = new PointF();
            }

            //Левый верхний квадрат
            M[0].X = A.X - d;
            M[0].Y = A.Y - d;

            //Левый нижний квадрат
            M[1].X = A.X - d;
            M[1].Y = A.Y + size - d;

            //Правый верхний квадрат
            M[2].X = A.X + size - d;
            M[2].Y = A.Y - d;

            //Правый нижний квадрат
            M[3].X = A.X + size - d;
            M[3].Y = A.Y + size - d;

            //Вызываем рекурсивно для каждого квадрата
            for (int i = 0; i < 4; i++)
            {
                drawTSquare(M[i], size / 2, iter - 1);
            }

            //Отрисовываем исходный квадрат
            g.FillRectangle(br, A.X, A.Y, size, size);

            return 0;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);//Подключаем Битмап
            g = Graphics.FromImage(map); //Подключаем графику
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание
            br = new SolidBrush(Color.Red);
            g.Clear(Color.Black);

            //Координата верхнего левого угла квадрата
            PointF A = new PointF(pictureBox1.Width / 2 - pictureBox1.Height / 4, pictureBox1.Height / 4);

            //Вызов рекурсивной функции отрисовки фрактала
            drawTSquare(A, pictureBox1.Height / 2 - pictureBox1.Height / 10, iter);

            //Переносим картинку из битмапа на picturebox
            pictureBox1.BackgroundImage = map;

        }
    }
}
