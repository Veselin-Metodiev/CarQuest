namespace CarQuest.Web.Controllers;

using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

public class BaseController : Controller
{
    protected Guid GetUserId()
    {
	    Guid id = Guid.Empty;

        if (User.Identity != null)
        {
            id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        return id;
    }
}
