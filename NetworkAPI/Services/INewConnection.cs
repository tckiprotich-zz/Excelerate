using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkAPI.Services
{
    public interface INewConnection
    {
        Task<ServiceResponse<List<ResponseModel>>> CreateConnection(NetworkModel newConnection);
        
    }
}