namespace FlightReservation.MVC.DTOs;

public sealed record AddPlaneDto(
  string Name,
  string TailNumber,
  string SeatConfiguration,
  int TotalSeats);
