﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListWithAuthentication.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public virtual ApplicationUser User { get; set; }

        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Item))
            {
                return false;
            }
            else
            {
                Item newItem = (Item)otherItem;
                return this.ItemId.Equals(newItem.ItemId);
            }
        }

        public override int GetHashCode()
        {
            return this.ItemId.GetHashCode();
        }
    }
}