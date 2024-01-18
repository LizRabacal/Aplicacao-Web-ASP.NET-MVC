using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRABALHOELETROPONTO.Services
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync();
        Task SeedUsersAsync();
    }
}