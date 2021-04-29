using FindExactSolution.Web.Client.Common.Resources.Registrations;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IRegistrationService
    {
        Task CreateRegistrationAsync(CreateRegistrationResource resource);
    }
}
