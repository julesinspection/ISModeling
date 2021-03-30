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
       
        public static int countAllSeries = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //chart1.Series.Clear();
            Random rnd = new Random();
            double x;

           
            int size = Convert.ToInt32(textBox1.Text);
            int countIntervals = Convert.ToInt32(textBox3.Text);
            double[] arr = new double[countIntervals];

            int countSeries = Convert.ToInt32(textBox2.Text);
            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                for (int i = 0; i < countIntervals; i++) {
                    arr[i] = 0;
                }

                seriesMass[s] = new Series { Name = "Испытание " + (countAllSeries + 1) };
                countAllSeries++;                

                switch (listBox1.SelectedIndex) {
                    case 0:
                        for (int i = 0; i < size; i++) {
                            x = rnd.NextDouble() * countIntervals;
                            arr[(int)x]++;
                        }
                        break;
                    case 1:
                        int m = 100, a = 8, c = 65;
                        x = 1;
                        for (int i = 0; i < size; i++) {
                            x = ((a * x) + c) % m / (double)m * countIntervals;
                            arr[(int)x]++;
                        }
                        break;
                    case 2:
                        LehmerAlg L = new LehmerAlg();
                        for (int i = 0; i < size; i++) {
                            x = L.Lehmer();
                            int r = (int)(countIntervals * x);
                            arr[r]++;
                        }
                        break;
                }

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++) {
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);
                }
                // Добавление серии в гистограмму
                chart1.Series.Add(seriesMass[s]);
            }
            
        }

        // Кнопка Очистить
        private void button2_Click(object sender, EventArgs e)
        {
            countAllSeries = 0;
            chart1.Series.Clear();
        }
    }

    class LehmerAlg {
        private const int A = 16807;
        private const int m = 2147483647;
        private const int q = 127773;
        private const int r = 2836;
        private int seed = 1;
        //public LehmerAlg(int seed)
        //{
        //    if (seed <= 0 || seed == int.MaxValue)
        //        throw new Exception("Bad seed");
        //    this.seed = seed;
        //}
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
