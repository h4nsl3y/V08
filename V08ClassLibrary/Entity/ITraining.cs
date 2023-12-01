using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V08ClassLibrary.Entity
{
    public interface ITraining
    {
        int TrainingId { get; set; }
        string Title { get; set; }
        int DepartmentId { get; set; }
        string Prerequisite { get; set; }
        int SeatNumber { get; set; }
        DateTime Deadline { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
    }
}
