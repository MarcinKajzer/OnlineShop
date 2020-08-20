using Shop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shop.Models
{
    public class Cart
    {
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalQuantity { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();


        public string FormatedTotalAmount => TotalAmount.ToString("0.00");

        public void AddItem(CartItem item)
        {
            CartItem findItem = FindItem(item.Id, item.Size);

            if (findItem != null)
                findItem.Quantity += item.Quantity;
            else
                Items.Add(item);

            TotalQuantity += item.Quantity;
            TotalAmount += item.Quantity * item.Price;
        }

        public void RemoveItem(int id, Size size)
        {
            CartItem findItem = FindItem(id, size);

            if(findItem != null)
            {
                Items.Remove(findItem);
                TotalAmount -= findItem.Quantity * findItem.Price;
                TotalQuantity -= findItem.Quantity;
            }
        }

        public void ChangeQuantity(int id, Size size, int difference)
        {
            CartItem findItem = FindItem(id, size);

            if (findItem != null)
            {
                if(findItem.Quantity > 0 || (findItem.Quantity == 0 && difference > 0))
                {
                    findItem.Quantity += difference;
                    TotalAmount += difference * findItem.Price;
                    TotalQuantity += difference;
                }
            }
        }

        public CartInfo GetSingleIntemInfo(int id, Size size)
        {
            CartItem findItem = FindItem(id, size);

            return new CartInfo
            {
                Amount = findItem.Quantity * findItem.Price,
                Quantity = findItem.Quantity
            };
        }

        public CartInfo GetTotalInfo()
        {
            return new CartInfo
            {
                Amount = TotalAmount,
                Quantity = TotalQuantity
            };
        }



        private CartItem FindItem(int id, Size size)
        {
            return Items.SingleOrDefault(i => i.Id == id && i.Size == size);
        }
    }
}
