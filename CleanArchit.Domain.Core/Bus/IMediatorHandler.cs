using CleanArchit.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        public Task SendCommand<T>(T command) where T : Command;
    }
}
