namespace RestaurantSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int NumberOfSeats {  get; set; }
        public int ActiveOrderId { get; set; }
        public Reservation Reservation { get; set; }

        public bool IsFree()
        {
            bool noActiveOrder = ActiveOrderId == 0;
            bool noReservation = Reservation == null;
            return noActiveOrder && noReservation;
        }

        public bool Reserve(Reservation reservation)
        {
            if (IsFree() && NumberOfSeats >= reservation.NumberOfPeople) 
            {
                Reservation = reservation;
                return true;
            }
            return false;
        }

        public bool Occupy(Order order)
        {
            if (IsFree() && NumberOfSeats >= order.NumberOfPeople)
            {
                ActiveOrderId = order.OrderId;
                return true;
            }
            return false;
        }

        public void FreeUp()
        {
            ActiveOrderId = 0;
        }

        public override string ToString()
        {
            string status = IsFree() ? "Free" : "Occupied";
            return $"Id: {Id}, Number of seats: {NumberOfSeats}, Status: {status}";
        }
    }
}
