﻿using InventoryMGMT_SYSTEM.NET.Models;
using InventoryMGMT_SYSTEM.NET.DTOs;

namespace InventoryMGMT_SYSTEM.NET.Services.UserServices
{
    public interface IUserService
    {
        User RegisterUser(RegisterUserDTO registerUserDTO);
    }
}
