using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Enums;

public enum EmployeePosition
{
    None = 0,

    CEO = 1,
    CTO = 2,
    CFO = 3,
    COO = 4,

    HRManager = 10,
    FinanceManager = 11,
    SalesManager = 12,
    ITManager = 13,
    WarehouseManager = 14,

    HRStaff = 20,
    Accountant = 21,
    SalesRepresentative = 22,
    Developer = 23,
    SystemAdministrator = 24,
    WarehouseWorker = 25,

    ProjectManager = 30,
    ProductOwner = 31,
    TeamLead = 32,
    Intern = 33
}

