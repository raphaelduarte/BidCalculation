using BidCalculation.Application.UseCases;
using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionController : ControllerBase
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly FeeCalculationUseCase _feeCalculationUseCase;

    public AuctionController(IAuctionRepository auctionRepository, FeeCalculationUseCase feeCalculationUseCase)
    {
        _auctionRepository = auctionRepository;
        _feeCalculationUseCase = feeCalculationUseCase;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuctionById(Guid id)
    {
        var auction = await _auctionRepository.FindByIdAsync(id);
        if (auction == null)
        {
            return NotFound("Auction not found.");
        }
        return Ok(auction);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuction(Auction auction)
    {
        await _auctionRepository.AddAsync(auction);
        return CreatedAtAction(nameof(GetAuctionById), new { id = auction.Id }, auction);
    }

    [HttpPost("{id}/calculate-fee")]
    public async Task<IActionResult> CalculateFee(Guid id)
    {
        var fee = await _feeCalculationUseCase.Execute(id);
        return Ok(new { Fee = fee });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuctions()
    {
        var auctions = await _auctionRepository.GetAllAsync();
        return Ok(auctions);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuction(Guid id, Auction updatedAuction)
    {
        var auction = await _auctionRepository.FindByIdAsync(id);
        if (auction == null)
        {
            return NotFound("Auction not found.");
        }

        auction.StartDate = updatedAuction.StartDate;
        auction.EndDate = updatedAuction.EndDate;

        await _auctionRepository.UpdateAsync(auction);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuction(Guid id)
    {
        var auction = await _auctionRepository.FindByIdAsync(id);
        if (auction == null)
        {
            return NotFound("Auction not found.");
        }

        await _auctionRepository.DeleteAsync(auction);
        return NoContent();
    }

}