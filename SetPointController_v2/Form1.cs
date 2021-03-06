using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SetPointController_v2
{
    public partial class Form1 : Form
    {
        MqttClient client;
        string clientId;
        public Form1()
        {
            InitializeComponent();

            //string BrokerAddress = "";
            //Broker.Text = BrokerAddress;

            //string BrokerAddress = "192.168.10.129";
            string BrokerAddress = "localhost";


            client = new MqttClient(BrokerAddress);

            // a unique clientID for each time the application start
            clientId = Guid.NewGuid().ToString();

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.Connect(clientId);
            status_convmodel.Text = "Power Off";
            status_converter.Text = "Power Off";
            timer.Enabled = false;
            string Topic_power = "setpoint/power";
            string Topic_current = "setpoint/current";
            string Power = Convert.ToString(0);
            string Current = Convert.ToString(0);

            client.Publish(Topic_power, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            client.Subscribe(new string[] { "appmodel/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "appmodel/temparray" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "real/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "convmodel/frequency" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "converter/frequency" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "convmodel/current" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "converter/current" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "convmodel/power" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "converter/power" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);

            



        }

        private void Power_CheckedChanged(object sender, EventArgs e)
        {

            if (PowerButton.Checked)
            {
                //status_convmodel.Text = "Status: Power On";
                timer.Enabled = true;
                //timer.Interval = 10000; // 1 second
                timer.Tick += new EventHandler(timer_Tick);


            }
            else
            {
                status_convmodel.Text = "Power Off";
                status_converter.Text = "Power Off";
                radioButton1.BackColor = Color.Red;
                radioButton2.BackColor = Color.Red;
                timer.Enabled = false;
                timer1.Enabled = false;
                string Topic_power_convmodel = "setpoint/power/convmodel";
                string Topic_power_converter = "setpoint/power/converter";
                string Topic_frequency_convmodel = "convmodel/frequency";
                string Topic_current = "setpoint/current";
                string Power = Convert.ToString(0);
                string Current = Convert.ToString(0);
                string Frequency = Convert.ToString(0);

                client.Publish(Topic_power_convmodel, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_power_converter, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_frequency_convmodel, Encoding.UTF8.GetBytes(Frequency), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            }

            if (File.Text != "")
            {
                string Topic_file = "setpoint/file";
                string Topic_report = "setpoint/report";
                string Report = Convert.ToString(1);
                client.Publish(Topic_file, Encoding.UTF8.GetBytes(File.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_report, Encoding.UTF8.GetBytes(Report), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }


        }

   

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ConverterModel.Checked)
            {
                status_convmodel.Text = "Power On";
                radioButton1.BackColor = Color.Green;
                radioButton1.ForeColor = Color.Green;
                string Topic_power = "setpoint/power/convmodel";
                string Topic_current = "setpoint/current";
                string Power = Convert.ToString(1);
                client.Publish(Topic_power, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

                timer.Enabled = false;
                timer1.Enabled = true;
                timer1.Interval = Convert.ToInt32(time.Text) * 1000; // in seconds
                timer1.Tick += new EventHandler(timer1_Tick);
            }
            else
            {
                status_convmodel.Text = "Power Off";
                radioButton1.BackColor = Color.Red;
                radioButton1.ForeColor = Color.Red;
            }

            if (Converter.Checked)
            {
                status_converter.Text = "Power On";
                radioButton2.BackColor = Color.Green;
                radioButton2.ForeColor = Color.Green;
                string Topic_power = "setpoint/power/converter";
                string Topic_current = "setpoint/current";
                string Power = Convert.ToString(1);
                client.Publish(Topic_power, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
                client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current.Text), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);


                timer.Enabled = false;
                timer1.Enabled = true;
                timer1.Interval = Convert.ToInt32(time.Text) * 1000; // in seconds
                timer1.Tick += new EventHandler(timer1_Tick);
            }
            else
            {
                status_converter.Text = "Power Off";
                radioButton2.BackColor = Color.Red;
                radioButton2.ForeColor = Color.Red;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            status_convmodel.Text = "Power Off";
            status_converter.Text = "Power Off";
            radioButton1.BackColor = Color.Red;
            radioButton1.ForeColor = Color.Red;
            radioButton2.BackColor = Color.Red;
            radioButton2.ForeColor = Color.Red;
            string Topic_power_convmodel = "setpoint/power/convmodel";
            string Topic_power_converter = "setpoint/power/converter";
            string Topic_frequency_convmodel = "convmodel/frequency";
            string Topic_current = "setpoint/current";
            string Power = Convert.ToString(0);
            string Current = Convert.ToString(0);
            string Frequency = Convert.ToString(0);

            client.Publish(Topic_power_convmodel, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_power_converter, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_frequency_convmodel, Encoding.UTF8.GetBytes(Frequency), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            timer1.Enabled = false;
            //timer.Enabled = true;//
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("hh:mm:ss");

        }


        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (this.InvokeRequired)
            {
                if (e.Topic == "appmodel/temp")
                {

                    this.Invoke(new Action(() => this.DisplayTemperatureModel.Text = Encoding.UTF8.GetString(e.Message)));

                }
               
                if (e.Topic == "real/temp")
                {

                    this.Invoke(new Action(() => this.DisplayTemperature.Text = Encoding.UTF8.GetString(e.Message)));

                }

                if (e.Topic == "convmodel/frequency")

                {

                    this.Invoke(new Action(() => this.DisplayFrequencyModel.Text = Encoding.UTF8.GetString(e.Message)));

                }
                if (e.Topic == "converter/frequency")

                {

                    this.Invoke(new Action(() => this.DisplayFrequency.Text = Encoding.UTF8.GetString(e.Message)));

                }
                if (e.Topic == "convmodel/current")

                {

                    this.Invoke(new Action(() => this.DisplayCurrentModel.Text = Encoding.UTF8.GetString(e.Message)));

                }
                if (e.Topic == "converter/current")

                {

                    this.Invoke(new Action(() => this.DisplayCurrent.Text = Encoding.UTF8.GetString(e.Message)));

                }
                if (e.Topic == "convmodel/power")

                {

                    this.Invoke(new Action(() => this.DisplayPowerModel.Text = Encoding.UTF8.GetString(e.Message)));

                }
                if (e.Topic == "converter/power")

                {

                    this.Invoke(new Action(() => this.DisplayPower.Text = Encoding.UTF8.GetString(e.Message)));

                }
                
            }
        }



        private void Quit_Click(object sender, EventArgs e)
        {
            string Topic_MQTT = "setpoint/mqtt";
            string MQTT = Convert.ToString(0);
            client.Publish(Topic_MQTT, Encoding.UTF8.GetBytes(MQTT), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            string Topic_report = "setpoint/report";
            string Report = Convert.ToString(0);
            client.Publish(Topic_report, Encoding.UTF8.GetBytes(Report), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            System.Windows.Forms.Application.Exit();
        }
    }
}
