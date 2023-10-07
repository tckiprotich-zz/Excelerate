global using Career_Connect.Contracts.Models;
namespace Career_Connect.Api.Services
{
    public interface ICreateConnectionService
    {
        Task<ServiceResponse<List<ResponseModel>>> CreateConnection(NetworkModel newConnection);
    }
}