using GreeenGarden.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeenGarden.Business.Interface
{
    public interface ICustomerExample
    {
        Task<ResultModel> test();
    }
}
