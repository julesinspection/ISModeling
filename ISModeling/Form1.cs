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

        public static int countExpSeries = 0;
        public static int countGExpSeries = 0;

        public static int countErlSeries = 0;


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

        // Метод простых 
        private void button6_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox4.Text);
            int countIntervals = Convert.ToInt32(textBox5.Text);
            int countSeries = Convert.ToInt32(textBox6.Text);

            Series[] seriesMass = new Series[countSeries];

            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countCSRandomSeries + 1) };
                countCSRandomSeries++;

                double[] values = Algs.SCongruence(countIntervals, size);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)(value * countIntervals)]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);

                // Добавление серии в гистограмму
                chart3.Series.Add(seriesMass[s]);
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

                double[] values = Algs.Trapezoid(countIntervals, size, sizeV, listBox1.SelectedIndex);
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

                double[] values = Algs.Triangle(countIntervals, size, listBox2.SelectedIndex);
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

                double[] values = Algs.Normal(countIntervals, size, Mx, sigma, listBox3.SelectedIndex);
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
        private void button22_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox35.Text);
            int countIntervals = Convert.ToInt32(textBox38.Text);
            int countSeries = Convert.ToInt32(textBox37.Text);

            Series[] seriesMass = new Series[countSeries];
            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countNormalSeries + 1) };
                countNormalSeries++;

                double[] values = Algs.Muller(countIntervals, size, listBox8.SelectedIndex);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    if (value > 0 && value < countIntervals)
                        arr[(int)value]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1, arr[i]);

                // Добавление серии в гистограмму
                chartM.Series.Add(seriesMass[s]);
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
        // Кнопка очистить Экспоненциальное
        private void button13_Click(object sender, EventArgs e)
        {
            countExpSeries = 0;
            chartExp.Series.Clear();
        }
        // Кнопка очистить Гиперэксп
        private void button17_Click(object sender, EventArgs e)
        {
            countGExpSeries = 0;
        }
        // Экспоненциальное
        private void button14_Click(object sender, EventArgs e)
        {
            chartGExp.Series.Clear();
            int size = Convert.ToInt32(textBox26.Text);
            int countIntervals = Convert.ToInt32(textBox28.Text);
            int L = Convert.ToInt32(textBox25.Text);
            Series s = new Series { Name = "Испытание" };
            countGExpSeries++;

            double[] arr = Algs.Exp(countIntervals, size, L, listBox4.SelectedIndex);


            // Добавление данных в серию
            for (int i = 0; i < size; i++)
                s.Points.AddXY(arr[i], 1);
            // Добавление серии в гистограмму
            chartExp.Series.Add(s);
            double interval = (arr.Max() - arr.Min()) / (double)countIntervals;
            chartExp.DataManipulator.Sort(PointSortOrder.Ascending, "X", "Испытание");
            chartExp.DataManipulator.Group("Count", interval, IntervalType.Number, "Испытание");
        }
        // Построить Гиперэксп
        private void button18_Click(object sender, EventArgs e)
        {
            chartGExp.Series.Clear();
            int size = Convert.ToInt32(textBox34.Text);
            int countIntervals = Convert.ToInt32(textBox36.Text);
            Series s = new Series { Name = "Испытание" };
            countGExpSeries++;

            double[] arr = Algs.GExp(countIntervals, size, listBox6.SelectedIndex);


            // Добавление данных в серию
            for (int i = 0; i < size; i++)
                s.Points.AddXY(arr[i], 1);
            // Добавление серии в гистограмму
            chartGExp.Series.Add(s);
            double interval = (arr.Max() - arr.Min()) / (double)countIntervals;
            chartGExp.DataManipulator.Sort(PointSortOrder.Ascending, "X", "Испытание");
            chartGExp.DataManipulator.Group("Count", interval, IntervalType.Number, "Испытание");

        }
        // Очистить эралнга
        private void button15_Click(object sender, EventArgs e)
        {
            countErlSeries = 0;
            chartErl.Series.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox29.Text);
            int countIntervals = Convert.ToInt32(textBox31.Text);
            int countSeries = Convert.ToInt32(textBox30.Text);
            int k = Convert.ToInt32(textBox24.Text);
            double L = Convert.ToInt32(textBox32.Text);

            Series[] seriesMass = new Series[countSeries];
            for (int s = 0; s < countSeries; s++) {

                seriesMass[s] = new Series { Name = "Испытание " + (countErlSeries + 1) };
                countErlSeries++;

                double[] values = Algs.Erl(countIntervals, size, k, L, listBox5.SelectedIndex);
                int[] arr = new int[countIntervals];

                foreach (var value in values)
                    arr[(int)value]++;

                // Добавление данных в серию
                for (int i = 0; i < countIntervals; i++)
                    seriesMass[s].Points.AddXY(i + 1,arr[i]);
                // Добавление серии в гистограмму
                chartErl.Series.Add(seriesMass[s]);            }
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

            private static double X = 1;
            public static double[] SCongruence(int n, int s)
            {
                const int m = 67;
                const int a = 45;
                const int c = 21;

                double[] mass = new double[s];

                for (int i = 0; i < s; i++) {
                    X = (a * X + c) % m / m * n;
                    mass[i] = X / n;
                }

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
                for (int i = 0; i < s; i++) {
                    int hi = seed / q;
                    int lo = seed % q;
                    seed = (A * lo) - (r * hi);
                    if (seed <= 0)
                        seed += m;
                    mass[i] = seed * 1.0 / m;
                }
                return mass;
            }

            public static double[] Trapezoid(int n, int s, int v, int AlgIndex)
            {
                double[] mass = new double[s];

                int b = (n / 2) - (v / 2);
                int c = (n / 2) + (v / 2);

                double[] x = new double[s * 2];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s * 2);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s * 2);
                        break;
                    case (2):
                        x = Algs.Lehmer(s * 2);
                        break;
                }

                for (int i = 0; i < s; i++) {
                    x[i] *= b;
                    x[s + i] = x[s + i] * -c + c;

                    mass[i] = x[i] + x[s + i];
                }

                return mass;
            }

            public static double[] Triangle(int n, int s, int AlgIndex)
            {
                double[] mass = new double[s];

                int b = n / 2;

                double[] x = new double[s * 2];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s * 2);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s * 2);
                        break;
                    case (2):
                        x = Algs.Lehmer(s * 2);
                        break;
                }

                for (int i = 0; i < s; i++) {
                    x[i] = x[i] * b;
                    x[s + i] = b - x[s + i] * b;

                    mass[i] = x[i] + x[s + i];
                }

                return mass;
            }

            public static double[] Normal(int n, int s, int Mx, int sigma, int AlgIndex)
            {
                double[] mass = new double[s];
                double m = n;

                double[] x = new double[s * n];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s * n);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s * n);
                        break;
                    case (2):
                        x = Algs.Lehmer(s * n);
                        break;
                }

                for (int i = 0; i < s; i++) {
                    double S = 0;

                    for (int j = n * i; j < n * (i + 1); j++)
                        S += x[j];

                    mass[i] = Mx + (sigma * (Math.Sqrt(12 / m) * (S - (m / 2))));
                }

                return mass;
            }

            public static double[] Muller(int n, int s, int AlgIndex)
            {
                double[] mass = new double[s];

                double[] x = new double[s * 2];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s * 2);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s * 2);
                        break;
                    case (2):
                        x = Algs.Lehmer(s * 2);
                        break;
                }

                for (int i = 0; i < s - 1; i++) {
                    for (int j = i * 2; j < (i + 1) * 2; j++) {
                        mass[i] = (-6 + Math.Sqrt(-2 * Math.Log(x[j]))) *  (-6 + Math.Sin(2 * Math.PI * x[j + 1]));
                    }
                        
                }

                return mass;
            }

            public static double[] Exp(int n, int s, double L, int AlgIndex)
            {
                double[] mass = new double[s];

                double[] x = new double[s];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s);
                        break;
                    case (2):
                        x = Algs.Lehmer(s);
                        break;
                }

                for (int i = 0; i < s; i++) {

                    mass[i] = -Math.Log(x[i]) / L;
                }

                return mass;
            }

            public static double[] Erl(int n, int s, int k, double L, int AlgIndex)
            {
                double[] mass = new double[s];

                double[] x = new double[s * k];

                x = Algs.Exp(n, s * k, L, AlgIndex);
                double S = 0;
                for (int i = 0; i < s; i++) {
                    S = 0;
                    for (int j = i * k; j < (i + 1) * k; j++)
                        S += x[j];

                    mass[i] = S;
                }

                return mass;
            }

            public static double[] GExp(int n, int s, int AlgIndex)
            {
                double[] mass = new double[s];

                double[] x = new double[s];

                switch (AlgIndex) {
                    case (-1):
                    case (0):
                        x = Algs.CSRandom(s);
                        break;
                    case (1):
                        x = Algs.SCongruence(n, s);
                        break;
                    case (2):
                        x = Algs.Lehmer(s);
                        break;
                }

                for (int i = 0; i < s; i++) {

                    mass[i] = Math.Pow(-Math.Log(x[i]) / 1, 1.3);
                }

                return mass;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            chart7.Series[0].Points.Clear();
            chart7.Series[1].Points.Clear();
            chart7.Series[2].Points.Clear();
            chart7.Series[3].Points.Clear();
            chart7.Series[4].Points.Clear();
            chart7.Series[5].Points.Clear();
            int[,] maxRealisedProducts = new int[6, 6] { 
                {0, 45,  25,  15,  8,  3, },
                { 200, 0,   60,  40,  20,  10 },
                { 290, 155, 0,   65,  32,  17},
                { 380, 210, 130, 0,   44,  24},
                { 470, 265, 165, 115,  0,   31},
                { 560, 320, 200, 140, 68,  0 } ,};
            int[] minProductsStorage = new int[6];
            minProductsStorage[0] = int.Parse(textBox111.Text);
            minProductsStorage[1] = int.Parse(textBox112.Text);
            minProductsStorage[2] = int.Parse(textBox113.Text);
            minProductsStorage[3] = int.Parse(textBox114.Text);
            minProductsStorage[4] = int.Parse(textBox115.Text);
            minProductsStorage[5] = int.Parse(textBox116.Text);
            int[] deliveryProductsStorage = new int[6];
            deliveryProductsStorage[0] = int.Parse(textBox121.Text);
            deliveryProductsStorage[1] = int.Parse(textBox122.Text);
            deliveryProductsStorage[2] = int.Parse(textBox123.Text);
            deliveryProductsStorage[3] = int.Parse(textBox124.Text);
            deliveryProductsStorage[4] = int.Parse(textBox125.Text);
            deliveryProductsStorage[5] = int.Parse(textBox126.Text);
            int[] currentProductStorage = new int[6] { 2000, 1000, 600, 400, 150, 50 }; 
            int[] allProductRequest = new int[6] { 0, 0, 0, 0, 0, 0 }; 
            int[] quantityMissingProducts = new int[6] { 0, 0, 0, 0, 0, 0 };
            Random random = new Random();
            for (int currentDay = 0; currentDay < 3000; currentDay++) {
                int[,] currentEveryRequest = new int[6, 6];
                switch (listBox7.SelectedIndex) {
                    case -1:
                    case 0:
                        for (int consumer = 0; consumer < 6; consumer++) {
                            for (int product = 0; product < 6; product++) {
                                currentEveryRequest[consumer, product] = random.Next(0, maxRealisedProducts[consumer, product]);
                            }
                        }
                        break;
                    case 1:
                        for (int consumer = 0; consumer < 6; consumer++) {
                            for (int product = 0; product < 6; product++) {
                                currentEveryRequest[consumer, product] = random.Next(0, maxRealisedProducts[consumer, product] / 2) + random.Next(0, maxRealisedProducts[consumer, product] / 2);
                            }
                        }
                        break;
                    case 2:
                        for (int consumer = 0; consumer < 6; consumer++) {
                            for (int product = 0; product < 6; product++) {
                                currentEveryRequest[consumer, product] = (int)(maxRealisedProducts[consumer, product] / 2 + Math.Sqrt(12 / 12) * (random.NextDouble() + random.NextDouble() + random.NextDouble() + random.NextDouble() - 2) / 2);
                            }
                        }
                        break;

                }
                
                int[] currentProductRequest = new int[6];
                for (int product = 0; product < 6; product++) {
                    for (int consumer = 0; consumer < 6; consumer++) {
                        currentProductRequest[product] += currentEveryRequest[consumer, product];
                    }
                    allProductRequest[product] += currentProductRequest[product];
                    currentProductStorage[product] -= currentProductRequest[product];
                    if (currentProductStorage[product] < 0) {
                        quantityMissingProducts[product] += Math.Abs(currentProductStorage[product]);
                        currentProductStorage[product] = deliveryProductsStorage[product];
                    }
                    else {
                        if (currentProductStorage[product] < minProductsStorage[product]) {
                            currentProductStorage[product] += deliveryProductsStorage[product];
                        }
                    }
                    chart7.Series[product].Points.AddXY(currentDay, allProductRequest[product] - quantityMissingProducts[product]);
                } 
            }
            double allRequest = allProductRequest.Sum();
            double allMissing = quantityMissingProducts.Sum();
            double precentCompleteRequest = 100 - (allMissing / allRequest) * 100;
            textBox27.Text = Math.Round(precentCompleteRequest, 2).ToString() + "%";
        }



        private void button20_Click(object sender, EventArgs e)
        {
            Queue<int> tasks1 = new Queue<int>();
            Queue<int> tasks2 = new Queue<int>();
            int maxTimeToType = Convert.ToInt32(textBox202.Text);
            int maxTimeToProc = Convert.ToInt32(textBox203.Text);
            int maxTimeToPrint = Convert.ToInt32(textBox204.Text);
            int targetTime = Convert.ToInt32(textBox201.Text);
            tasks1.Enqueue(1);
            tasks2.Enqueue(1);
            int sumTimeKlav = 0;
            int numTimeKlav = 0;
            int sumTimeProc = 0;
            int numTimeProc = 0;
            int sumTimePrint = 0;
            int numTimePrint = 0;
            int sumNumOfTasks = 0;
            int stopPrint = 0;
            int stopProc1 = 0;
            int stopProc2 = 0;
            int stopKlav = 0;
            bool isFirstMachineWork = false;
            int endOfFirst = 10;
            int endOfSecond = 10;
            bool isSecondMachineWork = false;
            bool isPrinterReady = true;
            int endOfPrint = -1;
            int endOfType = -1;
            bool isTypoReady = true;
            Queue<int> toPrint = new Queue<int>();
            Random r1 = new Random();
            Random r2 = new Random();
            for (int i = 0; i < targetTime; i++) {
                if (i == endOfType) {
                    Random r = new Random();
                    var task = r.Next(1, 2);
                    if (task == 1)
                        tasks1.Enqueue(1);
                    else
                        tasks2.Enqueue(1);
                    isTypoReady = true;
                }
                if (i == endOfPrint) {
                    isPrinterReady = true;
                    if (toPrint.Any()) {
                        toPrint.Dequeue();
                        isPrinterReady = false;
                        var time = GetTime(maxTimeToPrint, r1);
                        endOfPrint = i + time;
                        sumTimePrint += time;
                        numTimePrint++;
                    }
                }
                if (i == endOfFirst) {
                    isFirstMachineWork = false;
                    sumNumOfTasks++;
                    if (isPrinterReady) {
                        isPrinterReady = false;
                        var time = GetTime(maxTimeToPrint, r1);
                        endOfPrint = i + time;
                        sumTimePrint += time;
                        numTimePrint++;
                    } else
                        toPrint.Enqueue(1);
                }
                if (i == endOfSecond) {
                    isSecondMachineWork = false;
                    sumNumOfTasks++;
                    if (isPrinterReady) {
                        isPrinterReady = false;
                        var time = GetTime(maxTimeToPrint, r1);
                        endOfPrint = i + time;
                        sumTimePrint += time;
                        numTimePrint++;
                    } else {
                        toPrint.Enqueue(1);
                    }
                }
                if (!isFirstMachineWork) {
                    if (tasks2.Any()) {
                        var time = GetTime(maxTimeToProc, r1);
                        endOfFirst = i + time;
                        sumTimeProc += time;
                        numTimeProc++;
                        isFirstMachineWork = true;
                        tasks2.Dequeue();
                    }
                    else {
                        if (tasks1.Any()) {
                            var time = GetTime(maxTimeToProc, r1);
                            endOfFirst = i + time;
                            sumTimeProc += time;
                            numTimeProc++;
                            isFirstMachineWork = true;
                            tasks1.Dequeue();
                        }
                    }
                }
                if (!isSecondMachineWork) {
                    if (tasks2.Any()) {
                        var time = GetTime(maxTimeToProc, r1);
                        endOfSecond = i + time;
                        sumTimeProc += time;
                        numTimeProc++;
                        isSecondMachineWork = true;
                        tasks2.Dequeue();
                    }
                    else {
                        if (tasks1.Any()) {
                            var time = GetTime(maxTimeToProc, r1);
                            endOfSecond = i + time;
                            sumTimeProc += time;
                            numTimeProc++;
                            isSecondMachineWork = true;
                            tasks1.Dequeue();
                        }
                    }
                }
                if (isStartOfPrint(r2) && isTypoReady) {
                    isTypoReady = false;
                    var time = GetTime(maxTimeToType, r1);
                    endOfType = i + time;
                    sumTimeKlav += time;
                    numTimeKlav++;
                }
                if (isPrinterReady) {
                    stopPrint++;
                }
                if (isFirstMachineWork) {
                    stopProc1++;
                }
                if (isSecondMachineWork) {
                    stopProc2++;
                }
                if (!(isStartOfPrint(r2) && isTypoReady)) {
                    stopKlav++;
                }
            }
            textBox205.Text = Convert.ToString(sumNumOfTasks);
            if (numTimeKlav != 0) {
                textBox206.Text = Convert.ToString(sumTimeKlav / numTimeKlav);
            }
            if (numTimeProc != 0) { textBox208.Text = Convert.ToString(sumTimeProc / numTimeProc); }
            if (numTimePrint != 0) { textBox209.Text = Convert.ToString(sumTimePrint / numTimePrint); }

            textBox207.Text = Convert.ToString(sumTimeKlav);
            textBox211.Text = Convert.ToString(sumTimeProc);
            textBox212.Text = Convert.ToString(sumTimePrint);
            textBox214.Text = Convert.ToString(stopPrint);
            textBox213.Text = Convert.ToString(stopKlav);
        }
        private int GetTime(int x, Random r)
        {
            return r.Next(1, x);
        }

        private bool isStartOfPrint(Random r)
        {
            return r.Next(1, 100) < 20;
        }

    }
}
