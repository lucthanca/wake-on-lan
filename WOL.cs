using System.Globalization;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace WOL
{
    internal class WOL: UdpClient
    {
        private string? _macAddress;

        public string? MacAddress {
            set { _macAddress = value; }
            get { return _macAddress; }
        }
        public void SetClientToBrodcastMode()
        {
            if (Active)
            {
                Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
            }
        }


        private byte[] CreateMagicPacket()
        {
            if (_macAddress == null) throw new ArgumentNullException("MAC Address must not null!");

            //set sending bites
            int counter = 0;
            //buffer to be send
            byte[] bytes = new byte[1024];

            //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;

            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(_macAddress.Substring(i, 2), NumberStyles.HexNumber);
                    i += 2;
                }
            }

            return bytes;
        }

        public void SendMagicPacket()
        {
            byte[] bytes = CreateMagicPacket();
            Send(bytes, 1024);
        }
    }
}
