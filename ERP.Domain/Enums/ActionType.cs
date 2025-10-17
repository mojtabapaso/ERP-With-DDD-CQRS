using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Enums;

public enum ActionType : byte
{
    NONE = 0,
    INSERT = 1,
    UPDATE = 2,
    DELETE = 3
}
