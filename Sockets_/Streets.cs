using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sockets_
{
    internal class Streets
    {
        public static List<string> ind_streets = new List<string>();
        public static void Select(int length, int start, int full_length,
            byte[] response, ListBox list_box, Socket socket)
        {
            for (int i = 0; i < full_length; i++)
            {
                int count = socket.Receive(response);
                ind_streets.Add(Encoding.Default.GetString(response, 0, count));
            }
            for (int i = start; i < start + length; i++) list_box.Items.Add(ind_streets[i]);
        }
    }
}