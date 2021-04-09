using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ISModeling {

    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }
       
        public static int countCSRandomSeries = 0;
        public static int countLehmerSeries = 0;

        public static int countTrapezoidSeries = 0;
        public static int countTriangleSeries = 0;

        public static int countNormalSeries = 0;

        // Встроенная функция
        private void button1_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox1.Text);
            int countIntervals = Convert.ToInt32(textBox2.Text);
            int countSeries = Convert.ToInt32(textBox3.Text);

            Series[] seriesMass = new Series[countSeries];
            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countCSRandomSeries + 1) };
                countCSRandomSeries++;

                double[] values = Algs.CSRandom(size);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)(value * countIntervals)]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);

                // Добавление серии в гистограмму
                chartRandom.Series.Add(seriesMass[s]);
            }
        }


        // Метод Лемера
        private void button4_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox7.Text);
            int countIntervals = Convert.ToInt32(textBox8.Text);
            int countSeries = Convert.ToInt32(textBox9.Text);

            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countLehmerSeries + 1) };
                countLehmerSeries++;

                double[] values = Algs.Lehmer(size);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)(value * countIntervals)]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);

                // Добавление серии в гистограмму
                chartLehmer.Series.Add(seriesMass[s]);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x;

            int size = Convert.ToInt32(textBox4.Text);
            int countIntervals = Convert.ToInt32(textBox4.Text);
            double[] arr = new double[countIntervals];

            int countSeries = Convert.ToInt32(textBox6.Text);
            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                for (int i = 0; i < countIntervals; i++) {
                    arr[i] = 0;
                }

                seriesMass[s] = new Series { Name = "Испытание " + (countCSRandomSeries + 1) };
                countCSRandomSeries++;

                int m = 100, a = 8, c = 65;
                x = 2;
                for (int i = 0; i < size; i++) {
                    x = ((a * x) + c) % m / (double)m * countIntervals;
                    arr[(int)x]++;
                }


                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++) {
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);
                }
                // Добавление серии в гистограмму
                chart3.Series.Add(seriesMass[s]);
            }
        }

        // Трапеция
        private void button8_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox10.Text);
            int countSeries = Convert.ToInt32(textBox18.Text);
            int shift = Convert.ToInt32(textBox12.Text);
            int countIntervals = Convert.ToInt32(textBox11.Text);
            int sizeV = Convert.ToInt32(textBox13.Text);

            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countTrapezoidSeries + 1) };
                countTrapezoidSeries++;

                double[] values = Algs.Trapezoid(countIntervals, size, sizeV);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)value]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1 + shift, arr[i]);

                // Добавление серии в гистограмму
                chartTrapezoid.Series.Add(seriesMass[s]);
            }
        }

        // Труегольник
        private void button10_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox17.Text);
            int countSeries = Convert.ToInt32(textBox14.Text);
            int shift = Convert.ToInt32(textBox15.Text);
            int countIntervals = Convert.ToInt32(textBox16.Text);

            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countTriangleSeries + 1) };
                countTriangleSeries++;

                double[] values = Algs.Triangle(countIntervals, size);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)value]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1 + shift, arr[i]);

                // Добавление серии в гистограмму
                chartTriangle.Series.Add(seriesMass[s]);
            }
        }

        // Нормальное
        private void button12_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox19.Text);
            int countIntervals = Convert.ToInt32(textBox21.Text);
            int countSeries = Convert.ToInt32(textBox20.Text);
            int Mx = Convert.ToInt32(textBox22.Text);
            int sigma = Convert.ToInt32(textBox23.Text);

            Series[] seriesMass = new Series[countSeries];
            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countNormalSeries + 1) };
                countNormalSeries++;

                double[] values = Algs.Normal(countIntervals, size, Mx, sigma);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    if (value > 0 && value < countIntervals)
                        arr[(int)value]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);

                // Добавление серии в гистограмму
                chartNormal.Series.Add(seriesMass[s]);
            }
        }

        // Кнопка Очистить Встроенная функция
        private void button2_Click(object sender, EventArgs e)
        {
            countCSRandomSeries = 0;
            chartRandom.Series.Clear();
        }
        // Кнопка Очистить метод простых конгруэнций
        private void button5_Click(object sender, EventArgs e)
        {
            chart3.Series.Clear();
        }
        // Кнопка Очистить метод Лемера
        private void button3_Click(object sender, EventArgs e)
        {
            countLehmerSeries = 0;
            chartLehmer.Series.Clear();
        }
        // Кнопка Очистить трапецию
        private void button7_Click(object sender, EventArgs e)
        {
            countTrapezoidSeries = 0;
            chartTrapezoid.Series.Clear();
        }
        // Кнопка Очистить треугольник
        private void button9_Click(object sender, EventArgs e)
        {
            countTriangleSeries = 0;
            chartTriangle.Series.Clear();
        }
        // Кнопка Очистить Нормальное
        private void button11_Click(object sender, EventArgs e)
        {
            countNormalSeries = 0;
            chartNormal.Series.Clear();
        }
    }
    class Algs {
        public static double[] CSRandom(int s)
        {
            double[] mass = new double[s];
            Random rnd = new Random();
            for (int i = 0; i < s; i++)
                mass[i] = rnd.NextDouble();
            return mass;
        }

        private static int seed = 1;
        public static double[] Lehmer(int s)
        {
            const int A = 16807;
            const int m = 2147483647;
            const int q = 127773;
            const int r = 2836;

            double[] mass = new double[s];
            for(int i = 0; i < s; i++) {
                int hi = seed / q;
                int lo = seed % q;
                seed = (A * lo) - (r * hi);
                if (seed <= 0)
                    seed += m;
                mass[i] = seed * 1.0 / m;
            }
            return mass;
        }

        public static double[] Trapezoid(int n, int s, int v)
        {
            double[] mass = new double[s];

            int b = (n / 2) - (v / 2);
            int c = (n / 2) + (v / 2);

            double[] x = Algs.CSRandom(s * 2);

            for (int i = 0; i < s; i++) {
                x[i] *= b;
                x[s + i] = x[s + i] * -c + c;

                mass[i] = x[i] + x[s + i];
            }

            return mass;
        }

        public static double[] Triangle(int n, int s)
        {
            double[] mass = new double[s];

            int b = n / 2;

            double[] x = Algs.CSRandom(s * 2);

            for (int i = 0; i < s; i++) {
                x[i] = x[i] * b;
                x[s + i] = b - x[s + i] * b ;

                mass[i] = x[i] + x[s + i];
            }

            return mass;
        }

        public static double[] Normal(int n, int s, int Mx, int sigma)
        {
            double[] mass = new double[s];
            double m = n;

            double[] x = Algs.CSRandom(s * n);

            for (int i = 0; i < s; i++) {
                double S = 0;

                for (int j = n * i; j < n * (i + 1); j++)
                    S += x[j];

                mass[i] = Mx + (sigma * (Math.Sqrt(12 / m) * (S - (m / 2))));
            }

            return mass;
        }
    }
}
