using CleanArchit.Domain.Core.Commands;


namespace CleanArchit.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        public Task SendCommand<T>(T command) where T : Command;
    }
}
