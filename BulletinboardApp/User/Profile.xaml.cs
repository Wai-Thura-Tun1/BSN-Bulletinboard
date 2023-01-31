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
        /// <param name="id"></param>
        public Profile(int id)
        {
            InitializeComponent();
            this.id = id;
            vm = new UserViewModel(id);
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
            this.NavigationService.Navigate(new BulletinboardApp.User.Edit(id));
        }
    }
}
