using ERP.Domain.ValueObjects;
using ERP.Shared.Abstraction.Commmand;

namespace ERP.Application.Features.Commands.Employee.DeleteEmployeeById;

public record DeleteEmployeeByIdCommand(BaseId id) : ICommand;
