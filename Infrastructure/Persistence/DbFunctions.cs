using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbFunctions : IDb
    {
        AppDbContext appDbContext = new();
        public void AddItem(Item item)
        {
            appDbContext.items.Add(item);
            appDbContext.SaveChanges();
        }

        public void AddUser(User user)
        {
            appDbContext.users.Add(user);
            appDbContext.SaveChanges();
        }

        public List<Item> GetItems(int userId)
        {
            return appDbContext.items.Where(x=>x.UserId == userId).ToList();
        }

        public void ItemDone(int itemId)
        {
            appDbContext.items.Where(x=>x.Id == itemId).First().IsDone = true;
            appDbContext.SaveChanges();
        }
        
        public void ItemUnDone(int itemId)
        {
            appDbContext.items.Where(x=>x.Id == itemId).First().IsDone = false;
            appDbContext.SaveChanges();
        }

        public void RemoveItem(Item item)
        {
            appDbContext.items.Remove(item);
            appDbContext.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            appDbContext.users.Remove(user);
            appDbContext.SaveChanges();
        }

        public bool UserExists(string username)
        {
            return appDbContext.users.Where(x=> x.Username == username).Any();
        }

        public User? GetUser(string username, string password)
        {
            return appDbContext.users.Where(x=>x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
        }

        public Item? GetItem(int itemId)
        {
            return appDbContext.items.Where(x=>x.Id == itemId).FirstOrDefault();
        }
    }
}
