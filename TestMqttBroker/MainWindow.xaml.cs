using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MQTTnet;
using MQTTnet.Client;
using TestMqttBroker.Services;

namespace TestMqttBroker
{
    public partial class MainWindow : Window
    {
        private dao_mqtt dao_Mqtt;
        private ObservableCollection<string> mqttMessages = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            dao_Mqtt = new dao_mqtt();
            Task.Run(async () => await dao_Mqtt.Connect()).Wait();
            dao_Mqtt.Subscribe("smartdisplay/sound");
            dao_Mqtt.MessageReceived += OnMqttMessageReceived;
            mqttDataGrid.ItemsSource = mqttMessages;
        }

        private void OnMqttMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            string message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Dispatcher.Invoke(() =>
            {
                mqttMessages.Add(message);
            });
        }
    }
}
