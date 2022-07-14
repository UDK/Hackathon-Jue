using Hackathon_Jue.DB;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Jue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly HackathonContext _context;

        public MainController()
        {
            _context = new HackathonContext();
        }

        [HttpGet("Team")]
        public async Task<IActionResult> GetAllTeams()
        {
             return Ok(_context.Teams.AsQueryable<Team>().ToList());
        }

        [HttpPost("Team")]
        public async Task<IActionResult> CreateTeam(Team newTeam)
        {
            var result = await _context.Teams.AddAsync(newTeam);
            return Ok(result);
        }
    }
}