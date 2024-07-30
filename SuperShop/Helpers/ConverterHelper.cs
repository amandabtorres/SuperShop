using SuperShop.Data.Entities;
using SuperShop.Models;
using System;
using System.IO;

namespace SuperShop.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Product ToProduct(ProductViewModel model, Guid imageId, bool isNew)
        {
            return new Product
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Price = model.Price,
                IsAvailable = model.IsAvailable,
                LastPurschase = model.LastPurschase,
                LastSale = model.LastSale,
                Stock = model.Stock,
                User = model.User,
                ImageId = imageId
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                LastPurschase = product.LastPurschase,
                LastSale = product.LastSale,
                Stock = product.Stock,
                User = product.User,
                ImageId = product.ImageId
            };
        }
    }

   
}
