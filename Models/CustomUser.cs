﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StockMarket_begum.Data;


namespace StockMarket_begum.Models;

    public class CustomUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Addres")]
        public string? Address { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }


    public List<Transaction> Transactions { get; set; } = new();
        public Portfolio Portfolio { get; set; }

    }

public class CustomRole : IdentityRole
    {
    }
   
