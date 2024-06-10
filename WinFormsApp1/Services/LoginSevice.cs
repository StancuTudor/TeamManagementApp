using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface ILoginService
    {
        Task<LoginOut> Login(string user, string password);
    }

    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginOut> Login(string user, string password)
        {
            var resultUserData = new ValidateUserOut()
            {
                UserLogin = null,
                Result = string.Empty,
                StatusCode = ValidationStatusCode.Loading
            };

            var loginUserResult = await _loginRepository.GetUserLogin(user, password);
            
            // User or password not found.
            if (loginUserResult == null)
            {
                resultUserData.Result = "Invalid username or password.";
                resultUserData.StatusCode = ValidationStatusCode.Failed;
                return new LoginOut()
                {
                    UserData = resultUserData
                };
            }

            // Null password. Updating the new password, then log in.
            if (string.IsNullOrEmpty(loginUserResult.Password))
            {
                await _loginRepository.UpdateUserPassword(loginUserResult.UserId, password);
            }
            // Case sensitive check.
            else
            {
                if (loginUserResult.Password != password)
                {
                    resultUserData.Result = "Invalid username or password.";
                    resultUserData.StatusCode = ValidationStatusCode.Failed;
                    return new LoginOut()
                    {
                        UserData = resultUserData
                    };
                }
            }

            // Log in.
            resultUserData.UserLogin = loginUserResult;
            resultUserData.StatusCode = ValidationStatusCode.Success;
            return new LoginOut()
            {
                UserData = resultUserData
            };
        }
    }
}
