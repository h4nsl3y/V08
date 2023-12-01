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
        int EnrollmentId { get; set; }
        int EmployeeId { get; set; }
        int TrainingId { get; set; }
        int Status { get; set; } 
        DateTime SubmissionDate { get; set; }
    }
}
