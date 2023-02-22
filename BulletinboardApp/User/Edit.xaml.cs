using Microsoft.AspNetCore.Components.Routing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BulletinboardApp.User
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
      
        /// <summary>
        /// Constructor
        /// </summary>
        public Edit()
        {
            InitializeComponent();
            int id = (int)Application.Current.Properties["id"];
            vm = new UserViewModel(id);
            this.DataContext = vm;

        }


        /// <summary>
        /// Constructor
        /// </summary>
        private UserViewModel vm;

        
    }
}
