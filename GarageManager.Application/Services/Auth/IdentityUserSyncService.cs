using GarageManager.Application.DTOs.Account;
using GarageManager.Application.Interfaces;
using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Application.Wrappers;
using GarageManager.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Application.Services.Auth
{
    public class IdentityUserSyncService : IIdentityUserSyncService
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public IdentityUserSyncService(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<bool>> SyncUserToApplication(RegisterRequest registerRequest, string userId)
        {
            User user = new User();
            user.Id = Guid.Parse(userId);
            user.FirstName = registerRequest.FirstName;
            user.LastName = registerRequest.LastName;
            user.Email = registerRequest.Email;

            await _userRepositoryAsync.AddAsync(user);
            return new Response<bool>(true);
        }
    }
}
