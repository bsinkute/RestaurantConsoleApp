namespace RestaurantSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        int NumberOfSeat {  get; set; }

        public Table(int id, int numberOfSeat)
        {
            Id = id;
            NumberOfSeat = numberOfSeat;
        }

        public override string ToString()
        {
            return $" Id.: {Id}";
        }
    }
}
