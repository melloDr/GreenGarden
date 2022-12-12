using GreeenGarden.Business.Model;
using GreeenGarden.Business.Model.CustomerModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeenGarden.Business.Interface
{
    public interface ICustomerService
    {
        Task<ResultModel> getAll();

        Task<ResultModel> createCustomer(CustomerResponeToCreate model, IFormFile imageFile);
        Task<ResultModel> checkToken(string token);
    }
}
