using DataAccess.EfCore.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/developers")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevs = _unitOfWork.DeveloperRepository.GetPopularDevelopers(count).ToList();
            return Ok(popularDevs);
        }
        [HttpPost]
        public IActionResult FillerData()
        {
            var developer = new Developer()
            {
                Followers = 35,
                Name = "Benjamin",
            };

            var project = new Project()
            {
                Name = "Dummy project"
            };
            _unitOfWork.DeveloperRepository.Add(developer);
            _unitOfWork.ProjectRepository.Add(project);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
