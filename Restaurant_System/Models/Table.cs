namespace RestaurantSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int NumberOfSeats {  get; set; }
        public Order ActiveOrder { get; set; }
        public Reservation Reservation { get; set; }

        public bool IsFree()
        {
            bool noActiveOrder = ActiveOrder == null;
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

        public void ActivateReservation()
        {
            if (Reservation != null && ActiveOrder == null)
            {
                Order order = new Order(Reservation.NumberOfPeople, Reservation.ReservationDateTime, Id, NumberOfSeats, Reservation.EmployeeId);
                ActiveOrder = order;
                Reservation = null;
            }
        }

        public bool Occupy(Order order)
        {
            if (IsFree() && NumberOfSeats >= order.NumberOfPeople)
            {
                ActiveOrder = order;
                return true;
            }
            return false;
        }

        public void FreeUp()
        {
            ActiveOrder = null;
        }

        public override string ToString()
        {
            string status = IsFree() ? "Free" : "Occupied";
            return $"Id: {Id}, Number of seats: {NumberOfSeats}, Status: {status}";
        }
    }
}
