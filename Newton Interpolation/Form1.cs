using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Newton_Interpolation
{
    using static Convert;
    public partial class Form1 : Form
    {
        Graphics graphics;
        private readonly Pen axisPen_ = new Pen(Color.Black, 2);  //пен для рисования сетки
        private readonly Pen gridPen_ = new Pen(Color.DarkGray, 1);   //для рисования осей
        private readonly Pen curvePen_ = new Pen(Color.Green, 1);  //примерный вид функции
        private readonly Pen interpolatedCurvePen_ = new Pen(Color.Red, 1);  //примерный вид функции
        
        private readonly Pen pointPen_ = new Pen(Color.Blue, 4); //точки
        private readonly Pen interpolatedPointPen_ = new Pen(Color.Red, 4); //точки

        private bool canZoom;
        private float zoomCoeff = 1;
        private bool canMove;

        private int initialMouseX;
        private int initialMouseY;

        PointF center;

        private List<double> X = new List<double>();
        private List<double> Y = new List<double>();

        private List<double> interpolatedX = new List<double>();
        private List<double> interpolatedY = new List<double>();

        private uint _step = 10;
        private double _initialX;
        private uint _final_X;

        private uint _interpolateStep = 10;
        private double _interpolateInitialX;
        private uint _interpolateFinal_X;

        

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += this_MouseWheel;

            List<double> copy = new List<double>();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);

            graphics.TranslateTransform(center.X, center.Y);

        }


        private double TestFunction(double x)
        {
            return Math.Sin(0.47 * x + 0.2) + Math.Pow(x, 2);
        }


        private double TestFunction2(double x)
        {
            return Math.Sqrt(x) - Math.Cos(0.387 * x);
        }


        private double Pn(double x)
        {
            int n = X.Count;
            double result = Y[0];
            for (int i = 1; i < n; i++)
            {
                double temp = Delta(i, i) / (Factorial(i) * Math.Pow(_interpolateStep, i));
                for (int k = 0; k < i; k++)
                {
                    temp *= x - X[k];
                }
                result += temp;
            }

            return result;

        }


        private double Delta(int degree, int i)
        {
            if (degree == 1)
            {
                return Y[i] - Y[i - 1];
            }
            return Delta(degree - 1, i) - Delta(degree - 1, i - 1);
        }


        static double Factorial(double value)
        {
            if (value == 0) return 1;
            if (value == 1) return 1;
            return value * Factorial(value - 1);
        }


        private void functionPointTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void buildGrid()
        {
            float initialX = -1500 * zoomCoeff;
            float initialY = -1500 * zoomCoeff;
            float gridPitch = 10 * zoomCoeff;

            while (initialX <= 1500)    //рисование сетки по Х
            {
                graphics.DrawLine(initialX == 0 ? axisPen_ : gridPen_, initialX, initialY, initialX, -initialY);

                initialX += gridPitch;
            }

            while (initialY <= 1500)    //по У то же самое
            {
                graphics.DrawLine(initialY == 0 ? axisPen_ : gridPen_, initialX, initialY, -initialX, initialY);

                initialY += gridPitch;
            }
        }


        private void drawFunction()
        {
            buildGrid();

            PointF[] arrayToBuild = new PointF[X.Count];   //создание массива точек для построения

            for (var i = 0; i < X.Count; i++)
            {
                var tempOne = new PointF
                {
                    X = ToSingle(X[i] * zoomCoeff),
                    Y = -ToSingle(Y[i] * zoomCoeff)
                };  //создание отдельной точки
                //присваивание координат

                arrayToBuild[i] = tempOne;  //добавление точки в массив точек
            }

            graphics.DrawCurve(curvePen_, arrayToBuild);  //примерный вид графика

            for (var i = 0; i < X.Count; i++) //рисование точек
            {
                graphics.DrawLine(pointPen_, arrayToBuild[i].X, arrayToBuild[i].Y + 1, arrayToBuild[i].X,
                    arrayToBuild[i].Y - 1);
                graphics.DrawLine(pointPen_, arrayToBuild[i].X + 1, arrayToBuild[i].Y, arrayToBuild[i].X - 1,
                    arrayToBuild[i].Y);
            }



            PointF[] interpolatedArrayToBuild = new PointF[interpolatedX.Count];   //создание массива точек для построения

            for (var i = 0; i < interpolatedX.Count; i++)
            {
                var tempOne = new PointF
                {
                    X = ToSingle(interpolatedX[i] * zoomCoeff),
                    Y = -ToSingle(interpolatedY[i] * zoomCoeff)
                };  //создание отдельной точки
                //присваивание координат

                interpolatedArrayToBuild[i] = tempOne;  //добавление точки в массив точек
            }

            graphics.DrawCurve(interpolatedCurvePen_, interpolatedArrayToBuild);  //примерный вид графика

            for (var i = 0; i < interpolatedX.Count; i++) //рисование точек
            {
                graphics.DrawLine(interpolatedPointPen_, interpolatedArrayToBuild[i].X, interpolatedArrayToBuild[i].Y + 1, interpolatedArrayToBuild[i].X,
                    interpolatedArrayToBuild[i].Y - 1);
                graphics.DrawLine(interpolatedPointPen_, interpolatedArrayToBuild[i].X + 1, interpolatedArrayToBuild[i].Y, interpolatedArrayToBuild[i].X - 1,
                    interpolatedArrayToBuild[i].Y);
            }

            pictureBox1.Image = pictureBox1.Image;
        }


        //функция приближения
        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            graphics.Clear(Color.Transparent);    //очиста рисунка

            if (canZoom == false || X == null)
                return;

            graphics.Clear(Color.Transparent);    //очиста рисунка

            if (e.Delta > 0)
            {
                //graphics.ScaleTransform(1.2f, 1.2f);    //приближение

                zoomCoeff *= (float)2;

            }
            else
            {
                //graphics.ScaleTransform(0.8f, 0.8f); //отдаление

                zoomCoeff /= (float)2;
            }

            drawFunction();

            pictureBox1.Image = pictureBox1.Image;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            canZoom = true;
        }


        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            canZoom = false;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            canMove = true;
            initialMouseX = e.X;
            initialMouseY = e.Y;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (canMove != true)  //началось ли перетаскивание
            //    return;

            //graphics.Clear(Color.Transparent);  //очистить текущее изображение

            //var startX = e.X;
            //var startY = e.Y;

            //graphics.TranslateTransform((startX - initialMouseX), (startY - initialMouseY));    //переместить начало координат для рисования

            //drawFunction();    //перерисовать сетку и точки

            //pictureBox1.Image = pictureBox1.Image;    //обновить изображение

            canMove = false;
        }


        private void pictureBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove != true)  //началось ли перетаскивание
                return;

            graphics.Clear(Color.Transparent);  //очистить текущее изображение

            var startX = e.X;
            var startY = e.Y;

            graphics.TranslateTransform((startX +  - initialMouseX), (startY - initialMouseY));    //переместить начало координат для рисования

            drawFunction();    //перерисовать сетку и точки

            //pictureBox1.Image = pictureBox1.Image;    //обновить изображение

            initialMouseX = e.X;
            initialMouseY = e.Y;
        }


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);

            graphics.TranslateTransform(center.X, center.Y);

            drawFunction();
        }


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }


        private void CreateValueTable_Button_Click(object sender, EventArgs e)
        {
            function_dataGridView.Rows.Clear();

            X.Clear();
            Y.Clear();

            string tempStrStep = step_textBox.Text;
            string tempStrInitialX = initialX_textBox.Text;
            string tempStrFinalX = finalX_textBox.Text;

            try
            {
                tempStrStep.Trim();
                tempStrInitialX.Trim();
                tempStrFinalX.Trim();

                _step = Convert.ToUInt32(tempStrStep);
                _initialX = Convert.ToDouble(tempStrInitialX);
                _final_X = Convert.ToUInt32(tempStrFinalX);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные");
                return;
            }


            for (double i = _initialX; i <= _final_X; i += _step)
            {
                X.Add(i);
                Y.Add(TestFunction(i));


                function_dataGridView.Rows.Add(i, TestFunction(i));
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            function_dataGridView.Rows.Clear();
            interpolated_dataGridView.Rows.Clear();

            X.Clear();
            Y.Clear();

            interpolatedX.Clear();
            interpolatedY.Clear();

            string tempStrStep = interpolateStep_textBox.Text;
            string tempStrInitialX = interpolateInitialX_textBox.Text;
            string tempStrFinalX = interpolateFinalX_textBox.Text;

            try
            {
                tempStrStep.Trim();
                tempStrInitialX.Trim();
                tempStrFinalX.Trim();

                _interpolateStep = Convert.ToUInt32(tempStrStep);
                _interpolateInitialX = Convert.ToDouble(tempStrInitialX);
                _interpolateFinal_X = Convert.ToUInt32(tempStrFinalX);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные");
                return;
            }


            for (double i = _interpolateInitialX; i <= _interpolateFinal_X; i += _interpolateStep)
            {
                X.Add(i);
                Y.Add(TestFunction(i));


                function_dataGridView.Rows.Add(i, TestFunction(i));
            }

            for (double i = -50; i < 50; i += 5)
            {
                interpolatedX.Add(i);
                interpolatedY.Add(Pn(i));

                interpolated_dataGridView.Rows.Add(i, Pn(i));
            }
        }




        //private void drawGraphic()
        //{
        //    List<PointF> pointList = new List<PointF>();
        //    int stepCount = X.Count;
        //    pxStepX = pictureBox1.Width / stepCount;
        //    pxStepY = pictureBox1.Height / stepCount;

        //    // отрисовка шрихов на осях координат
        //    for (int i = 0; i < stepCount; i++)
        //    {
        //        graphics.DrawLine(axisPen_, center.X - pxStepX * i, center.Y - 5, center.X - pxStepX * i, center.Y + 5);
        //        graphics.DrawLine(axisPen_, center.X + pxStepX * i, center.Y - 5, center.X + pxStepX * i, center.Y + 5);

        //        graphics.DrawLine(axisPen_, center.X - 5, center.Y - pxStepY * i, center.X + 5, center.Y - pxStepY * i);
        //        graphics.DrawLine(axisPen_, center.X - 5, center.Y + pxStepY * i, center.X + 5, center.Y + pxStepY * i);
        //    }

        //    float pxInOneSinglePeace_X = pxStepX / (float)step;
        //    float pxInOneSinglePeace_Y = pxStepY / (float)step;

        //    float valueStepInOnePx_X = 1 / pxInOneSinglePeace_X;
        //    float valueStepInOnePx_Y = 1 / pxInOneSinglePeace_Y;

        //    for (float i = 0; i < pictureBox1.Width; i++)
        //    {
        //        pointList.Add(new PointF(i, (float)TestFunction2(valueStepInOnePx_X * i)));
        //    }



        //}
    }
}
