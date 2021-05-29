using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _users;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
        }
    }
}
