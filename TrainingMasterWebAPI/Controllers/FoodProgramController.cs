using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingMasterWebAPI.Queries;

namespace TrainingMasterWebAPI.Controllers
{
    public class FoodProgramController : Controller
    {
        readonly private FoodProgramQueries fpq;
        public FoodProgramController()
        {
            fpq = new FoodProgramQueries();
        }
    }
}