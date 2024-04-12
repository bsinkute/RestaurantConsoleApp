namespace RestaurantSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public int TableId { get; set; }

        public Reservation(int id, DateTime reservationDateTime, int numberOfPeople, string customerName, string contactNumber, int tableId)
        {
            Id = id;
            ReservationDateTime = reservationDateTime;
            NumberOfPeople = numberOfPeople;
            CustomerName = customerName;
            ContactNumber = contactNumber;
            TableId = tableId;
        }

        public override string ToString()
        {
            return $"Reservation ID: {Id}, Date and Time: {ReservationDateTime}, People: {NumberOfPeople}, Customer: {CustomerName}, Contact: {ContactNumber}, Table ID: {TableId}";
        }
    }
}
