namespace RestaurantSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Employee(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
