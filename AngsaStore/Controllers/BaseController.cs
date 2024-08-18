using AngsaStore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngsaStore.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationContext db = new ApplicationContext();
    }
}