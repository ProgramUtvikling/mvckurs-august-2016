﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        // GET: Admin/Movie
        public ActionResult Index()
        {
            return Content("Admin area: MovieController.Index()");
        }
    }
}