using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Writer p)
		{
			Context c = new Context();
			var dataValue = c.Writers.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
			if (dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.Mail),

				};
				var userIdentity=new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				
				return RedirectToAction("Index","Writer");
			}
			else
			{
				return View();
			}
		}

	}
}
//	Context context = new Context();
//	var dataValue = context.Writers.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
//            if (dataValue!=null)
//            {
//                HttpContext.Session.SetString("Name", p.Mail);
//                return RedirectToAction("Index","Writer");
//}

//			else
//{
//	return View();
//}

//        }