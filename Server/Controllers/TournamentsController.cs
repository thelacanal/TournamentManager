using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class TournamentsController : ControllerBase
{
    private readonly ApplicationContext _dbContext;
    public TournamentsController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    // Get all tournaments
    [HttpGet]
    public IActionResult GetTournaments()
    {
        var tournaments = _dbContext.Tournaments.ToList();
        return Ok(tournaments);
    }
    // Create a tournament
    [HttpPost]
    public IActionResult CreateTournament([FromBody] Tournament tournament)
    {
        _dbContext.Tournaments.Add(tournament);
        _dbContext.SaveChanges();
        return Ok(tournament);
    }
    [HttpGet("{id}")]
    public IActionResult GetTournament(int id)
    {
        var tournament = _dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
        if (tournament == null)
        {
            return NotFound();
        }
        return Ok(tournament);
    }
    // Modify Tournament
    [HttpPut("{id}")]
    public IActionResult UpdateTournament(int id, [FromBody] Tournament tournament)
    {
        var tournamentToBeUpdated = _dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
        if (tournamentToBeUpdated == null)
        {
            return NotFound();
        }
        tournamentToBeUpdated.Name = tournament.Name;
        tournamentToBeUpdated.Date = tournament.Date;
        tournamentToBeUpdated.PricePool = tournament.PricePool;
        tournamentToBeUpdated.Fee = tournament.Fee;
        tournamentToBeUpdated.Slots = tournament.Slots;
        _dbContext.SaveChanges();
        return Ok(tournamentToBeUpdated);
    }
    // Delete Tournament
    [HttpDelete("{id}")]
    public IActionResult DeleteTournament(int id)
    {
        var tournament = _dbContext.Tournaments.FirstOrDefault(t => t.Id == id);
        if (tournament == null)
        {
            return NotFound();
        }
        _dbContext.Tournaments.Remove(tournament);
        _dbContext.SaveChanges();
        return Ok(tournament);
    }
}
