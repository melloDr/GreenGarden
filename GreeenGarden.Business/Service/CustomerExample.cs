using GreeenGarden.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreeenGarden.Business.Interface;
using GreeenGarden.Data.Entities;
using AutoMapper;

namespace GreeenGarden.Business.Service
{
    public class CustomerExample : ICustomerExample
    {
        private readonly IMapper _mapper;
        private readonly GreenGardenDbContext _context;
        public CustomerExample(IMapper mapper, GreenGardenDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ResultModel> test()
        {
            var result = new ResultModel();
            try
            {
                var listCustomerToShow = "HelloBros";
                if (listCustomerToShow == null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.ResponseFailed = "list null";
                    return result;
                }
                result.IsSuccess = true;
                result.Code = 200;
                result.ResponseSuccess = listCustomerToShow;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Code = 400;
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }
    }
}
