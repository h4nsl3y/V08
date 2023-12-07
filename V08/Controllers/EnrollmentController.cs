using BusinessLogic.Services.EnrollmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using V08DataAccessLayer.Entity;

namespace V08.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpPost]
        public ActionResult RegisterEnrollment(int id)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.TrainingId=id;
            enrollment.EmployeeId = (Session["Account"] as Account).EmployeeId;
            enrollment.SubmissionDate = DateTime.Now;
            if (_enrollmentService.Add(enrollment))
            {
                return Json(new { message = "success" });
            }
            else
            {
                return Json(new { message = "Failed" });
            }
        }
    }
}