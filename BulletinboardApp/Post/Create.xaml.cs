using System.Windows.Controls;

namespace BulletinboardApp.Post
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Create()
        {
            InitializeComponent();
            vm = new PostViewModel();
            this.DataContext = vm;
        }

        private PostViewModel vm;

    }
}
