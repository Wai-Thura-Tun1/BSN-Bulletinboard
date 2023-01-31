using Bulletinboard.Front.AppControls;
using Bulletinboard.Front.AppLibrary;
using BulletinboardApp.Main;
using System.Windows.Input;

namespace BulletinboardApp.Account
{
    public class LoginViewModel : iViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel()
        {
            webApi = new iServiceSystem();
            this.WindowLoaded = new iDelegateCommand((object? arg) =>
            {
                this.InitializeWindow();
            },
            () => true);

            this.WindowClosed = new iDelegateCommand((object? arg) =>
            {
                webApi.Dispose();
                this.ParentForm = null;
            },
            () => true);
            this.LoginCommand = new iDelegateCommand(
            (object? arg) =>
            {
                this.Login();
                
            },
            () => true);
           
        }

        /// <summary>
        /// Define email
        /// </summary>
        private string _email = string.Empty;
        public string Email {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                this.OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Define password
        /// </summary>
        private string _password = string.Empty;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                this.OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Define webApi
        /// </summary>
        private iServiceSystem webApi;

        /// <summary>
        /// Define login command
        /// </summary>
        public iDelegateCommand LoginCommand { get; set; }

        /// <summary>
        /// login delegate
        /// </summary>
        /// <returns></returns>
        public delegate string LoginEventHandler();

        /// <summary>
        /// Login event
        /// </summary>
        public event LoginEventHandler? Logined;

        /// <summary>
        /// Login user
        /// </summary>
        private async void Login()
        {
            if (this.Logined != null)
            {
                this.Password = this.Logined.Invoke();
            }
            Mouse.OverrideCursor = Cursors.Wait;
            Bulletinboard.Front.AppLibrary.Model.User? result = await this.webApi.LoginAsync(this.Email, this.Password);
            Mouse.OverrideCursor = null;
            if (result == null || result.Id <= 0)
            {
                iMessage.ShowWarning(iMessage.MT_0150, iMessage.WMSG_SYS_0150);
            }
            else
            {
                iAppSettings.LoginUser.Id = result.Id;
                iAppSettings.LoginUser.Email = result.Email;
                iAppSettings.LoginUser.Role = result.Role;

                Layout layout = new Layout();
                layout.Show();
                this.ParentForm?.Close();
            }
        }

        /// <summary>
        /// Initialize window
        /// </summary>
        private void InitializeWindow()
        {
            this.clearData();
        }

        /// <summary>
        /// Clear email and password input
        /// </summary>
        private void clearData()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        
    }
}
