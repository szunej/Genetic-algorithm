using Microsoft.VisualBasic.Logging;
using System.Runtime.CompilerServices;
using NCalc;
using NCalc.Handlers;
using System.Collections;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq;
using ScottPlot;
using ScottPlot.Interactivity.UserActionResponses;
using System.ComponentModel;
using OpenTK.Graphics.OpenGL;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ScottPlot.Plottables;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Algorytm_Genetyczny
{
    public partial class Form1 : Form
    {
        double a;
        double b;
        double d;
        List<double[]> AllteststResults = new List<double[]>();
        int countbackgroundWorker = 0;
        BackgroundWorker[] arrayBackgroundWorkers = new BackgroundWorker[Environment.ProcessorCount - 2];
        double[] BestResult;

        public Form1()
        {
            InitializeComponent();
            panelData.Visible = true;
            panelPlot.Visible = false;
            panelTest.Visible = false;
            buttonDane.Enabled = false;
            progressBar.Maximum = 1762;
            for (int i = 0; i < arrayBackgroundWorkers.Length; i++)
            {
                arrayBackgroundWorkers[i] = new BackgroundWorker();
                arrayBackgroundWorkers[i].WorkerReportsProgress = true;
                arrayBackgroundWorkers[i].DoWork += backgroundWorker_DoWork;
            }
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            start(false, double.Parse(textBoxA.Text), double.Parse(textBoxB.Text), double.Parse(comboBoxD.Text),
                  double.Parse(textBoxPk.Text), double.Parse(textBoxPm.Text), int.Parse(textBoxN.Text), int.Parse(textBoxT.Text));
        }

        private async void buttonStartTest_Click(object sender, EventArgs e)
        {
            buttonStartTest.Visible = false;
            progressBar.Visible = true;
            double a = double.Parse(textBoxA.Text);
            double b = double.Parse(textBoxB.Text);
            double d = double.Parse(comboBoxD.Text);

            List<double> values = [a, b, d,];
            int finishedThred = 0;
            BackgroundWorker mainBackgroundWorker = new BackgroundWorker();
            mainBackgroundWorker.WorkerReportsProgress = true;
            mainBackgroundWorker.RunWorkerCompleted += backgroundWorker_Complite;
            mainBackgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            BackgroundWorker worker = null;
            mainBackgroundWorker.DoWork += (sender, e) =>
            {
                BackgroundWorker mainWorker = sender as BackgroundWorker;
                mainBackgroundWorker.ReportProgress(2);
                for (int nTest = 30; nTest <= 80; nTest += 5)
                {
                    for (double pkTest = 0.5; pkTest <= 0.5 /*0.9*/; pkTest += 0.05)
                    {
                        for (double pmTest = 0.0016; pmTest <=0.0016 /*0.01*/; pmTest += 0.0005)
                        {

                            countbackgroundWorker++;
                            if (pmTest == 0)
                                pmTest = 0.0001;
                            do
                            {
                                worker = FindAvailable();
                                Thread.Sleep(1);
                            }
                            while (worker == null);
                            double[] values = [a, b, d, pkTest, pmTest, nTest, 200];
                            worker.RunWorkerAsync(values);
                            mainBackgroundWorker.ReportProgress(1);
                        }
                    }
                    while (arrayBackgroundWorkers.Any(worker => worker.IsBusy))
                    {

                    }

                }
                while (arrayBackgroundWorkers.Any(worker => worker.IsBusy))
                {
                }
                double[] Result = ListResultsSort(AllteststResults);
                AllteststResults.Clear();
                double[] value = [a, b, d, Result[1], Result[2], Result[0], 0];
                for (int tTest = 50; tTest <= 150; tTest += 10)
                {
                    value[6] = tTest;
                    do
                    {
                        worker = FindAvailable();
                        Thread.Sleep(1);
                    }
                    while (worker == null);
                    worker.RunWorkerAsync(value);
                }
                while (arrayBackgroundWorkers.Any(worker => worker.IsBusy))
                {
                    Thread.Sleep(1);
                }
                BestResult = FindBestT(AllteststResults);
            };
            mainBackgroundWorker.RunWorkerAsync();



        }
        private void backgroundWorker_Complite(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar.Visible = false;
            labelResult.Visible = true;
            buttonReset.Visible = true;
            label14.Visible = true;
            labelResult.Text = "Najlepszy wynik: N= " + BestResult[0].ToString() + " pk= " + BestResult[1].ToString() + " pm= " + BestResult[2].ToString() +
                " Średnia wartość = " + BestResult[3].ToString() + " Największa wartość = " + BestResult[4].ToString() + " T= " + BestResult[5].ToString();
        }


        private BackgroundWorker FindAvailable()
        {
            foreach (BackgroundWorker worker in arrayBackgroundWorkers)
            {
                if (!(worker.IsBusy))
                {
                    return worker;
                }
            }
            return null;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            double[] tabValues = (double[])e.Argument;
            a = tabValues[0];
            b = tabValues[1];
            d = tabValues[2];
            double pkTest = tabValues[3];
            double pmTest = tabValues[4];
            int nTest = (int)tabValues[5];
            int tTest = (int)tabValues[6];
            BackgroundWorker worker = sender as BackgroundWorker;
            Object sem = new object();
            double[] testResult = new double[100];

            for (int i = 0; i < 100; i++)
            {
                testResult[i] = start(true, a, b, d, pkTest, pmTest, nTest, tTest);
            }
            lock (sem)
            {
                AllteststResults.Add(new double[] { (double)nTest, pkTest, pmTest, testResult.Average(), testResult.Max(), tTest });
            }






        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value += e.ProgressPercentage;
        }

        private double[] ListResultsSort(List<double[]> list)
        {
            List<double[]> listMaxFAvg = new List<double[]>();
            if (listMaxFAvg.Count == 0)
            {


            }
            double maxFAvg = list[0][3];
            listMaxFAvg.Add(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                if (maxFAvg < list[i][3])
                {
                    maxFAvg = list[i][3];
                    listMaxFAvg.Clear();
                    listMaxFAvg.Add(list[i]);
                }
                else if (maxFAvg == list[i][3])
                {
                    listMaxFAvg.Add(list[i]);
                }
            }
            if (listMaxFAvg.Count > 0)
            {
                double maxFMax = listMaxFAvg[0][4];
                double[] parFMax = list[0];
                for (int i = 1; i < listMaxFAvg.Count; i++)
                {
                    if (maxFMax < list[i][4])
                    {
                        maxFMax = list[i][4];
                        parFMax = list[i];

                    }
                }
                listMaxFAvg.Clear();
                listMaxFAvg.Add(parFMax);
            }
            return listMaxFAvg[0];
        }

        private double[] FindBestT(List<double[]> list)
        {
            double[] theBest = list[0];
            double theBestT = list[0][5];
            double theBestFmax = list[0][3];
            double theBestFAvg = list[0][4];


            foreach (double[] array in list)
            {
                if (array[4] > theBestFAvg)
                {
                    theBestFAvg = array[4];
                    theBestFmax = array[3];
                    theBestT = array[5];
                    theBest = array;

                }
                else if (array[4] == theBestFAvg)
                {
                    if (array[3] < theBestFmax)
                    {
                        theBestFAvg = array[4];
                        theBestFmax = array[3];
                        theBestT = array[5];
                        theBest = array;

                    }
                    else if (array[3] == theBestFmax)
                    {
                        if (array[5] < theBestT)
                        {
                            theBestFAvg = array[4];
                            theBestFmax = array[3];
                            theBestT = array[5];
                            theBest = array;
                        }
                    }

                }
            }
            return theBest;

        }


        private void buttonTest_Click(object sender, EventArgs e)
        {
            panelData.Visible = false;
            panelPlot.Visible = false;
            panelTest.Visible = true;

            buttonPlot.Enabled = true;
            buttonDane.Enabled = true;
            buttonTest.Enabled = false;

        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {

            panelData.Visible = false;
            panelPlot.Visible = true;
            panelTest.Visible = false;

            buttonPlot.Enabled = false;
            buttonDane.Enabled = true;
            buttonTest.Enabled = true;

        }

        private void buttonDane_Click(object sender, EventArgs e)
        {
            panelData.Visible = true;
            panelPlot.Visible = false;
            panelTest.Visible = false;

            buttonPlot.Enabled = true;
            buttonDane.Enabled = false;
            buttonTest.Enabled = true;

        }

        private double start(bool doTest, double a, double b, double d, double Pk, double Pm, int n, int t)
        {
            bool doElite = checkBoxElita.Checked;
            double[] population = new double[n];
            double[] tabFMax = new double[t];
            double[] tabFAvg = new double[t];
            double[] tabFMin = new double[t];

            //losowanie początkowej populacji
            for (int i = 0; i < n; i++)
            {
                population[i] = Math.Round(a + (new Random().NextDouble() * (b - a)), (-1) * (int)(Math.Log10(d)));

            }



            // wykonywanie t powtórzeń algorytmu
            for (int i = 0; i < t; i++)
            {
                ArrayList result = genAlgorytm(a, b, d, Pk, Pm, n, doElite, population);
                population = (double[])result[0];
                tabFMax[i] = (double)result[1];
                tabFMin[i] = (double)result[2];
                tabFAvg[i] = (double)result[3];


            }

            if (!doTest)
            {
                formsPlot1.Plot.Clear();
                //tworzenie wykresu
                int[] plotX = Enumerable.Range(1, t + 1).ToArray();
                var plotFMax = formsPlot1.Plot.Add.Scatter(plotX, tabFMax);
                plotFMax.LegendText = "f(x) max";
                var plotFAvg = formsPlot1.Plot.Add.Scatter(plotX, tabFAvg);
                plotFAvg.LegendText = "f(x) średnia";
                var plotFMin = formsPlot1.Plot.Add.Scatter(plotX, tabFMin);
                plotFMin.LegendText = "f(x) min";
                formsPlot1.Plot.ShowLegend(Alignment.UpperLeft);
                formsPlot1.Visible = true;
                formsPlot1.Plot.Axes.AutoScale();
                formsPlot1.Refresh();

                tableLayoutPanelData.Controls.Clear();
                tableLayoutPanelData.RowCount = n;
            }

            HashSet<double> listUnicPopu = new HashSet<double>();
            foreach (double individual in population)
            {
                listUnicPopu.Add(individual);
            }


            int l = GenNumber(a, b, d);
            List<ArrayList> listAllResult = new List<ArrayList>();
            foreach (double individual in listUnicPopu)
            {
                ArrayList listLoopResult = new ArrayList();


                listLoopResult.Add(individual);

                //zamiana xreal na xbin
                listLoopResult.Add(IntToBin(RealToInt(individual, a, b, l), l));

                //wyliczanie funkcji celu
                Expression ex = new Expression(textBoxFun.Text);
                ex.Parameters["x"] = individual;
                ex.EvaluateParameter += delegate (string name, ParameterArgs args)
                {
                    if (name == "Pi")
                        args.Result = Math.PI;
                };
                listLoopResult.Add((double)ex.Evaluate());

                //wylicznie ile procent populacji to ten wynik
                var number = population.Where(ind => ind == individual);
                listLoopResult.Add((((double)number.Count() / population.Length) * 100).ToString());

                listAllResult.Add(listLoopResult);
            }

            if (!doTest)
            {
                //sortownie listy wyników po procencie populacji
                for (int i = 0; i < listAllResult.Count; i++)
                {
                    for (int j = 0; j < listAllResult.Count - 1; j++)
                    {
                        if (Double.Parse((String)listAllResult[j][3]) < Double.Parse((String)listAllResult[j + 1][3]))
                        {

                            ArrayList tempList = listAllResult[j];
                            listAllResult[j] = listAllResult[j + 1];
                            listAllResult[j + 1] = tempList;
                        }
                    }
                }

                int count = 0;
                foreach (ArrayList listLoop in listAllResult)
                {
                    //numeracja wierszy
                    System.Windows.Forms.Label labelNumber = new System.Windows.Forms.Label();
                    labelNumber.TextAlign = ContentAlignment.MiddleCenter;
                    labelNumber.Text = (count + 1).ToString();
                    tableLayoutPanelData.Controls.Add(labelNumber, 0, count);

                    //wypisanie xreal
                    System.Windows.Forms.Label labelXReal = new System.Windows.Forms.Label();
                    labelXReal.TextAlign = ContentAlignment.MiddleCenter;
                    labelXReal.Text = listLoop[0].ToString();
                    tableLayoutPanelData.Controls.Add(labelXReal, 1, count);

                    //wypisanie xbin
                    System.Windows.Forms.Label labelXBin = new System.Windows.Forms.Label();
                    labelXBin.Text = (String)listLoop[1];
                    labelXBin.TextAlign = ContentAlignment.MiddleCenter;
                    tableLayoutPanelData.Controls.Add(labelXBin, 2, count);


                    //wypisanie wartości funkcji celu
                    System.Windows.Forms.Label labelFun = new System.Windows.Forms.Label();
                    labelFun.TextAlign = ContentAlignment.MiddleCenter;
                    labelFun.Text = listLoop[2].ToString();
                    tableLayoutPanelData.Controls.Add(labelFun, 3, count);

                    //wypisanie procentu ile populacji to ten wynik
                    System.Windows.Forms.Label labelPercent = new System.Windows.Forms.Label();
                    labelPercent.TextAlign = ContentAlignment.MiddleCenter;
                    labelPercent.Text = listLoop[3].ToString();
                    tableLayoutPanelData.Controls.Add(labelPercent, 4, count++);
                }

            }
            double fMax = 0;
            if (doTest)
            {
                fMax = tabFMax.Max();
            }

            return fMax;
        }

        private ArrayList genAlgorytm(double a, double b, double d, double Pk, double Pm, int n, bool doElite, double[] population)
        {
            double[] tabF = new double[n];
            double[] tabX = new double[n];
            double[] tabG = new double[n];
            double[] tabP = new double[n];
            double[] tabQ = new double[n];
            double[] tabR = new double[n];
            double[] tabRealXAfterSele = new double[n];
            double[] tabNewRealX = new double[n];
            String[] tabBinXAfterSele = new string[n];
            bool[] parentIndex = new bool[n];
            double r = 0;
            List<string> listParent = new List<string>();
            List<string> listChild = new List<string>();
            Expression ex = null;

            int l = GenNumber(a, b, d);
            tabX = population;
            for (int i = 0; i < n; i++)
            {


                //licznie funkcji
                ex = new Expression(textBoxFun.Text);
                ex.Parameters["x"] = tabX[i];
                ex.EvaluateParameter += delegate (string name, ParameterArgs args)
                {
                    if (name == "Pi")
                        args.Result = Math.PI;
                };
                tabF[i] = (double)ex.Evaluate();
            }

            //tworzenie elity
            double[] elite = [0, 0];
            if (doElite)
            {
                double maxFunValue = tabF.Max();
                int eliteIndex = Array.IndexOf(tabF, maxFunValue);
                elite = [tabX[eliteIndex], tabF[eliteIndex]];
            }

            double min = minFind(tabF);
            for (int i = 0; i < n; i++)
            {

                ex.Parameters["x"] = tabF[i];
                double resultF = (double)ex.Evaluate();
                double resultG = tabF[i] - min + d;
                tabG[i] = resultG;
            }

            tabQ[0] = 0;
            for (int i = 0; i < n; i++)
            {
                //wyliczanie prawdopodbieństwa reprodukcji
                double sum = tabG.Sum();
                double p = tabG[i] / sum;



                //wylicznie dystrybunaty
                if (i == 0)
                {
                    tabQ[0] = p;
                }
                else
                {
                    tabQ[i] = tabQ[i - 1] + p;
                }


                //losowanie r 
                r = new Random().NextDouble();
                tabR[i] = r;

            }

            //selekcja
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                bool survive = false;
                while (!survive)
                {


                    if (j == 0)
                    {
                        if (tabR[i] <= tabQ[j])
                        {
                            survive = true;

                        }

                    }
                    else if (j < n && tabQ[j - 1] < tabR[i] && tabR[i] <= tabQ[j])
                    {
                        survive = true;

                    }


                    if (survive)
                    {

                        tabRealXAfterSele[i] = tabX[j];
                    }
                    j++;
                }
            }

            //tłumaczenia na binarne
            for (int i = 0; i < n; i++)
            {

                tabBinXAfterSele[i] = IntToBin(RealToInt(tabRealXAfterSele[i], a, b, l), l);

            }
            //selekacja na rodzica
            for (int i = 0; i < n; i++)
            {

                if (new Random().NextDouble() <= Pk)
                {
                    listParent.Add(tabBinXAfterSele[i]);

                    parentIndex[i] = true;
                }

            }

            //tworzenie dzieci
            ArrayList listPc = new ArrayList();
            Random rand = new Random();
            if (listParent.Count % 2 != 0)
            {
                listParent.RemoveAt(listParent.Count - 1);
            }
            for (int i = 0; i < listParent.Count; i += 2)
            {

                int random = (int)(new Random().NextDouble() * l);
                listPc.Add(random + 1);
                listPc.Add(random + 1);
                listChild.Add(listParent[i].Substring(0, random) + listParent[i + 1].Substring(random));
                listChild.Add(listParent[i + 1].Substring(0, random) + listParent[i].Substring(random));

            }

            int counter = 0;
            for (int i = 0; i < n; i++)
            {



                if (parentIndex[i] && counter < listParent.Count)
                {

                    tabBinXAfterSele[i] = listChild[counter];
                    counter++;

                }


            }


            //mutajca
            for (int i = 0; i < n; i++)
            {
                string mutationPoints = "";
                char[] chromosom = tabBinXAfterSele[i].ToCharArray();
                for (int j = 0; j < chromosom.Length; j++)
                {


                    if (new Random().NextDouble() < Pm)
                    {

                        if (chromosom[j] == '0')
                        {
                            chromosom[j] = '1';
                        }
                        else
                            chromosom[j] = '0';
                        mutationPoints += (j + 1) + ",";
                    }
                }

                tabBinXAfterSele[i] = new string(chromosom);


                //następne pokolenie
                double newRealX = Math.Round(IntToReal(BinToInt(tabBinXAfterSele[i]), a, b, l), (-1) * (int)(Math.Log10(d)));
                tabNewRealX[i] = newRealX;


                //liczenie wartości dla funkcji oceny
                ex.Parameters["x"] = newRealX;
                tabF[i] = (double)ex.Evaluate();

            }

            //wstawianie elity
            if (doElite)
            {
                int randIndex = new Random().Next(0, tabNewRealX.Length);
                if (tabF[randIndex] < elite[1])
                {
                    tabNewRealX[randIndex] = elite[0];
                    tabF[randIndex] = elite[1];
                }
            }

            //liczenie maksylmanego,najmniejszego i średniego f(x)
            double fMax = tabF.Max();
            double fMin = tabF.Min();
            double fAvg = tabF.Average();
            return [tabNewRealX, fMax, fMin, fAvg];
        }



        private int GenNumber(double a, double b, double d)
        {
            return (int)Math.Ceiling(Math.Log(((b - a) / d) + 1, 2));
        }

        private int RealToInt(double number, double a, double b, int l)
        {
            double result = (1 / (b - a)) * (number - a) * (Math.Pow(2, l) - 1);
            return (int)result;
        }

        private String IntToBin(int intValue, int l)
        {
            String bin = "";
            for (int i = l - 1; i >= 0; i--)
            {
                int pow = (int)Math.Pow(2, i);
                if (intValue >= pow)
                {
                    intValue -= pow;
                    bin += "1";
                }
                else
                    bin += "0";

            }
            return bin;
        }

        private int BinToInt(String bin)
        {
            char[] charArray = bin.ToCharArray();
            Array.Reverse(charArray);
            int intValue = 0;
            int i = 0;
            foreach (char c in charArray)
            {
                if (c == '1')
                    intValue += (int)Math.Pow(2, i);
                i++;
            }
            return intValue;
        }

        private double IntToReal(double intValue, double a, double b, double l)
        {
            return ((intValue * (b - a)) / (Math.Pow(2, l) - 1)) + a;
        }

        private double minFind(double[] tab)
        {
            double min = tab[0];
            for (int i = 1; i < tab.Length - 1; i++)
            {
                if (tab[i] < min)
                {
                    min = tab[i];

                }
            }
            return min;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelResult.Visible = true;
            buttonReset.Visible = true;
            label14.Visible = true;
            buttonStartTest.Visible = true;

        }

        private void textBoxFun_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
