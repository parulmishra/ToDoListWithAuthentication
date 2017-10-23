using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoListWithAuthentication.Models
{
    public class EFItemRepository: IItemRepository
    {
        ToDoContext db = new ToDoContext();

        public EFItemRepository(ToDoContext context = null)
        {
            if (context == null)
            {
                this.db = new ToDoContext();
            }
            else 
            { 
                this.db = context;
            }
        }
        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Item Save(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }
    }
}
