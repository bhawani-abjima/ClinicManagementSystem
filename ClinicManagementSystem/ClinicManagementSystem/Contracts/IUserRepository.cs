﻿using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IUserRepository
    {
        Task <string> AddAsync(UserModel user);
      
    }
}
