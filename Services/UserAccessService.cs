﻿using AutoMapper;
using Phantom.API.Common.Helpers;
using Phantom.API.IRepository;
using Phantom.API.IServices;
using Phantom.API.Model;
using Phantom.API.Model.Dto;
using System.Security.Cryptography;

namespace Phantom.API.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IUserAccessRepository _accessRepository;
        private readonly IBaseResponse<object> _baseResponse;
        private readonly IMapper _mapper;

        public UserAccessService(IUserAccessRepository accessRepository, IBaseResponse<object> baseResponse, IMapper mapper)

        {
            _accessRepository = accessRepository;
            _baseResponse = baseResponse;
            _mapper = mapper;
        }
        /// <summary>
        /// Registers a neew customer 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponseVm<object>> RegisterCustomer(RegisterCustomerDto model)
        {
            try
            {
                //check if email is in the right format
                var EmailValidate = _accessRepository.ValidateEmail(model.Email);

                if (!EmailValidate.Success)
                    return await _baseResponse.CustomErroMessage("Invalid Email", "400");

                //check if email or number already exist
                var EmailExist = _accessRepository.EmailExist(model.Email);

                if (EmailExist)
                {
                    return await _baseResponse.CustomErroMessage("Email already Exist", "400");
                }

                //check if Number exist
                var NumberExist = _accessRepository.NumberExist(model.WhatsappNumber);

                if (NumberExist)
                {
                    return await _baseResponse.CustomErroMessage("PhoneNumber already Exist", "400");
                }


                var account = _mapper.Map<Customer>(model);

                using (var hmac = new HMACSHA512())
                {
                    var PasswordSalt = hmac.Key;
                    byte[] hashP = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                    account.PasswordHash = hashP.ToString();
                }
                account.OTP = "0786";
                account.AuthorizedBy = "system";
                account.OTPExpiry = DateTimeOffset.Now;
                account.isAuthorized = false;
                account.isVerified = false;
                account.UpdatedDate = DateTimeOffset.Now;
                account.ResetToken = "";
                account.LastPasswordChange = DateTimeOffset.Now;
                account.VerificationToken = "";

                var saveuser = await _accessRepository.CreateCustomerAccountAsync(account);

                if (saveuser == null)
                {
                    return await _baseResponse.CustomErroMessage("Customer creation failed. Try again later!", "400");
                }

                return await _baseResponse.CustomErroMessage("Registration Successful.", "201");


            }
            catch (Exception ex)
            {
                return await Task.FromResult(new BaseResponseVm<object>());
            }
        }

        public async Task<BaseResponseVm<object>> ResetPassword(PasswordResetDto model, string token)
        {
            try
            {

                if (model.NewPassword != model.ConfirmPassword)
                {
                    return await _baseResponse.CustomErroMessage("The Passwords does not match", "400");
                }

                var EmailExist = _accessRepository.EmailExist(model.Email);

                if (!EmailExist)
                {
                    return await _baseResponse.CustomErroMessage("Account Does Not Exist", "400");
                }

                //vallidate token 
                var validateToken = _accessRepository.ValidateToken(token);
                if (!validateToken)
                {
                    return await _baseResponse.CustomErroMessage("Invalid Token", "400");
                }

                var reset = _accessRepository.CreateNewPassword(model.NewPassword);

                return await _baseResponse.CustomErroMessage("Registration Successful.", "201");

            }
            catch (Exception)
            {

                return await Task.FromResult(new BaseResponseVm<object>());
            }
        }
    }
}
