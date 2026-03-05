using ERP.Application.Message;
using ERP.Domain.Repository.EmployeeManagment;
using MassTransit;
using System;
using System.ComponentModel;

namespace ERP.Application.EventHandler;

//public class HireEmployeeEventHandler : IConsumer<HireEmployeeMessage>
//{
//    public Task Consume(ConsumeContext<HireEmployeeMessage> context)
//    {
//        throw new NotImplementedException();
//    }
//}

//IPublishEndpoint
//public class HireEmployeeEventHandler : IObserver<HireEmployeeMessage>
//{
//    public void OnCompleted()
//    {
//        throw new NotImplementedException();
//    }

//    public void OnError(Exception error)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnNext(HireEmployeeMessage value)
//    {
//        throw new NotImplementedException();
//    }
//}


//public class HireEmployeeConsumer : IConsumer<HireEmployeeMessage>
//{
//    private readonly IEmployeeWriteRepository employeeWriteRepository;

//    public HireEmployeeConsumer(IEmployeeWriteRepository employeeWriteRepository, IMongoDatabase)
//    {
//        this.employeeWriteRepository = employeeWriteRepository;
//    }
//    public async Task Consume(ConsumeContext<HireEmployeeMessage> context)
//    {
//        HireEmployeeMessage hireEmployeeMessage = context.Message;
//        var employee = await employeeWriteRepository.GetByIdAsync(hireEmployeeMessage.EmployeeId);
//        ;
//    }
//}
