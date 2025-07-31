using ERP.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Exceptions.EmployeeManagmentExceptions
{
    internal class CompanyEmployeeNullException : EmployeeManagmentException
    {
        public CompanyEmployeeNullException() : base("Comany emloy is null ")
        {
        }
    }
}
