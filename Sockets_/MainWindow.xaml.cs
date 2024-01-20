using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Sockets_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string index1 = "115547", index2 = "121170", index3 = "125009";
        public static string[] indexes = { index1, index2, index3 };
        public static int amount_of_streets_of_first_ind = 5, amount_of_streets_of_sec_ind = 9, amount_of_streets_of_third_ind = 16;
        public static int[] street_amounts = { amount_of_streets_of_first_ind, amount_of_streets_of_sec_ind, amount_of_streets_of_third_ind };
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (Socket socket = new Socket(SocketType.Stream, ProtocolType.IP))
            {
                string serv_name = "192.168.1.130";
                int port = int.Parse("2019");
                IPEndPoint point = new IPEndPoint(Dns.GetHostAddresses(serv_name).Where(addr => addr.AddressFamily == AddressFamily.InterNetwork).First(), port);
                socket.Connect(point);
                byte[] response = new byte[1024];
                if (box.Text == indexes[0]) Streets.Select(amount_of_streets_of_first_ind, 0, amount_of_streets_of_first_ind + amount_of_streets_of_sec_ind + amount_of_streets_of_third_ind,
                    response, list_box, socket);
                else if (box.Text == indexes[1]) Streets.Select(amount_of_streets_of_sec_ind, amount_of_streets_of_first_ind, amount_of_streets_of_first_ind + amount_of_streets_of_sec_ind + amount_of_streets_of_third_ind,
                    response, list_box, socket);
                else if (box.Text == indexes[2]) Streets.Select(amount_of_streets_of_third_ind, amount_of_streets_of_first_ind + amount_of_streets_of_sec_ind, amount_of_streets_of_first_ind + amount_of_streets_of_sec_ind + amount_of_streets_of_third_ind,
                    response, list_box, socket);
            }
        }
    }
}