﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.Messages
{
    public static class MessengerHelper
    {
        public static event Action<ReloadDataMessage> ReloadDataRequested;
        public static void SendReloadDataMessage()
        {
            ReloadDataRequested?.Invoke(new ReloadDataMessage());
        }
    }
}
