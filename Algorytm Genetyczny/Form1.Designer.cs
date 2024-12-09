namespace Algorytm_Genetyczny
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxA = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxB = new TextBox();
            label3 = new Label();
            textBoxN = new TextBox();
            label4 = new Label();
            comboBoxD = new ComboBox();
            buttonStart = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label12 = new Label();
            textBoxFun = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBoxPk = new TextBox();
            textBoxPm = new TextBox();
            label26 = new Label();
            textBoxT = new TextBox();
            checkBoxElita = new CheckBox();
            panelData = new Panel();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label6 = new Label();
            label5 = new Label();
            tableLayoutPanelData = new TableLayoutPanel();
            panelPlot = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            panelTest = new Panel();
            buttonReset = new Button();
            labelResult = new Label();
            label14 = new Label();
            buttonStartTest = new Button();
            progressBar = new ProgressBar();
            buttonDane = new Button();
            buttonPlot = new Button();
            buttonTest = new Button();
            panelData.SuspendLayout();
            panelPlot.SuspendLayout();
            panelTest.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxA
            // 
            textBoxA.Location = new Point(63, 28);
            textBoxA.Margin = new Padding(3, 0, 3, 0);
            textBoxA.Name = "textBoxA";
            textBoxA.Size = new Size(35, 23);
            textBoxA.TabIndex = 0;
            textBoxA.Text = "-4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 30);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 1;
            label1.Text = "a=";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 31);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 3;
            label2.Text = "b=";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // textBoxB
            // 
            textBoxB.Location = new Point(139, 29);
            textBoxB.Margin = new Padding(3, 0, 3, 0);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(35, 23);
            textBoxB.TabIndex = 2;
            textBoxB.Text = "12";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(353, 32);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 5;
            label3.Text = "N=";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(384, 29);
            textBoxN.Margin = new Padding(3, 0, 3, 0);
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(35, 23);
            textBoxN.TabIndex = 4;
            textBoxN.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 31);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 6;
            label4.Text = "d=";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // comboBoxD
            // 
            comboBoxD.FormattingEnabled = true;
            comboBoxD.Items.AddRange(new object[] { "1", "0,1", "0,01", "0,001", "0,0001", "0,00001", "0,000001" });
            comboBoxD.Location = new Point(211, 29);
            comboBoxD.Margin = new Padding(3, 0, 3, 0);
            comboBoxD.Name = "comboBoxD";
            comboBoxD.Size = new Size(122, 23);
            comboBoxD.TabIndex = 7;
            comboBoxD.Text = "0,001";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(1085, 22);
            buttonStart.Margin = new Padding(3, 0, 3, 0);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(119, 39);
            buttonStart.TabIndex = 8;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(512, 31);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 17;
            label12.Text = "f(x)=";
            // 
            // textBoxFun
            // 
            textBoxFun.Location = new Point(553, 30);
            textBoxFun.Margin = new Padding(3, 0, 3, 0);
            textBoxFun.Name = "textBoxFun";
            textBoxFun.Size = new Size(151, 23);
            textBoxFun.TabIndex = 18;
            textBoxFun.Text = "(x%1)*(Cos(20*Pi*x)-Sin(x))";
            textBoxFun.TextChanged += textBoxFun_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(715, 33);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 19;
            label7.Text = "Pk=";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(871, 33);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 20;
            label8.Text = "Pm=";
            // 
            // textBoxPk
            // 
            textBoxPk.Location = new Point(755, 31);
            textBoxPk.Name = "textBoxPk";
            textBoxPk.Size = new Size(101, 23);
            textBoxPk.TabIndex = 21;
            textBoxPk.Text = "0,4";
            // 
            // textBoxPm
            // 
            textBoxPm.Location = new Point(911, 31);
            textBoxPm.Name = "textBoxPm";
            textBoxPm.Size = new Size(101, 23);
            textBoxPm.TabIndex = 22;
            textBoxPm.Text = "0,1";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(433, 31);
            label26.Name = "label26";
            label26.Size = new Size(21, 15);
            label26.TabIndex = 39;
            label26.Text = "T=";
            label26.TextAlign = ContentAlignment.TopRight;
            // 
            // textBoxT
            // 
            textBoxT.Location = new Point(462, 29);
            textBoxT.Margin = new Padding(3, 0, 3, 0);
            textBoxT.Name = "textBoxT";
            textBoxT.Size = new Size(35, 23);
            textBoxT.TabIndex = 40;
            textBoxT.Text = "10";
            // 
            // checkBoxElita
            // 
            checkBoxElita.AutoSize = true;
            checkBoxElita.Location = new Point(1028, 33);
            checkBoxElita.Margin = new Padding(3, 2, 3, 2);
            checkBoxElita.Name = "checkBoxElita";
            checkBoxElita.Size = new Size(48, 19);
            checkBoxElita.TabIndex = 41;
            checkBoxElita.Text = "elita";
            checkBoxElita.UseVisualStyleBackColor = true;
            // 
            // panelData
            // 
            panelData.Controls.Add(label11);
            panelData.Controls.Add(label10);
            panelData.Controls.Add(label9);
            panelData.Controls.Add(label6);
            panelData.Controls.Add(label5);
            panelData.Controls.Add(tableLayoutPanelData);
            panelData.Location = new Point(32, 94);
            panelData.Margin = new Padding(3, 2, 3, 2);
            panelData.Name = "panelData";
            panelData.Size = new Size(1172, 424);
            panelData.TabIndex = 42;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(706, 11);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 5;
            label11.Text = "%";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(597, 11);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(25, 15);
            label10.TabIndex = 4;
            label10.Text = "f(x)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(480, 11);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 3;
            label9.Text = "Xbin";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(367, 11);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 2;
            label6.Text = "Xreal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(263, 11);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 1;
            label5.Text = "Lp";
            // 
            // tableLayoutPanelData
            // 
            tableLayoutPanelData.AutoScroll = true;
            tableLayoutPanelData.BackColor = SystemColors.Window;
            tableLayoutPanelData.ColumnCount = 5;
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.Location = new Point(217, 28);
            tableLayoutPanelData.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.Size = new Size(563, 327);
            tableLayoutPanelData.TabIndex = 0;
            // 
            // panelPlot
            // 
            panelPlot.Controls.Add(formsPlot1);
            panelPlot.Location = new Point(32, 91);
            panelPlot.Margin = new Padding(3, 2, 3, 2);
            panelPlot.Name = "panelPlot";
            panelPlot.Size = new Size(1172, 427);
            panelPlot.TabIndex = 43;
            panelPlot.Visible = false;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(73, 28);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(907, 370);
            formsPlot1.TabIndex = 0;
            // 
            // panelTest
            // 
            panelTest.Controls.Add(buttonReset);
            panelTest.Controls.Add(labelResult);
            panelTest.Controls.Add(label14);
            panelTest.Controls.Add(buttonStartTest);
            panelTest.Controls.Add(progressBar);
            panelTest.Location = new Point(29, 89);
            panelTest.Margin = new Padding(3, 2, 3, 2);
            panelTest.Name = "panelTest";
            panelTest.Size = new Size(1172, 427);
            panelTest.TabIndex = 44;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(501, 232);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 6;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Visible = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(287, 187);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(44, 15);
            labelResult.TabIndex = 5;
            labelResult.Text = "label15";
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            labelResult.Visible = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(500, 160);
            label14.Name = "label14";
            label14.Size = new Size(95, 15);
            label14.TabIndex = 4;
            label14.Text = "Test zakończony!";
            label14.Visible = false;
            // 
            // buttonStartTest
            // 
            buttonStartTest.Location = new Point(480, 176);
            buttonStartTest.Name = "buttonStartTest";
            buttonStartTest.Size = new Size(159, 36);
            buttonStartTest.TabIndex = 0;
            buttonStartTest.Text = "Start test";
            buttonStartTest.UseVisualStyleBackColor = true;
            buttonStartTest.Click += buttonStartTest_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(287, 178);
            progressBar.Maximum = 1760;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(553, 34);
            progressBar.Step = 1;
            progressBar.TabIndex = 1;
            progressBar.Visible = false;
            // 
            // buttonDane
            // 
            buttonDane.Enabled = false;
            buttonDane.Location = new Point(36, 68);
            buttonDane.Margin = new Padding(3, 2, 3, 2);
            buttonDane.Name = "buttonDane";
            buttonDane.Size = new Size(83, 22);
            buttonDane.TabIndex = 43;
            buttonDane.Text = "Dane";
            buttonDane.UseVisualStyleBackColor = true;
            buttonDane.Click += buttonDane_Click;
            // 
            // buttonPlot
            // 
            buttonPlot.Location = new Point(125, 67);
            buttonPlot.Name = "buttonPlot";
            buttonPlot.Size = new Size(75, 23);
            buttonPlot.TabIndex = 44;
            buttonPlot.Text = "Wykres";
            buttonPlot.UseVisualStyleBackColor = true;
            buttonPlot.Click += buttonGraph_Click;
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(206, 67);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(83, 22);
            buttonTest.TabIndex = 45;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += buttonTest_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 547);
            Controls.Add(panelTest);
            Controls.Add(buttonTest);
            Controls.Add(panelPlot);
            Controls.Add(buttonPlot);
            Controls.Add(buttonDane);
            Controls.Add(panelData);
            Controls.Add(checkBoxElita);
            Controls.Add(textBoxT);
            Controls.Add(label26);
            Controls.Add(textBoxPm);
            Controls.Add(textBoxPk);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxFun);
            Controls.Add(label12);
            Controls.Add(buttonStart);
            Controls.Add(comboBoxD);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxN);
            Controls.Add(label2);
            Controls.Add(textBoxB);
            Controls.Add(label1);
            Controls.Add(textBoxA);
            Margin = new Padding(3, 0, 3, 0);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Algorytm Genetyczny";
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            panelPlot.ResumeLayout(false);
            panelTest.ResumeLayout(false);
            panelTest.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxA;
        private Label label1;
        private Label label2;
        private TextBox textBoxB;
        private Label label3;
        private TextBox textBoxN;
        private Label label4;
        private ComboBox comboBoxD;
        private Button buttonStart;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label12;
        private TextBox textBoxFun;
        private Label label7;
        private Label label8;
        private TextBox textBoxPk;
        private TextBox textBoxPm;
        private Label label26;
        private TextBox textBoxT;
        private CheckBox checkBoxElita;
        private Panel panelData;
        private Button buttonDane;
        private TableLayoutPanel tableLayoutPanelData;
        private Label label5;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label6;
        private Panel panelPlot;
        private Button buttonPlot;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Button buttonTest;
        private Panel panelTest;
        private Button buttonStartTest;
        private ProgressBar progressBar;
        private Button buttonReset;
        private Label labelResult;
        private Label label14;
    }
}
