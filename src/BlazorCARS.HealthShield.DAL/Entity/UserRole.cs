﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Created by JAYaseelan
 */

namespace BlazorCARS.HealthShield.DAL.Entity
{
    public class UserRole : BaseDomain
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
    }
}
