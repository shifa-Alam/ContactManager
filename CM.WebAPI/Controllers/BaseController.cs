using Microsoft.AspNetCore.Mvc;

namespace CM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase, IDisposable
    {
        public abstract void Dispose();

    }
}
