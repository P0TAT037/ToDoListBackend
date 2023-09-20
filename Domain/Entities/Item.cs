namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public required int UserId { get; set; }

        public required string Content { get; set; }

        public bool IsDone { get; set; }

        public User User { get; set; }
    }
}
