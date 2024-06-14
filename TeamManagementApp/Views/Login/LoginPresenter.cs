using Microsoft.Extensions.Hosting;
using System.Reflection;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Views.Login
{
    public class LoginPresenter(ILoginService loginService, ICurrentUserService currentUserService)
    {
        private ILoginView _view;
        private readonly ILoginService _loginSevice = loginService;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public LoginState State { get; set; } = LoginState.Loading;

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

                await HandleAppVersion();

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
                        _currentUserService.MemberId = loginOut.UserData.UserLogin.MemberId;
                    }
                }
            }
            catch (Exception ex)
            {
                loginOut = new LoginOut()
                {
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
            if (State == LoginState.NotAutorized)
                return;

            State = LoginState.Autorized;
            _view.Close();
        }

        private async Task HandleAppVersion()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var actualVersion = await _loginSevice.GetAppVersion();
            var minVersion = new Version(actualVersion.MinVersion);
            var latestVersion = new Version(actualVersion.LatestVersion);

            if (currentVersion != null)
            {
                if (currentVersion < minVersion)
                {
                    MessageBox.Show("This version is no longer supported. Update needed.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CloseNotAutorized();
                }
                else if (currentVersion != latestVersion)
                {
                    MessageBox.Show("This is not the latest app version.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
