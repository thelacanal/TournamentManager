using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



[Route("api/[controller]")]
[ApiController]
public class MatchesController : ControllerBase
{
    private readonly ApplicationContext _dbContext;
    public MatchesController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    // Get all matches
    [HttpGet]
    public IActionResult GetMatches()
    {
        var matches = _dbContext.Matches.ToList();
        return Ok(matches);
    }
    // Create a match
    [HttpPost]
    public IActionResult CreateMatch([FromBody] Match match)
    {
        _dbContext.Matches.Add(match);
        _dbContext.SaveChanges();
        return Ok(match);
    }
    [HttpGet("{id}")]
    public IActionResult GetMatch(int id)
    {
        var match = _dbContext.Matches.FirstOrDefault(t => t.Id == id);
        if (match == null)
        {
            return NotFound();
        }
        return Ok(match);
    }
    // Modify Match
    [HttpPut("{id}")]
    public IActionResult UpdateMatch(int id, [FromBody] Match match)
    {
        var matchToBeUpdated = _dbContext.Matches.FirstOrDefault(t => t.Id == id);
        if (matchToBeUpdated == null)
        {
            return NotFound();
        }
        matchToBeUpdated.Team1 = match.Team1;
        matchToBeUpdated.Team2 = match.Team2;
        matchToBeUpdated.TournamentId = match.TournamentId;
        // matchToBeUpdated.Date = match.Date;
        matchToBeUpdated.Score1 = match.Score1;
        matchToBeUpdated.Score2 = match.Score2;
        _dbContext.SaveChanges();
        return Ok(matchToBeUpdated);
    }
    // Delete Match
    [HttpDelete("{id}")]
    public IActionResult DeleteMatch(int id)
    {
        var match = _dbContext.Matches.FirstOrDefault(t => t.Id == id);
        if (match == null)
        {
            return NotFound();
        }
        _dbContext.Matches.Remove(match);
        _dbContext.SaveChanges();
        return Ok(match);
    }

}