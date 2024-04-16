namespace RestaurantSystem.Models
{
    public class MenuItem : IComparable<MenuItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }

        public MenuItem(int id, string name, decimal price, DateTime addedDate)
        {
            Id = id;
            Name = name;
            Price = price;
            AddedDate = addedDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }

        public int CompareTo(MenuItem? other)
        {
            if (other == null) return 1;

            return Id.CompareTo(other.Id);
        }
    }
}
