using AutoMapper;
using GreeenGarden.Business.Interface;
using GreeenGarden.Business.Utilities;
using GreeenGarden.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeenGarden.Business.Service
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly GreenGardenDbContext _context;
        public LoginService(IMapper mapper, GreenGardenDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Customer AuthenticateUser(string userName, string password)
        {
            var passwordToLogin = CustomerUtil.GetMD5(password);
            var Customer = _context.Customers.Where(x => x.UserName == userName && x.Password == passwordToLogin && x.StatusId == Guid.Parse("679b6de9-ccbb-4fa3-bdcc-3120fd4dddec")).FirstOrDefault();
            return Customer;
        }
    }
}
