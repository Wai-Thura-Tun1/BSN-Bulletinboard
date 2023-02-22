using Bulletinboard.Front.AppControls;
using Bulletinboard.Front.AppLibrary;
using BulletinboardApp.Account;
using BulletinboardApp.ViewModels;
using System;
using System.Windows;

namespace BulletinboardApp.Main
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : iWindow
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Layout()
        {
            InitializeComponent();
            CheckIsAdmin();
            this.DataContext = MainViewModel.Instance;
        }

        /// <summary>
        /// Hide user menu if login user is not admin
        /// </summary>
        private void CheckIsAdmin()
        {
            if(iAppSettings.LoginUser.Id <= 0 || iAppSettings.LoginUser.Role < 1)
            {
                this.menuUserCon.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Navigate to user list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserList_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("User/List.xaml"));
        }

        /// <summary>
        /// Navigate to user create page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateUserBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("User/Create.xaml"));
        }

        /// <summary>
        /// Navigate to post list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostListBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("Post/List.xaml"));
        }

        /// <summary>
        /// Navigate to post create page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePost_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("Post/Create.xaml"));
        }

        /// <summary>
        /// Execute logout function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutBtn_Clicked(object sender, RoutedEventArgs e)
        {
            ExecuteLogout();
        }

        /// <summary>
        /// Execute logout function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupLogout_Clicked(object sender, RoutedEventArgs e)
        {
            ExecuteLogout();
        }

        /// <summary>
        /// Navigate to profile page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("User/Profile.xaml"));
        }

        /// <summary>
        /// Navigate to change password page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePassBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.menuLayout.Navigate(this.CreateUriObject("User/ChangePass.xaml"));
        }

        /// <summary>
        /// Logout
        /// </summary>
        private void ExecuteLogout()
        {
            MessageBoxResult result = iMessage.ShowQuestion(iMessage.MT_0250, iMessage.QMSG_TRAN_POST_3030, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Login login = new();
                login.Show();
                Close();
            }
        }

        private Uri CreateUriObject(string path)
        {
            return new Uri(path,UriKind.Relative);
        }
        
    }
}
