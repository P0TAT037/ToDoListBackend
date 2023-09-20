namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Username { get; set; }
        
        public required string Password { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}