using Entities;
using Shop.Common;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Helpers
{
    public class ProductMapper
    {
        public Product MapToProductModel(CreateProductViewModel from)
        {
            Product product = new Product
            {
                Category = from.Category,
                Color = from.Color,
                Description = from.Description,
                Gender = from.Gender,
                Name = from.Name,
                Price = from.Price,
                Image = from.ImageName,
                Sizes = new List<SizeInfo>()
            };

            foreach (var size in from.Sizes.Where(s => s.Quantity > 0))
            {
                product.Quantity += size.Quantity;

                product.Sizes.Add(new SizeInfo
                {
                    Size = size.Size,
                    Quantity = size.Quantity
                });
            }

            return product;
        }

        public Product UpdateExistingProduct(UpdateProductViewModel from, Product to)
        {
            to.Id = from.Id;
            to.Category = from.Category;
            to.Color = from.Color;
            to.Description = from.Description;
            to.Gender = from.Gender;
            to.Name = from.Name;
            to.Quantity = 0;
            to.Price = from.Price;
            to.IsOverpriced = from.IsOverpriced;

            if (from.IsOverpriced)
            {
                to.BeforePrice = to.Price;
                to.Price = from.NewPrice;
            }
            
            for (int i = 0; i < from.Sizes.Count(); i++)
            {
                if (from.Sizes[i].ExistsInDB)
                {
                    to.Sizes.FirstOrDefault(s => s.Id == from.Sizes[i].Id).Quantity = from.Sizes[i].Quantity;
                    to.Quantity += from.Sizes[i].Quantity;
                }
                else
                {
                    if (from.Sizes[i].Quantity > 0)
                    {
                        SizeInfo s = new SizeInfo { Quantity = from.Sizes[i].Quantity, Size = from.Sizes[i].Size };
                        to.Sizes.Add(s);
                    }
                }
            }

            return to;
        }

        public UpdateProductViewModel MapToUpdateProductViewModel(Product from)
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
                IsOverpriced = from.IsOverpriced,
                Sizes = new List<SizeInfoDTO>()
            };

            foreach (Size sizeName in Enum.GetValues(typeof(Size)))
            {
                SizeInfoDTO sizeModel = new SizeInfoDTO { Size = sizeName, Quantity = 0 };

                var size = from.Sizes.FirstOrDefault(s => s.Size == sizeName);

                if (size != null)
                {
                    sizeModel.Quantity = size.Quantity;
                    sizeModel.Id = size.Id;
                    sizeModel.ExistsInDB = true;
                }

                viewModel.Sizes.Add(sizeModel);
            }

            return viewModel;
        }

        public ProductDetailsViewModel MapToProductDetailsViewModel(Product from, bool isFavourite)
        {
            ProductDetailsViewModel product = new ProductDetailsViewModel
            {
                Id = from.Id,
                Category = from.Category,
                Color = from.Color,
                Description = from.Description,
                Gender = from.Gender,
                Name = from.Name,
                Price = from.Price,
                Sizes = new List<SizeInfoDTO>(),
                Quantity = from.Quantity,
                Image = from.Image,
                BeforePrice = from.BeforePrice,
                IsOverpriced = from.IsOverpriced,
                IsFavourite = isFavourite
            };

            foreach (var size in from.Sizes.OrderBy(x => x.Size))
            {
                product.Sizes.Add(new SizeInfoDTO
                {
                    Size = size.Size,
                    Quantity = size.Quantity
                });
            }

            return product;
        }
    }
}
