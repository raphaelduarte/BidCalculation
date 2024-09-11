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

    [HttpGet]
    public async Task<IActionResult> GetAllBids()
    {
        var bids = await _bidRepository.GetAllAsync();
        return Ok(bids);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBid(Guid id, Bid updatedBid)
    {
        var bid = await _bidRepository.FindByIdAsync(id);
        if (bid == null)
        {
            return NotFound("Bid not found.");
        }

        bid.BasePrice = updatedBid.BasePrice;
        bid.VehicleType = updatedBid.VehicleType;

        await _bidRepository.UpdateAsync(bid);
        return NoContent();
    }


    [HttpPost]
    public async Task<IActionResult> CreateBid(Bid bid)
    {
        await _bidRepository.AddAsync(bid);
        return CreatedAtAction(nameof(GetBidById), new { id = bid.Id }, bid);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBid(Guid id)
    {
        var bid = await _bidRepository.FindByIdAsync(id);
        if (bid == null)
        {
            return NotFound("Bid not found.");
        }

        await _bidRepository.DeleteAsync(bid);
        return NoContent();
    }
}