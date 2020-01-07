using CRUDOperationWebAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperationWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public async Task<object> GetUsersList()
        {
            object response = await APIService.Get<object>("api/crud/GetUsersList");
            return response;
        }
    }
}