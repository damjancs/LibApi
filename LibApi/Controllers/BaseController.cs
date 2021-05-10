using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Controllers
{
    public abstract class BaseController : Controller
    {
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First(u => u.Type == "user.Id").Value);
        }
    }
}
