using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWithSQLLite.Data {
    public interface INetworkConnection {
        bool IsConnected { get; }
        void checkNetworConnection();
    }
}
