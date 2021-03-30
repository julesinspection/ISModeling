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
       
        public static int countAllSeriesRand = 0;
        public static int countAllSeriesLehmer = 0;

        // Встроенная функция
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double x;
           
            int size = Convert.ToInt32(textBox1.Text);
            int countIntervals = Convert.ToInt32(textBox2.Text);
            double[] arr = new double[countIntervals];

            int countSeries = Convert.ToInt32(textBox3.Text);
            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                for (int i = 0; i < countIntervals; i++) {
                    arr[i] = 0;
                }

                seriesMass[s] = new Series { Name = "Испытание " + (countAllSeriesRand + 1) };
                countAllSeriesRand++; 
                
                for (int i = 0; i < size; i++) {
                    x = rnd.NextDouble() * countIntervals;
                    arr[(int)x]++;
                }

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++) {
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);
                }
                // Добавление серии в гистограмму
                chart1.Series.Add(seriesMass[s]);
            }
            
        }


        // Метод Лемера
        private void button4_Click(object sender, EventArgs e)
        {
            double x;

            int size = Convert.ToInt32(textBox7.Text);
            int countIntervals = Convert.ToInt32(textBox8.Text);
            double[] arr = new double[countIntervals];

            int countSeries = Convert.ToInt32(textBox9.Text);
            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                for (int i = 0; i < countIntervals; i++) {
                    arr[i] = 0;
                }

                seriesMass[s] = new Series { Name = "Испытание " + (countAllSeriesLehmer + 1) };
                countAllSeriesLehmer++;
                LehmerAlg L = new LehmerAlg();
                for (int i = 0; i < size; i++) {
                    x = L.Lehmer();
                    int r = (int)(countIntervals * x);
                    arr[r]++;
                }

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++) {
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);
                }
                // Добавление серии в гистограмму
                chart2.Series.Add(seriesMass[s]);
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

                seriesMass[s] = new Series { Name = "Испытание " + (countAllSeriesRand + 1) };
                countAllSeriesRand++;

                int m = 100, a = 8, c = 65;
                x = 1;
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

        // Кнопка Очистить Встроенная функция
        private void button2_Click(object sender, EventArgs e)
        {
            countAllSeriesRand = 0;
            chart1.Series.Clear();
        }
        // Кнопка Очистить метод Лемера
        private void button3_Click(object sender, EventArgs e)
        {
            countAllSeriesLehmer = 0;
            chart2.Series.Clear();
        }
        // Кнопка Очистить метод простых конгруэнций
        private void button5_Click(object sender, EventArgs e)
        {
            chart3.Series.Clear();
        }
    }

    class LehmerAlg {
        private const int A = 16807;
        private const int m = 2147483647;
        private const int q = 127773;
        private const int r = 2836;
        private int seed = 1;
        public double Lehmer()
        {
            int hi = seed / q;
            int lo = seed % q;
            seed = (A * lo) - (r * hi);
            if (seed <= 0)
                seed = seed + m;
            return (seed * 1.0) / m;

        }
    }
}
