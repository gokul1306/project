using Microsoft.AspNetCore.Mvc;

namespace project.Controller;

  [ApiController]
  [Route("[controller]/[action]")]
  public class PoolController : ControllerBase
  {
    private readonly ILogger _logger;
    public PoolController(ILogger<PoolController> logger)
    {
        _logger = logger;
    }
    IProjectService ProjectService = DataFactory.PoolDataFactory.GetPoolServiceObject();

    [HttpPost]
    public IActionResult CreateNewProject( int departmentId,string projectName)
    {
        if (departmentId <= 0 || projectName == null) 
            return BadRequest("Project name and Department  is required");

        try
        {
            return ProjectService.CreatePool(departmentId,projectName) ? Ok("Project Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : CreatePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpPost]
    public IActionResult RemoveProject(int projectId)
    {
        if (ProjectId <= 0) return BadRequest("Project Id is not provided");

        try
        {
            return ProjectService.RemoveProject(projectId) ? Ok("Project Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Project Service : RemoveProject throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
      [HttpGet]
    public IActionResult ViewProjects()
    {
        try
        {
            return Ok(ProjectService.ViewProjects());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
  }





