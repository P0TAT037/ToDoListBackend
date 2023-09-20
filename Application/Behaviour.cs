using Application.Interfaces;
using Domain.Entities;
using Presentation.DTOs;

namespace Application
{
    public class Behaviour
    {
        private IDb _db;

        public Behaviour(IDb db)
        {
            _db = db;
        }   
        public void AddItem(Item item) 
        {
            _db.AddItem(item);
        }

        public bool UserExists(string username)
        {
            return _db.UserExists(username);
        }
        
        public User GetUser(string username, string password)
        {
            return _db.GetUser(username, password);
        }

        public void AddUser(User user)
        {
            _db.AddUser(user);
        }

        public void RemoveUser(User user)
        {
            _db.RemoveUser(user);
        }
        public void RemoveItem(Item item)
        {
            _db.RemoveItem(item);
        }

        public List<ItemDTO> GetItems(int userId) 
        {
            var items = _db.GetItems(userId);
            var i = new List<ItemDTO>();
            foreach (var item in items)
            {
                i.Add(new ItemDTO(item));
            }
            return i;
        }

        
        public Item? GetItem(int itemId) 
        {
            return _db.GetItem(itemId);
        }

        public void ItemDone(int itemId)
        {
            _db.ItemDone(itemId);
        }
        
        public async void ItemUnDone(int itemId)
        {
            _db.ItemUnDone(itemId);
        }

    }
}