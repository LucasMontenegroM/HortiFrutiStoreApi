using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HortiFrutiStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/error")]
public abstract class MainController : ControllerBase
{
    public IActionResult HandleError() =>
        Problem();
}
