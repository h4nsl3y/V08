using BusinessLogic.Services.TrainingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V08ClassLibrary.Custom;
using V08ClassLibrary.Enum;
using V08DataAccessLayer.Entity;

namespace V08.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        [HttpGet]
        public ActionResult GetTrainingList()
        {
            return Json(_trainingService.GetAll(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetTraining(int id)
        {
            return Json(_trainingService.Get(id), JsonRequestBehavior.AllowGet);
        }
    }
}