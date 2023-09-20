using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDb
    {
        public void AddItem(Item item);
        
        public void RemoveItem(Item item);

        public bool UserExists(string username);
        
        public User? GetUser(string username, string password);  
        
        public void AddUser(User user);

        public void RemoveUser(User user);

        public List<Item> GetItems(int userId);
        public Item? GetItem(int itemId);

        public void ItemDone(int itemId);

        public void ItemUnDone(int itemId);
    }
}
