using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Video_Conference.Interfaces
{
    public interface ISIPHandle
    {
        public Task SIPInitialization();
    }
}
