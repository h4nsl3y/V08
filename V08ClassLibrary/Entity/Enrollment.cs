using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity

{
    public class Enrollment : IEnrollment
    {
        public int enrollmentId { get; set; }
        public int employeeId { get; set; }
        public int trainingId { get; set; }
        public int status { get; set; } // 'Rejected','Approved','Waiting_For_Approval',
        public DateTime submissionDate { get; set; }
    }
}
