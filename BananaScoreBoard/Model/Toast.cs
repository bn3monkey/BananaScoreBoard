using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model
{
    class Toast
    {
        public delegate void SendCallback(string value);
        SendCallback callback = null;

        public void RegisterSendCallback(SendCallback callback)
        {
            this.callback = callback;
        }

        public void SendMessage(string value)
        {
            if (this.callback != null)
            {
                callback.Invoke(value);
            }
        }

        public void SendMessage(string value, params object[] args)
        {
            string new_value = string.Format(value, args);
            SendMessage(new_value);
        }
    }
}
