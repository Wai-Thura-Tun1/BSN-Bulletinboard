using System.Windows.Controls;

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
        /// <param name="id"></param>
        public Edit(int id)
        {
            InitializeComponent();
            vm = new UserViewModel(id);
            this.DataContext = vm;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        private UserViewModel vm;

        
    }
}
