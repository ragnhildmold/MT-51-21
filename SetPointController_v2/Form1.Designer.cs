
namespace SetPointController_v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PowerButton = new System.Windows.Forms.CheckBox();
            this.Current = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.status_convmodel = new System.Windows.Forms.Label();
            this.ConverterModel = new System.Windows.Forms.CheckBox();
            this.Converter = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.File = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayTemperatureModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DisplayFrequencyModel = new System.Windows.Forms.TextBox();
            this.DisplayCurrentModel = new System.Windows.Forms.TextBox();
            this.DisplayPowerModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DisplayFrequency = new System.Windows.Forms.TextBox();
            this.DisplayTemperature = new System.Windows.Forms.TextBox();
            this.DisplayCurrent = new System.Windows.Forms.TextBox();
            this.DisplayPower = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Clock = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.status_converter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.PowerButton.AutoSize = true;
            this.PowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PowerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PowerButton.Location = new System.Drawing.Point(128, 337);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(47, 23);
            this.PowerButton.TabIndex = 1;
            this.PowerButton.Text = "Power";
            this.PowerButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PowerButton.UseVisualStyleBackColor = true;
            this.PowerButton.CheckedChanged += new System.EventHandler(this.Power_CheckedChanged);
            // 
            // Current
            // 
            this.Current.Location = new System.Drawing.Point(130, 207);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(100, 20);
            this.Current.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Set Point";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(130, 243);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(100, 20);
            this.time.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time ON";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // status_convmodel
            // 
            this.status_convmodel.AutoSize = true;
            this.status_convmodel.Location = new System.Drawing.Point(274, 283);
            this.status_convmodel.Name = "status_convmodel";
            this.status_convmodel.Size = new System.Drawing.Size(90, 13);
            this.status_convmodel.TabIndex = 6;
            this.status_convmodel.Text = "Status: Power Off";
            // 
            // ConverterModel
            // 
            this.ConverterModel.AutoSize = true;
            this.ConverterModel.Location = new System.Drawing.Point(130, 282);
            this.ConverterModel.Name = "ConverterModel";
            this.ConverterModel.Size = new System.Drawing.Size(104, 17);
            this.ConverterModel.TabIndex = 7;
            this.ConverterModel.Text = "Converter Model";
            this.ConverterModel.UseVisualStyleBackColor = true;
            // 
            // Converter
            // 
            this.Converter.AutoSize = true;
            this.Converter.Location = new System.Drawing.Point(130, 306);
            this.Converter.Name = "Converter";
            this.Converter.Size = new System.Drawing.Size(72, 17);
            this.Converter.TabIndex = 8;
            this.Converter.Text = "Converter";
            this.Converter.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // File
            // 
            this.File.Location = new System.Drawing.Point(130, 168);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(100, 20);
            this.File.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name of File";
            // 
            // DisplayTemperatureModel
            // 
            this.DisplayTemperatureModel.Location = new System.Drawing.Point(442, 84);
            this.DisplayTemperatureModel.Name = "DisplayTemperatureModel";
            this.DisplayTemperatureModel.ReadOnly = true;
            this.DisplayTemperatureModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayTemperatureModel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Temperature";
            // 
            // DisplayFrequencyModel
            // 
            this.DisplayFrequencyModel.Location = new System.Drawing.Point(490, 482);
            this.DisplayFrequencyModel.Name = "DisplayFrequencyModel";
            this.DisplayFrequencyModel.ReadOnly = true;
            this.DisplayFrequencyModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayFrequencyModel.TabIndex = 13;
            // 
            // DisplayCurrentModel
            // 
            this.DisplayCurrentModel.Location = new System.Drawing.Point(490, 522);
            this.DisplayCurrentModel.Name = "DisplayCurrentModel";
            this.DisplayCurrentModel.ReadOnly = true;
            this.DisplayCurrentModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayCurrentModel.TabIndex = 14;
            // 
            // DisplayPowerModel
            // 
            this.DisplayPowerModel.Location = new System.Drawing.Point(490, 561);
            this.DisplayPowerModel.Name = "DisplayPowerModel";
            this.DisplayPowerModel.ReadOnly = true;
            this.DisplayPowerModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayPowerModel.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Current";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 564);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Power";
            // 
            // DisplayFrequency
            // 
            this.DisplayFrequency.Location = new System.Drawing.Point(667, 482);
            this.DisplayFrequency.Name = "DisplayFrequency";
            this.DisplayFrequency.ReadOnly = true;
            this.DisplayFrequency.Size = new System.Drawing.Size(100, 20);
            this.DisplayFrequency.TabIndex = 19;
            // 
            // DisplayTemperature
            // 
            this.DisplayTemperature.Location = new System.Drawing.Point(641, 84);
            this.DisplayTemperature.Name = "DisplayTemperature";
            this.DisplayTemperature.ReadOnly = true;
            this.DisplayTemperature.Size = new System.Drawing.Size(100, 20);
            this.DisplayTemperature.TabIndex = 20;
            // 
            // DisplayCurrent
            // 
            this.DisplayCurrent.Location = new System.Drawing.Point(667, 522);
            this.DisplayCurrent.Name = "DisplayCurrent";
            this.DisplayCurrent.ReadOnly = true;
            this.DisplayCurrent.Size = new System.Drawing.Size(100, 20);
            this.DisplayCurrent.TabIndex = 21;
            // 
            // DisplayPower
            // 
            this.DisplayPower.Location = new System.Drawing.Point(667, 563);
            this.DisplayPower.Name = "DisplayPower";
            this.DisplayPower.ReadOnly = true;
            this.DisplayPower.Size = new System.Drawing.Size(100, 20);
            this.DisplayPower.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(456, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Model";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(651, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Real";
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(128, 398);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 25;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "[A]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(596, 525);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "[A]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(775, 525);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "[A]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(237, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "[s]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(596, 485);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "[Hz]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(775, 485);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "[Hz]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(596, 566);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "[W]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(775, 564);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "[W]";
            // 
            // Clock
            // 
            this.Clock.AutoSize = true;
            this.Clock.Location = new System.Drawing.Point(37, 403);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(34, 13);
            this.Clock.TabIndex = 35;
            this.Clock.Text = "Clock";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(37, 379);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "Time:";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(467, 168);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 37;
            this.chart1.Text = "chart1";
            // 
            // status_converter
            // 
            this.status_converter.AutoSize = true;
            this.status_converter.Location = new System.Drawing.Point(274, 306);
            this.status_converter.Name = "status_converter";
            this.status_converter.Size = new System.Drawing.Size(90, 13);
            this.status_converter.TabIndex = 38;
            this.status_converter.Text = "Status: Power Off";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(821, 612);
            this.Controls.Add(this.status_converter);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Clock);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DisplayPower);
            this.Controls.Add(this.DisplayCurrent);
            this.Controls.Add(this.DisplayTemperature);
            this.Controls.Add(this.DisplayFrequency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DisplayPowerModel);
            this.Controls.Add(this.DisplayCurrentModel);
            this.Controls.Add(this.DisplayFrequencyModel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DisplayTemperatureModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.File);
            this.Controls.Add(this.Converter);
            this.Controls.Add(this.ConverterModel);
            this.Controls.Add(this.status_convmodel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.PowerButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PowerButton;
        private System.Windows.Forms.TextBox Current;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label status_convmodel;
        private System.Windows.Forms.CheckBox ConverterModel;
        private System.Windows.Forms.CheckBox Converter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox File;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DisplayTemperatureModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DisplayFrequencyModel;
        private System.Windows.Forms.TextBox DisplayCurrentModel;
        private System.Windows.Forms.TextBox DisplayPowerModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DisplayFrequency;
        private System.Windows.Forms.TextBox DisplayTemperature;
        private System.Windows.Forms.TextBox DisplayCurrent;
        private System.Windows.Forms.TextBox DisplayPower;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label Clock;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label status_converter;
    }
}

