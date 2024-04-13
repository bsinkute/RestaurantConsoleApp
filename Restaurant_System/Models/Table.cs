namespace RestaurantSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        int NumberOfSeats {  get; set; }

        public Table(int id, int numberOfSeat)
        {
            Id = id;
            NumberOfSeats = numberOfSeat;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Number of seats: {NumberOfSeats}";
        }
    }
}
