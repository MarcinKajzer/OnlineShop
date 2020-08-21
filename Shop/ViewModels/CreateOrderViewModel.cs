using Shop.DTOs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required]
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }

        [Required]
        public  AdressDTO Adress { get; set; }
        public  List<CartItem> Items { get; set; }

        public string FormatedTotalAmount => TotalAmount.ToString("0.00");
    }
}
