using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public string CreateImage(string fmt, string id)
        {
			return $"ImageController.CreateImage({fmt}, {id})";
        }
    }
}