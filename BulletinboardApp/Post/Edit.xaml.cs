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
        public Edit(int id)
        {
            InitializeComponent();
            vm = new PostViewModel(id);
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private PostViewModel vm;
    }
}
