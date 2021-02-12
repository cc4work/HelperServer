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
        IServerController AttachScript(Type type);
        IServerController AttachAccount(string v);
        IServerController AttachImageInfos(string v);
        void Run();
        IServerController BuildServer();
        void Stop();
        IHelperClient GetClient(IDevice device);
        void GetClientDetail();
    }
}
