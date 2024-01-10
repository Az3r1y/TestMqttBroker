using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using TestMqttBroker.Services;

namespace TestMqttBroker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dao_mqtt dao_Mqtt;
       


        public MainWindow()
        {
            InitializeComponent();
            dao_Mqtt = new dao_mqtt();


            Task.Run(async () => await dao_Mqtt.Connect()).Wait();
            dao_Mqtt.Subscribe("topic/test");

        }
    }
}


