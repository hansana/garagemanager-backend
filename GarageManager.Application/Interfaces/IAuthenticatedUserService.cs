using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
