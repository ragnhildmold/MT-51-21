
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
            this.Current = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
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
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.PowerButton = new System.Windows.Forms.CheckBox();
            this.Converter = new System.Windows.Forms.CheckBox();
            this.ConverterModel = new System.Windows.Forms.CheckBox();
            this.status_convmodel = new System.Windows.Forms.Label();
            this.status_converter = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.Clock = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Current
            // 
            this.Current.Location = new System.Drawing.Point(144, 127);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(100, 20);
            this.Current.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Set Point";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(144, 163);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(100, 20);
            this.time.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time ON";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // File
            // 
            this.File.Location = new System.Drawing.Point(90, 31);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(100, 20);
            this.File.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name of File";
            // 
            // DisplayTemperatureModel
            // 
            this.DisplayTemperatureModel.Location = new System.Drawing.Point(106, 89);
            this.DisplayTemperatureModel.Name = "DisplayTemperatureModel";
            this.DisplayTemperatureModel.ReadOnly = true;
            this.DisplayTemperatureModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayTemperatureModel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Temperature";
            // 
            // DisplayFrequencyModel
            // 
            this.DisplayFrequencyModel.Location = new System.Drawing.Point(106, 131);
            this.DisplayFrequencyModel.Name = "DisplayFrequencyModel";
            this.DisplayFrequencyModel.ReadOnly = true;
            this.DisplayFrequencyModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayFrequencyModel.TabIndex = 13;
            // 
            // DisplayCurrentModel
            // 
            this.DisplayCurrentModel.Location = new System.Drawing.Point(106, 171);
            this.DisplayCurrentModel.Name = "DisplayCurrentModel";
            this.DisplayCurrentModel.ReadOnly = true;
            this.DisplayCurrentModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayCurrentModel.TabIndex = 14;
            // 
            // DisplayPowerModel
            // 
            this.DisplayPowerModel.Location = new System.Drawing.Point(106, 210);
            this.DisplayPowerModel.Name = "DisplayPowerModel";
            this.DisplayPowerModel.ReadOnly = true;
            this.DisplayPowerModel.Size = new System.Drawing.Size(100, 20);
            this.DisplayPowerModel.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Current";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Power";
            // 
            // DisplayFrequency
            // 
            this.DisplayFrequency.Location = new System.Drawing.Point(303, 131);
            this.DisplayFrequency.Name = "DisplayFrequency";
            this.DisplayFrequency.ReadOnly = true;
            this.DisplayFrequency.Size = new System.Drawing.Size(100, 20);
            this.DisplayFrequency.TabIndex = 19;
            // 
            // DisplayTemperature
            // 
            this.DisplayTemperature.Location = new System.Drawing.Point(303, 89);
            this.DisplayTemperature.Name = "DisplayTemperature";
            this.DisplayTemperature.ReadOnly = true;
            this.DisplayTemperature.Size = new System.Drawing.Size(100, 20);
            this.DisplayTemperature.TabIndex = 20;
            // 
            // DisplayCurrent
            // 
            this.DisplayCurrent.Location = new System.Drawing.Point(303, 171);
            this.DisplayCurrent.Name = "DisplayCurrent";
            this.DisplayCurrent.ReadOnly = true;
            this.DisplayCurrent.Size = new System.Drawing.Size(100, 20);
            this.DisplayCurrent.TabIndex = 21;
            // 
            // DisplayPower
            // 
            this.DisplayPower.Location = new System.Drawing.Point(303, 209);
            this.DisplayPower.Name = "DisplayPower";
            this.DisplayPower.ReadOnly = true;
            this.DisplayPower.Size = new System.Drawing.Size(100, 20);
            this.DisplayPower.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "Model";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(278, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "Real Application";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "[A]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "[A]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(411, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "[A]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(251, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "[s]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(212, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "[Hz]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(411, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "[Hz]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(212, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "[W]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(411, 215);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "[W]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(212, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "[°C]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(411, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "[°C]";
            // 
            // PowerButton
            // 
            this.PowerButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.PowerButton.AutoSize = true;
            this.PowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PowerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PowerButton.Location = new System.Drawing.Point(69, 266);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(47, 23);
            this.PowerButton.TabIndex = 1;
            this.PowerButton.Text = "Power";
            this.PowerButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PowerButton.UseVisualStyleBackColor = true;
            this.PowerButton.CheckedChanged += new System.EventHandler(this.Power_CheckedChanged);
            // 
            // Converter
            // 
            this.Converter.AutoSize = true;
            this.Converter.Location = new System.Drawing.Point(67, 228);
            this.Converter.Name = "Converter";
            this.Converter.Size = new System.Drawing.Size(72, 17);
            this.Converter.TabIndex = 8;
            this.Converter.Text = "Converter";
            this.Converter.UseVisualStyleBackColor = true;
            // 
            // ConverterModel
            // 
            this.ConverterModel.AutoSize = true;
            this.ConverterModel.Location = new System.Drawing.Point(67, 205);
            this.ConverterModel.Name = "ConverterModel";
            this.ConverterModel.Size = new System.Drawing.Size(104, 17);
            this.ConverterModel.TabIndex = 7;
            this.ConverterModel.Text = "Converter Model";
            this.ConverterModel.UseVisualStyleBackColor = true;
            // 
            // status_convmodel
            // 
            this.status_convmodel.AutoSize = true;
            this.status_convmodel.Location = new System.Drawing.Point(196, 109);
            this.status_convmodel.Name = "status_convmodel";
            this.status_convmodel.Size = new System.Drawing.Size(54, 13);
            this.status_convmodel.TabIndex = 6;
            this.status_convmodel.Text = "Power Off";
            // 
            // status_converter
            // 
            this.status_converter.AutoSize = true;
            this.status_converter.Location = new System.Drawing.Point(196, 135);
            this.status_converter.Name = "status_converter";
            this.status_converter.Size = new System.Drawing.Size(54, 13);
            this.status_converter.TabIndex = 38;
            this.status_converter.Text = "Power Off";
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(254, 292);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 25;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Clock
            // 
            this.Clock.AutoSize = true;
            this.Clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock.Location = new System.Drawing.Point(43, 27);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(42, 16);
            this.Clock.TabIndex = 35;
            this.Clock.Text = "Clock";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 366);
            this.splitter1.TabIndex = 43;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.Current);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.time);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Quit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.PowerButton);
            this.groupBox1.Controls.Add(this.Converter);
            this.groupBox1.Controls.Add(this.ConverterModel);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 337);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.DisplayTemperatureModel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.DisplayFrequencyModel);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.DisplayCurrentModel);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.DisplayPowerModel);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.DisplayFrequency);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.DisplayTemperature);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.DisplayCurrent);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.DisplayPower);
            this.groupBox2.Location = new System.Drawing.Point(389, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 337);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.File);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(29, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 62);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CSV-file ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Clock);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(27, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 69);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.status_convmodel);
            this.groupBox5.Controls.Add(this.status_converter);
            this.groupBox5.Location = new System.Drawing.Point(29, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(316, 234);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Setpoint";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton1.Location = new System.Drawing.Point(176, 109);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButton2.Location = new System.Drawing.Point(176, 135);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(876, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox Current;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox PowerButton;
        private System.Windows.Forms.CheckBox Converter;
        private System.Windows.Forms.CheckBox ConverterModel;
        private System.Windows.Forms.Label status_convmodel;
        private System.Windows.Forms.Label status_converter;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label Clock;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

