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

        [HttpGet("team")]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(_context.Teams.AsQueryable<Team>().ToList());
        }

        [HttpPost("team")]
        public async Task<IActionResult> CreateTeam(Team newTeam)
        {
            var result = await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPut("team/{teamId}/invite")]
        public async Task<IActionResult> InviteUser([FromRoute] Guid teamId, [FromBody] string inviteUser)
        {
            var team = _context.Teams.FirstOrDefault(q => q.Id == teamId);
            team.InvitedUsers.Add(inviteUser);
            await _context.SaveChangesAsync();
            return Ok(team);
        }
        
        [HttpPut("team/{teamId}/approved")]
        public async Task<IActionResult> ApproveUser([FromRoute] Guid teamId, [FromBody] string name)
        {
            var team = _context.Teams.FirstOrDefault(q => q.Id == teamId);
            if (!team.InvitedUsers.Remove(name)) return NotFound();
            team.ApprovedUser.Add(name);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpPut("team/{teamId}/reject")]
        public async Task<IActionResult> RejectUser([FromRoute] Guid teamId, [FromBody] string name)
        {
            var team = _context.Teams.FirstOrDefault(q => q.Id == teamId);
            if (!team.InvitedUsers.Remove(name)) return NotFound();
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpGet("user/{name}")]
        public async Task<IActionResult> IsInvitedTeam([FromRoute] string name)
        {
            return Ok(_context.Teams.Where(q => q.InvitedUsers.Contains(name)).ToList().Select(q => q.Name));
        }

    }
}