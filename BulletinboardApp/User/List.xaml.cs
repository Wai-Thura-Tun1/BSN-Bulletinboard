using System.Windows;
using System.Windows.Controls;

namespace BulletinboardApp.User
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Page
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public List()
        {
            InitializeComponent();
            vm = new UserViewModel();
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private UserViewModel vm;

        /// <summary>
        /// Navigate to user edit page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Clicked(object sender, RoutedEventArgs e)
        {
            UserModel userModel = (UserModel)this.userDataGrid.CurrentItem as UserModel;
            if (userModel != null)
            {
                this.NavigationService.Navigate(new BulletinboardApp.User.Edit(userModel.Id));
            }
        }
    }
}
