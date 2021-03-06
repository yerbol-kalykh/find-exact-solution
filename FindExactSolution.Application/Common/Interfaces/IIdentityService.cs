using FindExactSolution.Application.Common.Models;
using FindExactSolution.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<IEnumerable<IUser>> GetAllUsersAsync();

        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
