using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Extensions
{
	public class SummaryviewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync() {
			return View();
		}
	}
}
