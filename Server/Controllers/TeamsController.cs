using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly ApplicationContext _dbContext;

    public TeamsController(ApplicationContext dbContext)
     {
        _dbContext = dbContext;
    }
    // Get all teams
    [HttpGet]
    public IActionResult GetTeams()
    {
        var teams = _dbContext.Teams.ToList(); //is this good practice?
        return Ok(teams);
    }

    // Create a team
    [HttpPost]
    public IActionResult CreateTeam([FromBody] Team team)
    {
        _dbContext.Teams.Add(team);
        _dbContext.SaveChanges();
        return Ok(team);
    }
    [HttpGet("{id}")]
    public IActionResult GetTeam(int id)
    {
        var team = _dbContext.Teams.FirstOrDefault(t => t.Id == id);
        if (team == null)
        {
            return NotFound();
        }
        return Ok(team);
    }
    // Modify Team
    [HttpPut("{id}")]
    public IActionResult UpdateTeam(int id, [FromBody] Team team)
    {
        var teamToBeUpdated = _dbContext.Teams.FirstOrDefault(t => t.Id == id);
        if (teamToBeUpdated == null)
        {
            return NotFound();
        }
        teamToBeUpdated.Name = team.Name;
        teamToBeUpdated.Game = team.Game;
        teamToBeUpdated.Owner = team.Owner;
        teamToBeUpdated.Description = team.Description;
        _dbContext.SaveChanges();
        return Ok(teamToBeUpdated);
    }
    // Delete Team
    [HttpDelete("{id}")]
    public IActionResult DeleteTeam(int id)
    {
        var teamToBeDeleted = _dbContext.Teams.FirstOrDefault(t => t.Id == id);
        if (teamToBeDeleted == null)
        {
            return NotFound();
        }
        _dbContext.Teams.Remove(teamToBeDeleted);
        _dbContext.SaveChanges();
        return Ok(teamToBeDeleted);
    }
}
