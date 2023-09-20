using Domain.Entities;

namespace Presentation.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public bool IsDone { get; set; } = false;
        
        public ItemDTO(Item i) {
            Content = i.Content;
            IsDone = i.IsDone;
            Id = i.Id;
        }
    }
}
