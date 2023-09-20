using Application;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    public class ItemController: ControllerBase
    {
        Behaviour behaviour;

        public ItemController(IDb db) 
        {
            behaviour = new Behaviour(db);
        }

        [HttpGet]
        [Authorize]
        [Route("/items")]
        public ActionResult GetItems()
        {
            var userId = HttpContext.User.Claims.Where(x=>x.Type.Equals("id")).First().Value;
            try
            {
                var items = behaviour.GetItems(int.Parse(userId));
                
                return Ok(items);

            }
            catch (Exception)
            {

                return StatusCode(500, "internal server error");
            }
        }
        
        [HttpPost]
        [Authorize]
        [Route("/items")]
        public ActionResult AddItem(string content)
        {
            var item = new Item { 
                UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type.Equals("id")).First().Value),
                Content = content,
            };
            
            try 
            {
                behaviour.AddItem(item);
            }
            catch (Exception) 
            { 
                return StatusCode(500, "internal server error"); 
            }

            return Ok(behaviour.GetItems(int.Parse(User.Claims.Where(x => x.Type.Equals("id")).First().Value)));
        }
        
        [HttpDelete]
        [Authorize]
        [Route("/items/{itemId}")]
        public ActionResult RemoveItem(int itemId)
        {

            var item = behaviour.GetItem(itemId);
            if(item is null)  return NotFound();
            try 
            {
                behaviour.RemoveItem(item);
            }
            catch (Exception) 
            { 
                return StatusCode(500, "internal server error"); 
            }

            return Ok(behaviour.GetItems(int.Parse(User.Claims.Where(x => x.Type.Equals("id")).First().Value)));
        }
        
        [HttpPut]
        [Authorize]
        [Route("/items/{itemId}")]
        public ActionResult ItemDone(int itemId)
        {

            try
            {
                behaviour.ItemDone(itemId);
            }
            catch (Exception)
            {
                return StatusCode(500, "internal server error");
            } 
            

            return Ok(behaviour.GetItems(int.Parse(User.Claims.Where(x => x.Type.Equals("id")).First().Value)));
        }
        
        [HttpPatch]
        [Authorize]
        [Route("/items/{itemId}")]
        public ActionResult ItemUnDone(int itemId)
        {

            try
            {
                behaviour.ItemUnDone(itemId);
            }
            catch (Exception)
            {
                return StatusCode(500, "internal server error");
            } 
            

            return Ok(behaviour.GetItems(int.Parse(User.Claims.Where(x => x.Type.Equals("id")).First().Value)));
        }
    }
}
