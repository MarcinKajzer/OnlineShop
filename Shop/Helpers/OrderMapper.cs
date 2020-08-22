using Entities;
using Shop.DTOs;
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
                TotalAmount = from.TotalAmount,
                Products = new List<ProductInfo>() { },
                CreationDate = DateTime.Now
            };

            from.Items.ForEach(i => order.Products.Add(new ProductInfo
            {
                ProductId = i.Id,
                Quantity = i.Quantity,
                SelectedSize = i.Size
            }));

            return order;
        }

        public OrderDetailsViewModel MapToOrderDetailsViewModel(Order from)
        {
            OrderDetailsViewModel viewModel = new OrderDetailsViewModel
            {
                Adress = new AdressDTO
                {
                    City = from.Adress.City,
                    Street = from.Adress.Street,
                    BuildingNumber = from.Adress.BuildingNumber,
                    FlatNumber = from.Adress.FlatNumber,
                    PostCode = from.Adress.PostCode
                },
                Id = from.Id,
                CreationDate = from.CreationDate,
                UserEmail = from.User.Email,
                UserName = from.User.FirstName + " " + from.User.LastName,
                IsSent = from.IsSent,
                Products = new List<ProductInfoDTO>()
            };

            from.Products.ForEach(p => viewModel.Products.Add(new ProductInfoDTO
            {
                Name = p.Product.Name,
                Quantity = p.Quantity,
                Size = p.SelectedSize
            }));

            return viewModel;
        }
    }
}
