using System.Windows;
using System.Windows.Controls;

namespace BulletinboardApp.Post
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
        public Edit()
        {
            InitializeComponent();
            int id = (int)Application.Current.Properties["id"];
            vm = new PostViewModel(id);
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private PostViewModel vm;
    }
}
