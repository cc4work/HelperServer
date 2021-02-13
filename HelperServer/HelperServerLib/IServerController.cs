using HelperShareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperServerLib
{
    public interface IServerController
    {
        IServerController WithScript(Type type);
        IServerController WithAccount(string v);
        IServerController WithImageInfos(string v);
        void Run();
        IServerController BuildServer();
        void Stop();
        IHelperClient GetClient(IDevice device);
        void GetClientDetail();
        IServerController WithCommands(string v);
    }
}
