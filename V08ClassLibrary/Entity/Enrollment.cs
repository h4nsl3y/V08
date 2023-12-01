﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity

{
    public class Enrollment : IEnrollment
    {
        public int EnrollmentId { get; set; }
        public int EmployeeId { get; set; }
        public int TrainingId { get; set; }
        public int Status { get; set; } 
        public DateTime SubmissionDate { get; set; }
    }
}
