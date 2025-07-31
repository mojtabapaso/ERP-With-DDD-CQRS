using ERP.Shared.Abstraction.Commmand;

namespace ERP.Application.Features.Commands.Employee.DeleteEmployeeById;

public class DeleteEmployeeByIdCommandHandler : ICommandHandler<DeleteEmployeeByIdCommand>
{
    public Task ExecuteAsync(DeleteEmployeeByIdCommand command)
    {
        throw new NotImplementedException();
    }
}
