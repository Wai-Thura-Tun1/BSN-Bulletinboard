using System.Windows.Controls;

namespace BulletinboardApp.User
{
    /// <summary>
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Page
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChangePass()
        {
            InitializeComponent();
            vm = new UserViewModel();
            vm.Passed += Vm_Passed;
            vm.CPassed += Vm_CPassed;
            vm.NPassed += Vm_NPassed;
            this.DataContext = vm;
        }

        /// <summary>
        /// Define vm
        /// </summary>
        private UserViewModel vm;

        /// <summary>
        /// Update new password
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        private string Vm_NPassed()
        {
            return this.newPass.Password;
        }

        /// <summary>
        /// Update confirm password
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        private string Vm_CPassed()
        {
            return this.confirmPass.Password;
        }

        /// <summary>
        /// Update old password
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        private string Vm_Passed()
        {
            return this.oldPass.Password;
        }
    }
}
