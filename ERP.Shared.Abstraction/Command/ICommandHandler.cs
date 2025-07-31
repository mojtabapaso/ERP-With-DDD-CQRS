namespace ERP.Shared.Abstraction.Commmand;



public interface ICommandHandler<in TCommand> where TCommand : class , ICommand
{
    Task ExecuteAsync(TCommand command);
}