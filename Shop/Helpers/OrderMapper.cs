using Entities;
using Shop.Entities;
using Shop.ViewModels;
using System;
using System.Collections.Generic;

namespace Shop.Helpers
{
    public class OrderMapper
    {
        public Order MapToOrderModel(CreateOrderViewModel from, string currentUserId)
        {
            Order order = new Order
            {
                Adress = new Adress
                {
                    City = from.Adress.City,
                    Street = from.Adress.Street,
                    BuildingNumber = from.Adress.BuildingNumber,
                    FlatNumber = from.Adress.FlatNumber,
                    PostCode = from.Adress.PostCode
                },
                UserId = currentUserId,
                Products = new List<ProductInfo>() { },
                TotalAmount = from.TotalAmount,
                CreationDate = DateTime.Now
            };

            from.Items.ForEach(i => order.Products.Add(new ProductInfo
            {
                ProductId = i.Id,
                Quantity = i.Quantity
            }));

            return order;
        }
    }
}
