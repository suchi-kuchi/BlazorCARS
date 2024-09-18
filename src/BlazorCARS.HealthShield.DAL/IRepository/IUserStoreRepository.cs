﻿using BlazorCARS.HealthShield.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Created by JAYaseelan
 */
namespace BlazorCARS.HealthShield.DAL.IRepository
{
    public interface IUserStoreRepository : IBaseRepository<UserStore>
    {
        //Can be extended based on business requirement
        Task<UserStore> GetByUserNameAsync(string username);
    }
}
