using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Newton_Interpolation
{
    using static Convert;
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private readonly Pen _axisPen = new Pen(Color.Black, 2);  //пен для рисования сетки
        private readonly Pen _gridPen = new Pen(Color.DarkGray, 1);   //для рисования осей
        private readonly Pen _curvePen = new Pen(Color.Green, 2);  //примерный вид функции
        private readonly Pen _interpolatedCurvePen = new Pen(Color.Red, 2);  //примерный вид функции
        
        private readonly Pen _pointPen = new Pen(Color.Blue, 4); //точки
        private readonly Pen _interpolatedPointPen = new Pen(Color.Red, 4); //точки

        private bool _canZoom;
        private float _zoomCoeff = 1;
        private bool _canMove;

        private int _initialMouseX;
        private int _initialMouseY;

        private PointF _center;

        private List<double> _X = new List<double>();
        private List<double> _Y = new List<double>();

        private List<double> _interpolated_X = new List<double>();
        private List<double> _interpolated_Y = new List<double>();

        private double _step;
        private double _initial_X;
        private uint _final_X;

        private uint _interpolateStep;
        private double _interpolateInitial_X;
        private uint _interpolateFinal_X;

        

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += this_MouseWheel;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);

            _center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);

            _graphics.TranslateTransform(_center.X, _center.Y);
        }


        private double TestFunction(double x)
        {
            return Math.Sin(0.47 * x + 0.2) + Math.Pow(x, 2);
        }


        private double TestFunction2(double x)
        {
            return x * Math.Log10 (x) - 1.2;
        }


        private double Pn(double x)
        {
            int n = _X.Count;
            double result = _Y[0];

            int tempFactorial = 1;

            for (int i = 1; i < n; i++)
            {
                tempFactorial *= i;
                double temp = Delta(i, i) / (tempFactorial * Math.Pow(_step, i));
                for (int k = 0; k < i; k++)
                {
                    temp *= x - _X[k];
                }
                result += temp;
            }

            tempFactorial = 1;
            return result;

        }


        private double Delta(int degree, int i)
        {
            if (degree == 1)
                return _Y[i] - _Y[i - 1];
            else
                return Delta(degree - 1, i) - Delta(degree - 1, i - 1);
        }


        private void buildGrid()
        {
            float initialX = -1500 * _zoomCoeff;
            float initialY = -1500 * _zoomCoeff;
            float gridPitch = 25 * _zoomCoeff;

            while (initialX <= 1500)    //рисование сетки по Х
            {
                _graphics.DrawLine(initialX == 0 ? _axisPen : _gridPen, initialX, initialY, initialX, -initialY);

                initialX += gridPitch;
            }

            while (initialY <= 1500)    //по У то же самое
            {
                _graphics.DrawLine(initialY == 0 ? _axisPen : _gridPen, initialX, initialY, -initialX, initialY);

                initialY += gridPitch;
            }
        }


        private void drawFunction()
        {
            _graphics.Clear(Color.Transparent);

            buildGrid();

            PointF[] arrayToBuild = new PointF[_X.Count];   //создание массива точек для построения

            for (var i = 0; i < _X.Count; i++)
            {
                var tempOne = new PointF
                {
                    X = ToSingle(_X[i] * _zoomCoeff),
                    Y = -ToSingle(_Y[i] * _zoomCoeff)
                };  //создание отдельной точки
                //присваивание координат

                arrayToBuild[i] = tempOne;  //добавление точки в массив точек
            }

            _graphics.DrawCurve(_curvePen, arrayToBuild);  //примерный вид графика

            for (var i = 0; i < _X.Count; i++) //рисование точек
            {
                _graphics.DrawLine(_pointPen, arrayToBuild[i].X, arrayToBuild[i].Y + 3, arrayToBuild[i].X,
                    arrayToBuild[i].Y - 3);
                _graphics.DrawLine(_pointPen, arrayToBuild[i].X + 3, arrayToBuild[i].Y, arrayToBuild[i].X - 3,
                    arrayToBuild[i].Y);
            }


            if (_interpolated_X.Count != 0)
            {
                PointF[] interpolatedArrayToBuild = new PointF[_interpolated_X.Count];   //создание массива точек для построения

                for (var i = 0; i < _interpolated_X.Count; i++)
                {
                    var tempOne = new PointF
                    {
                        X = ToSingle(_interpolated_X[i] * _zoomCoeff),
                        Y = -ToSingle(_interpolated_Y[i] * _zoomCoeff)
                    };  //создание отдельной точки
                        //присваивание координат

                    interpolatedArrayToBuild[i] = tempOne;  //добавление точки в массив точек
                }

                _graphics.DrawCurve(_interpolatedCurvePen, interpolatedArrayToBuild);  //примерный вид графика

                for (var i = 0; i < _interpolated_X.Count; i++) //рисование точек
                {
                    _graphics.DrawLine(_interpolatedPointPen, interpolatedArrayToBuild[i].X, interpolatedArrayToBuild[i].Y + 3, interpolatedArrayToBuild[i].X,
                        interpolatedArrayToBuild[i].Y - 3);
                    _graphics.DrawLine(_interpolatedPointPen, interpolatedArrayToBuild[i].X + 3, interpolatedArrayToBuild[i].Y, interpolatedArrayToBuild[i].X - 3,
                        interpolatedArrayToBuild[i].Y);
                }
            }
            

            pictureBox1.Image = pictureBox1.Image;
        }


        //функция приближения
        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_canZoom == false || _X == null)
                return;

            _graphics.Clear(Color.Transparent);    //очиста рисунка

            if (e.Delta > 0)
            {
                _zoomCoeff *= (float)2;
            }
            else
            {
                _zoomCoeff /= (float)2;
            }

            drawFunction();

            pictureBox1.Image = pictureBox1.Image;
        }


        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            _canZoom = true;
        }


        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            _canZoom = false;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _canMove = true;
            _initialMouseX = e.X;
            _initialMouseY = e.Y;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _canMove = false;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canMove != true)  //началось ли перетаскивание
                return;

            _graphics.Clear(Color.Transparent);  //очистить текущее изображение

            var startX = e.X;
            var startY = e.Y;

            _graphics.TranslateTransform((startX +  - _initialMouseX), (startY - _initialMouseY));    //переместить начало координат для рисования

            drawFunction();    //перерисовать сетку и точки

            _initialMouseX = e.X;
            _initialMouseY = e.Y;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);

            _center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);

            _graphics.TranslateTransform(_center.X, _center.Y);

            drawFunction();
        }


        private void CreateValueTable_Button_Click(object sender, EventArgs e)
        {
            function_dataGridView.Rows.Clear();
            interpolated_dataGridView.Rows.Clear();

            _X.Clear();
            _Y.Clear();

            _interpolated_X.Clear();
            _interpolated_Y.Clear();

            string tempStrStep = step_textBox.Text;
            string tempStrInitialX = initialX_textBox.Text;
            string tempStrFinalX = finalX_textBox.Text;

            try
            {
                tempStrStep.Trim();
                tempStrInitialX.Trim();
                tempStrFinalX.Trim();

                _step = Convert.ToUInt32(tempStrStep);
                _initial_X = Convert.ToDouble(tempStrInitialX);
                _final_X = Convert.ToUInt32(tempStrFinalX);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные");
                return;
            }


            for (double i = _initial_X; i <= _final_X; i += _step)
            {
                _X.Add(i);
                _Y.Add(TestFunction(i));


                function_dataGridView.Rows.Add(i, TestFunction(i));
            }

            drawFunction();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            interpolated_dataGridView.Rows.Clear();

            _interpolated_X.Clear();
            _interpolated_Y.Clear();

            string tempInterpolateStrStep = interpolateStep_textBox.Text;
            string tempInterpolateStrInitialX = interpolateInitialX_textBox.Text;
            string tempInterpolateStrFinalX = interpolateFinalX_textBox.Text;

            try
            {
                tempInterpolateStrStep.Trim();
                tempInterpolateStrInitialX.Trim();
                tempInterpolateStrFinalX.Trim();

                _interpolateStep = Convert.ToUInt32(tempInterpolateStrStep);
                _interpolateInitial_X = Convert.ToDouble(tempInterpolateStrInitialX);
                _interpolateFinal_X = Convert.ToUInt32(tempInterpolateStrFinalX);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные");
                return;
            }

            for (double i = _interpolateInitial_X; i <= _interpolateFinal_X; i += _interpolateStep)
            {
                _interpolated_X.Add(i);
                _interpolated_Y.Add(Pn(i));

                interpolated_dataGridView.Rows.Add(i, Pn(i));
            }

            drawFunction();
        }
    }
}
