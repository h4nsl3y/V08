using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity
{
    public interface IAccount
    {
        int EmployeeId { get; set; }
        string FirstName { get; set; }
        string OtherName { get; set; }
        string LastName { get; set; }
        string Nic { get; set; }
        int MobileNumber { get; set; }
        string Email { get; set; }

        int? DepartmentId { get; set; }
        int? ManagerId { get; set; }
        string Password { get; set; }
        int RoleId { get; set; }
    }
}
