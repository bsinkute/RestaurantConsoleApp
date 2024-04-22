namespace RestaurantSystem.Models
{
    public class Reservation
    {
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public int EmployeeId { get; set; }

        public Reservation(DateTime reservationDateTime, int numberOfPeople, string customerName, string contactNumber, int employeeId)
        {
            ReservationDateTime = reservationDateTime;
            NumberOfPeople = numberOfPeople;
            CustomerName = customerName;
            ContactNumber = contactNumber;
            EmployeeId = employeeId;
        }
    }
}
