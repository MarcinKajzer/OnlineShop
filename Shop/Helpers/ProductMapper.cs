using Entities;
using Shop.Common;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public class ProductMapper
    {
        public Product MapValues(CreateProductViewModel from)
        {
            Product product = new Product
            {
                Category = from.Category,
                Color = from.Color,
                Description = from.Description,
                Gender = from.Gender,
                Name = from.Name,
                Price = from.Price,
                Sizes = new List<Size>()
            };

            foreach (var size in from.Sizes)
            {
                if (size.Quantity > 0)
                {
                    product.Quantity += size.Quantity;

                    product.Sizes.Add(new Size
                    {
                        Name = size.Name,
                        Quantity = size.Quantity
                    });
                }
            }

            return product;
        }

        public Product MapValues(UpdateProductViewModel from, Product to)
        {
            to.Category = from.Category;
            to.Color = from.Color;
            to.Description = from.Description;
            to.Gender = from.Gender;
            to.Name = from.Name;
            to.Price = from.Price;
            to.Quantity = 0;

            foreach (var size in from.Sizes)
            {
                if (size.Quantity > 0)
                    to.Quantity += size.Quantity;
            }

            for (int i = 0; i < from.Sizes.Count(); i++)
            {
                if (from.Sizes[i].ExistsInDB)
                    to.Sizes.FirstOrDefault(s => s.Id == from.Sizes[i].Id).Quantity = from.Sizes[i].Quantity;
                
                else if (from.Sizes[i].Quantity > 0)
                {
                    Size s = new Size { Quantity = from.Sizes[i].Quantity, Name = from.Sizes[i].Name };
                    to.Sizes.Add(s);
                }
            }

            return to;
        }

        public UpdateProductViewModel MapValues(Product from)
        {
            UpdateProductViewModel viewModel = new UpdateProductViewModel
            {
                Category = from.Category,
                Color = from.Color,
                Description = from.Description,
                Gender = from.Gender,
                Id = from.Id,
                Name = from.Name,
                Price = from.Price,
                Sizes = new List<SizeModel>()
            };

            foreach (SizeEnum size in Enum.GetValues(typeof(SizeEnum)))
            {
                SizeModel sizeModel = new SizeModel { Name = size };

                foreach (var item in from.Sizes)
                {
                    if (item.Name == size)
                    {
                        sizeModel.Quantity = item.Quantity;
                        sizeModel.Id = item.Id;
                        sizeModel.ExistsInDB = true;
                        break;
                    }
                    else
                        sizeModel.Quantity = 0;
                    
                }

                viewModel.Sizes.Add(sizeModel);
            }

            return viewModel;
        }
    }
}
