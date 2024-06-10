using TeamManagementApp.Services;
using TeamManagementApp.Utils;
using TeamManagementApp.Models;
using Refit;

namespace TeamManagementApp.Views.Login
{
    public class LoginPresenter(ILoginService loginService, ICurrentUserService currentUserService)
    {
        private ILoginView _view;
        private readonly ILoginService _loginSevice = loginService;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public LoginState State { get; set; } = LoginState.NotAutorized;

        public void SetView(ILoginView view)
        {
            _view = view;
        }
        public async Task Login()
        {
            try
            {
                ValidateForm();
                var result = await GetStatusLogin(_view.User, _view.Password);
                ValidateResult(result);

                CloseAutorized();
            }
            catch (ValidationException ex)
            {
                _view.Error = ex.Message;
            }
            catch (Exception ex)
            {
                _view.Error = ex.Message;
            }
        }
        private void ValidateForm()
        {
            _view.User = _view.User.Trim();
            _view.Password = _view.Password.Trim();

            if (string.IsNullOrEmpty(_view.User))
            {
                throw new ValidationException("Username can't be empty.");
            }
            if (string.IsNullOrEmpty(_view.Password))
            {
                throw new ValidationException("Password can't be empty.");
            }
        }
        private void ValidateResult(ValidateUserOut result)
        {
            if (result.StatusCode != ValidationStatusCode.Success)
            {
                throw new ValidationException(result.Result);
            }
        }
        private async Task<ValidateUserOut> GetStatusLogin(string user, string password)
        {
            LoginOut loginOut = new LoginOut();
            try
            {
                loginOut = await _loginSevice.Login(user, password);

                if (loginOut.UserData.StatusCode == ValidationStatusCode.Success)
                {
                    if (loginOut.UserData.UserLogin != null)
                    {
                        _currentUserService.UserId = loginOut.UserData.UserLogin.UserId;
                        _currentUserService.UserName = loginOut.UserData.UserLogin.UserName;
                    }
                }
            }
            catch (Exception ex)
            {
                loginOut = new LoginOut() { 
                    UserData = new ValidateUserOut()
                    {
                        UserLogin = null,
                        Result = ex.Message,
                        StatusCode = ValidationStatusCode.Failed
                    }
                };
            }
            return loginOut.UserData;
        }

        public void CloseNotAutorized()
        {
            State = LoginState.NotAutorized;
            _view.Close();
        }

        public void CloseAutorized()
        {
            State = LoginState.Autorized;
            _view.Close();
        }
    }
}
