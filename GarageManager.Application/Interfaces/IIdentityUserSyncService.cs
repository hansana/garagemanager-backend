using GarageManager.Application.DTOs.Account;
using GarageManager.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Application.Interfaces
{
    public interface IIdentityUserSyncService
    {
        Task<Response<bool>> SyncUserToApplication(RegisterRequest registerRequest, string userId);
    }
}
