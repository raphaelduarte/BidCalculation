using System.ComponentModel.DataAnnotations;

namespace BidCalculation.API.Requests;

public class AuctionRequest
{
    [Required(ErrorMessage = "StartDate is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "EndDate is required")]
    public DateTime EndDate { get; set; }
}