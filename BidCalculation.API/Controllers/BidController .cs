using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BidController : ControllerBase
{
    private readonly IBidRepository _bidRepository;

    public BidController(IBidRepository bidRepository)
    {
        _bidRepository = bidRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBidById(Guid id)
    {
        var bid = await _bidRepository.FindByIdAsync(id);
        if (bid == null)
        {
            return NotFound("Bid not found.");
        }
        return Ok(bid);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBid(Bid bid)
    {
        await _bidRepository.AddAsync(bid);
        return CreatedAtAction(nameof(GetBidById), new { id = bid.Id }, bid);
    }
}