﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DiamondShopSystem.Data.Models;

public partial class Customer
{
    public string Id { get; set; }

    public string CustomerName { get; set; }

    public string CustomerPhone { get; set; }

    public string CustomerAddress { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}