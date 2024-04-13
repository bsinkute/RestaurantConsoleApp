namespace RestaurantSystem.Models
{
    public class Reservation
    {
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }

        public Reservation(DateTime reservationDateTime, int numberOfPeople, string customerName, string contactNumber)
        {
            ReservationDateTime = reservationDateTime;
            NumberOfPeople = numberOfPeople;
            CustomerName = customerName;
            ContactNumber = contactNumber;
        }

        public override string ToString()
        {
            return $"Reservation Date and Time: {ReservationDateTime}, People: {NumberOfPeople}, Customer: {CustomerName}, Contact: {ContactNumber}";
        }
    }
}
