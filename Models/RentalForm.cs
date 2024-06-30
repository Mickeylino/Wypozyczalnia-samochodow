public class RentalForm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime LeavingDate { get; set; }
    public bool Consent { get; set; }
    public int CarId { get; set; }
    public string UserId { get; set; } // New field to link to user

}