using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            string BrokerAddress = "172.19.2.81";

            client = new MqttClient(BrokerAddress);

            // a unique clientID for each time the application start
            clientId = Guid.NewGuid().ToString();

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.Connect(clientId);
            status.Text = "Status: Power Off";
            timer.Enabled = false;
            string Topic_power = "setpoint/power";
            string Topic_current = "setpoint/current";
            string Power = Convert.ToString(0);
            string Current = Convert.ToString(0);

            client.Publish(Topic_power, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            client.Subscribe(new string[] { "appmodel/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "real/temp" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "convmodel/frequency" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "converter/frequency" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "convmodel/currentcoil" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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
                status.Text = "Status: Power On";
                timer.Enabled = true;
                //timer.Interval = 1000; // 1 second
                timer.Tick += new EventHandler(timer_Tick);


            }
            else
            {
                status.Text = "Status: Power Off";
                timer.Enabled = false;
                timer1.Enabled = false;
                string Topic_power_convmodel = "setpoint/power/convmodel";
                string Topic_power_converter = "setpoint/power/converter";
                string Topic_current = "setpoint/current";
                string Power = Convert.ToString(0);
                string Current = Convert.ToString(0);

                client.Publish(Topic_power_convmodel, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_power_converter, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            }


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ConverterModel.Checked)
            {
                status.Text = "Status: Power On";
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

            if (Converter.Checked)
            {
                status.Text = "Status: Power On";
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



        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            status.Text = "Status: Power Off";
            string Topic_power_convmodel = "setpoint/power/convmodel";
            string Topic_power_converter = "setpoint/power/converter";
            string Topic_current = "setpoint/current";
            string Power = Convert.ToString(0);
            string Current = Convert.ToString(0);

            client.Publish(Topic_power_convmodel, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_power_converter, Encoding.UTF8.GetBytes(Power), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            client.Publish(Topic_current, Encoding.UTF8.GetBytes(Current), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            timer1.Enabled = false;
            //timer.Enabled = true;
        }
 
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    timer2.Enabled = true;
        //    timer2.Interval = 1000;
        //    timer2.Tick += new EventHandler(timer2_Tick);
            
        //}
        private void timer2_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("hh::mm:ss");

        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
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
                if (e.Topic == "convmodel/currentcoil")

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

        }
    }
}
