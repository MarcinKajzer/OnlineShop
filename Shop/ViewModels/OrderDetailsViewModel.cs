using Shop.DTOs;
using System;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public AdressDTO Adress { get; set; }
        public List<ProductInfoDTO> Products { get; set; }
        public bool IsSent { get; set; }
    }
}
