﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Shared.Models
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
