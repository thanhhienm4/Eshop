﻿using EshopSolution.Data.Entities;
using EshopSolution.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EshopSolution.ViewModels.System.Users
{
    public class UpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Khả dụng")]
        public Status Status { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}