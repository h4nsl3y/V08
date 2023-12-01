using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity
{
    public class Training : ITraining
    {
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string Prerequisite { get; set; }
        public int SeatNumber { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
