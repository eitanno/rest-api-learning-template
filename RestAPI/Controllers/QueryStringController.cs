using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using RestAPI.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class QuerystringController : ControllerBase
{

    public enum SortOrder
    {
        Ascending,
        Descending
    }





}
