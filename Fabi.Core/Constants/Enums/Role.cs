using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabi.Core.Constants.Enums;
public enum Role
{
    [Description("Admin")]
    Admin = 1,
    [Description("User")]
    User = 2,
    [Description("Customer")]
    Customer = 3,
    [Description("Delivery")]
    Delivery = 3,
    [Description("Finance")]
    Finance = 4,
    [Description("SuperAdmin")]
    SuperAdmin = 4
}