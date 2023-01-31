using System.Windows.Controls;

namespace BulletinboardApp.User
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
            vm = new UserViewModel();
            vm.Passed += Vm_Passed;
            vm.CPassed += Vm_CPassed;
            this.DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private UserViewModel vm;

        /// <summary>
        /// Update password
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        private string Vm_Passed()
        {
            return TextPass.Password;
        }

        /// <summary>
        /// Update confirm password
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        private string Vm_CPassed()
        {
            return TextCPass.Password;
        }
    }
}
