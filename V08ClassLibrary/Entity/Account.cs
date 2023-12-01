using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity
{
    public class Account : IAccount
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Nic { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }

        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

    }
}
