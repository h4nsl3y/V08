using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity
{
    public interface IEnrollment 
    {
        int enrollmentId { get; set; }
        int employeeId { get; set; }
        int trainingId { get; set; }
        int status { get; set; } // 'Rejected','Approved','Waiting_For_Approval',
        DateTime submissionDate { get; set; }
    }
}
