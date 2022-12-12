using AutoMapper;
using GreeenGarden.Business.Model;
using GreeenGarden.Business.Model.CustomerModel;
using GreeenGarden.Business.Utilities;
using GreeenGarden.Business.Interface;
using GreeenGarden.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeenGarden.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly GreenGardenDbContext _context;
        public CustomerService(IMapper mapper, GreenGardenDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ResultModel> getAll()
        {
            var result = new ResultModel(); 
            try
            {
                var listCustomerToShow = _context.Customers.ToList();
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

        public async Task<ResultModel> createCustomer(CustomerResponeToCreate model, IFormFile imageFile)
        {
            var result = new ResultModel();
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var checkMail = _context.Customers.Where(e => e.Email.Equals(model.Email)).FirstOrDefault();
                var checkPhone = _context.Customers.Where(e => e.Phone.Equals(model.Phone)).FirstOrDefault();
                var checkUserName = _context.Customers.Where(e => e.UserName.Equals(model.UserName)).FirstOrDefault();
                bool checkMailValid = CustomerUtil.IsValidEmail(model.Email);
                bool checkPhoneValid = CustomerUtil.IsValidPhone(model.Phone);
                bool checkUserNameValid = CustomerUtil.IsValidUserName(model.UserName);
                bool checkFullNamaValid = CustomerUtil.IsValidFullName(model.FullName);
                bool checkPasswordValid = CustomerUtil.checkPasswordValid(model.Password);

                if (checkMailValid == false)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Mail invalid!";
                    return result;
                }
                if (checkPhoneValid == false)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Phone invalid!";
                    return result;
                }
                if (checkUserNameValid == false)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Username invalid!";
                    return result;
                }
                if (checkFullNamaValid == false)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Full name invalid!";
                    return result;
                }
                if (checkPasswordValid == false)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Password must have 1 uppercase letter, 1 number, 1 special character \"!@#$%^&*()\", and from 8-20 characters!";
                    return result;
                }
                if (checkUserName != null)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Username already exists!";
                    return result;
                }
                if (checkMail != null)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Mail already exists!";
                    return result;
                }
                if (checkPhone != null)
                {
                    await transaction.RollbackAsync();
                    result.Code = 400;
                    result.IsSuccess = false;
                    result.ResponseFailed = "Phone already exists!";
                    return result;
                }

                var newCustomer = new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    UserName = model.UserName,
                    Password = CustomerUtil.GetMD5(model.Password),
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    ImageId = Guid.Parse("4a11b7d1-575e-4bc9-a9c1-bb1fb52bc529"),
                    StatusId = Guid.Parse("679b6de9-ccbb-4fa3-bdcc-3120fd4dddec"),
                    FullName = model.FullName,
                };

                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();

                result.Code = 200;
                result.IsSuccess = true;
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Code = 400;
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }

        public async Task<ResultModel> checkToken(string token)
        {
            var result = new ResultModel(); 
            /*Guid currentUserId = Guid.Parse(HttpContext);
            string userId = currentUser.FindFirst("UserId").Value;



            result.Code = 200;
            result.IsSuccess = true;
            result.ResponseSuccess = userId;*/

            return result;
        }
    }
}
