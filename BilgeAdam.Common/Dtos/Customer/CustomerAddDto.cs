﻿using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.Common.Dtos.Customer
{
    public class CustomerAddDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [MaxLength(5)]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(30, ErrorMessage = "En fazle 30 karakter olabilir")]
        public string ContactName { get; set; }

        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(15)]
        public string Region { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(24)]
        public string Fax { get; set; }
    }
}