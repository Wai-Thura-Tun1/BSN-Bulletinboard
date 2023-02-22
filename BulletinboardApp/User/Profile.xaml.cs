using Bulletinboard.Front.AppLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BulletinboardApp.User
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Profile()
        {
            InitializeComponent();
            this.id = iAppSettings.LoginUser.Id;
            vm = new UserViewModel(this.id);
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private UserViewModel vm;

        /// <summary>
        /// Define id
        /// </summary>
        private int id;

        /// <summary>
        /// Navigate to user edit page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileEditBtn_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["id"] = this.id;
            Uri pathUri = new Uri("User/Edit.xaml", UriKind.Relative);
            this.NavigationService.Navigate(pathUri);
        }
    }
}
