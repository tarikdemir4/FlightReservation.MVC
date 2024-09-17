﻿namespace FlightReservation.MVC.Models;

public sealed class Route
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Departure { get; set; } = string.Empty;
    public string Arrival { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public Guid PlaneId { get; set; }
    public Plane? Plane { get; set; }
}

