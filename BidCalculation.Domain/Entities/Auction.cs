﻿using BidCalculation.Domain.Core;

namespace BidCalculation.Domain.Entities;

public class Auction : Entity
{
    public Auction() { }
    public Auction(DateTime startDateTime, DateTime endDateTime)
    {
        StartDate = startDateTime;
        EndDate = endDateTime;
    }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    public ICollection<Bid> Bids { get; set; } = new List<Bid>();
}