using System;
using System.Windows;
using System.Windows.Controls;

namespace BulletinboardApp.Post
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
            vm = new PostViewModel();
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private PostViewModel vm;

        /// <summary>
        /// Navigate to post edit page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostEditBtn_Clicked(object sender, RoutedEventArgs e)
        {
            if (postDataGrid.CurrentItem is PostModel postModel)
            {
                Application.Current.Properties["id"] = postModel.Id;
                Uri pathUri = new Uri("../Post/Edit.xaml",UriKind.Relative);
                this.NavigationService.Navigate(pathUri);
            }
        }
    }
}
