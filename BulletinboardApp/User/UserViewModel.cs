using AppLibrary;
using AppLibrary.WebServiceInterface;
using Bulletinboard.CommonLibrary;
using Bulletinboard.Front.AppControls;
using Bulletinboard.Front.AppLibrary;
using AppModel = Bulletinboard.Front.AppLibrary.Model;
using Bulletinboard.Model;
using BulletinboardApp.ViewModels;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BulletinboardApp.User
{
    public class UserViewModel : iViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserViewModel()
        {
            User = new();
            UserList = new ObservableCollection<UserModel>();
            RoleList = new ObservableCollection<RoleModel>();
            Initialized();
            this.GetUserList();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public UserViewModel(int id)
        {
            User = new();
            RoleList = new ObservableCollection<RoleModel>();
            Initialized();
            GetUserById(id);
        }

        /// <summary>
        /// Define user list
        /// </summary>
        public ObservableCollection<UserModel> UserList { get; set; }

        /// <summary>
        /// Define role list
        /// </summary>
        public ObservableCollection<RoleModel> RoleList { get; set; }

        /// <summary>
        /// Define user
        /// </summary>
        public UserModel User { get; set; }

        #region Delegate Command

        /// <summary>
        /// Define search command
        /// </summary>
        public iDelegateCommand? Search { get; set; }

        /// <summary>
        /// Define save command
        /// </summary>
        public iDelegateCommand? Save { get; set; }

        /// <summary>
        /// Define cancel command
        /// </summary>
        public iDelegateCommand? Cancel { get; set; }

        /// <summary>
        /// Define create command
        /// </summary>
        public iDelegateCommand? Create { get; set; }

        /// <summary>
        /// Define delete command
        /// </summary>
        public iDelegateCommand? Delete { get; set; }

        /// <summary>
        /// Define change command
        /// </summary>
        public iDelegateCommand? Change { get; set; }
        #endregion

        #region Password Box Delegates

        /// <summary>
        /// Old password delegate
        /// </summary>
        /// <returns></returns>
        public delegate string PassEventHandler();

        /// <summary>
        /// Old password event
        /// </summary>
        /// <returns></returns>
        public event PassEventHandler? Passed;

        /// <summary>
        /// Confirm password delegate
        /// </summary>
        /// <returns></returns>
        public delegate string CPassEventHandler();

        /// <summary>
        /// Confirm password event
        /// </summary>
        /// <returns></returns>
        public event CPassEventHandler? CPassed;

        /// <summary>
        /// New password delegate
        /// </summary>
        /// <returns></returns>
        public delegate string NPassEventHandler();

        /// <summary>
        /// New password event
        /// </summary>
        /// <returns></returns>
        public event NPassEventHandler? NPassed;
        #endregion

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialized()
        {
            this.Search = new iDelegateCommand(
                (object? arg) =>
                {
                    this.GetUserList();
                }, () => true);
            this.Create = new iDelegateCommand(
                (object? arg) =>
                {
                    MainViewModel.Instance.PagePath = iNavigation.USER_CREATE;
                }, () => true);
            this.Save = new iDelegateCommand(
                (object? arg) =>
                {
                    this.OnSave();
                    this.SaveAsync();
                }, () => true);
            this.Cancel = new iDelegateCommand(
                (object? arg) =>
                {
                    this.validatePage();
                },() => true);
            this.Delete = new iDelegateCommand(
                (object? arg) =>
                {
                    this.DeleteUser(iConvert.ToInt(arg));
                }, () => true);
            this.Change = new iDelegateCommand(
                (object? arg) =>
                {
                    this.ChangePassword();
                }, () => true);
            this.GetRoleList();
        }

        /// <summary>
        /// Update all passwords 
        /// </summary>
        private void OnSave()
        {
            if (this.Passed != null)
            {
                User.Password = this.Passed.Invoke();
            }
            if (this.CPassed != null)
            {
                User.CPassword = this.CPassed.Invoke();
            }
            if(this.NPassed != null)
            {
                User.NewPassword = this.NPassed.Invoke();
            }
        }

        /// <summary>
        /// Delete user data by id
        /// </summary>
        /// <param name="id"></param>
        private async void DeleteUser(int id)
        {
            MessageBoxResult result = iMessage.ShowQuestion(iMessage.MT_0180,iMessage.QMSG_TRAN_USER_3010,MessageBoxResult.Cancel);
            if(result == MessageBoxResult.Yes)
            {
                using (var webApi = new iServiceUser())
                {
                    AppModel.User data = new();
                    data.Id = id;
                    data.IsDeleted = true;
                    data.DeletedUserId = iConvert.ToString(iAppSettings.LoginUser.Id);
                    int resultStatus = await webApi.UpdateAsync(data, "DeleteUser");
                    if (resultStatus == iConstance.APIRESULT_SUCCESS)
                    {
                        iMessage.ShowInfomation(iMessage.MT_0180, iMessage.IMSG_TRAN_0080);
                        this.GetUserList();
                    }
                    else
                    {
                        iMessage.ShowError(iMessage.MT_0180, iMessage.EMSG_TRAN_0130);
                    }
                }
            }
            
        }

        /// <summary>
        /// Change password
        /// </summary>
        private async void ChangePassword()
        {
            this.OnSave();
            bool validate = true;
            if(string.IsNullOrEmpty(User.Password))
            {
                validate = false;
                iMessage.ShowWarning(iMessage.MT_0240,iMessage.WMSG_TRAN_U_2200);
            }
            else if (string.IsNullOrEmpty(User.NewPassword))
            {
                validate = false;
                iMessage.ShowWarning(iMessage.MT_0240,iMessage.WMSG_TRAN_U_2210);
            }
            else if (string.IsNullOrEmpty(User.CPassword))
            {
                validate = false;
                iMessage.ShowWarning(iMessage.MT_0240,iMessage.WMSG_TRAN_U_2220);
            }
            else if (User.NewPassword != User.CPassword)
            {
                validate = false;
                iMessage.ShowWarning(iMessage.MT_0240,iMessage.WMSG_TRAN_U_2230);
            }

            if(validate)
            {
                using(var webApi = new iServiceUser())
                {
                    AppModel.User user = new();
                    user.Id = iAppSettings.LoginUser.Id;
                    user.NPass = User.NewPassword;
                    user.Password = User.Password;
                    user.UpdatedUserId = iConvert.ToString(iAppSettings.LoginUser.Id);
                    int result = await webApi.UpdateAsync(user, "ChangePassword");
                    if(result == iConstance.APIRESULT_SUCCESS)
                    {
                        iMessage.ShowInfomation(iMessage.MT_0240,iMessage.IMSG_TRAN_0140);
                        validatePage();
                    }
                    else
                    {
                        iMessage.ShowError(iMessage.MT_0240,iMessage.EMSG_TRAN_0190);
                    }
                }
            }

        }

        /// <summary>
        /// Get all user data
        /// </summary>
        private async void GetUserList()
        {
            UserList.Clear();
            using(var webApi = new iServiceUser())
            {
                var getData = await webApi.GetAllAsync(User.Keyword);
                UserModel user;
                if (getData.Count > 0)
                {
                    foreach (var data in getData)
                    {
                        user = new UserModel();
                        iConvert.CopyClassProperty<IUser>(data, user);
                        UserList.Add(user);
                    }
                }
            }
            
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        private async void GetRoleList()
        {
            RoleList.Clear();
            using(var webApi = new iServiceUser())
            {
                var roleData = await webApi.GetRoleAsync();
                RoleModel role;
                if (roleData.Count > 0)
                {
                    foreach (var data in roleData)
                    {
                        role = new RoleModel();
                        iConvert.CopyClassProperty<IRole>(data, role);
                        RoleList.Add(role);
                    }
                }
                
            }
        }

        /// <summary>
        /// Get user data by id
        /// </summary>
        /// <param name="id"></param>
        private async void GetUserById(int id)
        {
            using(var webApi = new iServiceUser())
            {
                var userModel = await webApi.GetUserById(id);
                iConvert.CopyClassProperty<IUser>(userModel,User);
                User.SDob = iConvert.ToDateFormat(userModel.Dob);
            }
        }

        /// <summary>
        /// Save,Update by checking id
        /// </summary>
        private async void SaveAsync()
        {
            if(CheckInput()) {
                Mouse.OverrideCursor = Cursors.Wait;
                using var webApi = new iServiceUser();
                if (User.Id <= 0)
                {
                    AppModel.User data = new();
                    iConvert.CopyClassProperty<IUser>(User, data);
                    data.Dob = iConvert.ToDateTime(User.SDob);
                    data.CreatedUserId = iConvert.ToString(iAppSettings.LoginUser.Id);
                    data.DataStatus = iConstance.DATASTATUS_ADD;
                    int result = await webApi.UpdateAsync(data, "SaveUser");
                    Mouse.OverrideCursor = null;
                    if (result == iConstance.APIRESULT_SUCCESS)
                    {
                        iMessage.ShowInfomation(iMessage.MT_0160, iMessage.IMSG_TRAN_0060);
                        validatePage();
                    }
                    else if (result == iConstance.APIRESULT_NONEDATA)
                    {
                        iMessage.ShowWarning(iMessage.MT_0160, iMessage.WMSG_TRAN_U_2240);
                    }
                    else
                    {
                        iMessage.ShowError(iMessage.MT_0160, iMessage.EMSG_TRAN_0110);
                    }
                }
                else
                {
                    AppModel.User data = new();
                    iConvert.CopyClassProperty<IUser>(User, data);
                    data.Dob = iConvert.ToDateTime(User.SDob);
                    data.UpdatedUserId = iConvert.ToString(iAppSettings.LoginUser.Id);
                    int result = await webApi.UpdateAsync(data, "UpdateUser");
                    Mouse.OverrideCursor = null;
                    if (result == iConstance.APIRESULT_SUCCESS)
                    {
                        iMessage.ShowInfomation(iMessage.MT_0170, iMessage.IMSG_TRAN_0070);
                        validatePage();
                    }
                    else
                    {
                        iMessage.ShowError(iMessage.MT_0170, iMessage.EMSG_TRAN_0120);
                    }
                }
            }
            
        }

        /// <summary>
        /// Check user role before navigate
        /// </summary>
        private void validatePage()
        {
            if (iConvert.ToInt(iAppSettings.LoginUser.Role) == 1)
            {
                MainViewModel.Instance.PagePath = iNavigation.USER_LIST;
            }
            else
            {
                MainViewModel.Instance.PagePath = iNavigation.POST_LIST;
            }
        }

        /// <summary>
        /// Validate inputs
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool inputResult = true;
            string mtString = User.Id > 0 ? iMessage.MT_0170 : iMessage.MT_0160;
            if (string.IsNullOrEmpty(User.FirstName))
            {
                iMessage.ShowWarning(mtString,iMessage.WMSG_TRAN_U_2090);
                inputResult = false;
            }
            else if (string.IsNullOrEmpty(User.LastName))
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2100);
                inputResult = false;
            }

            else if (string.IsNullOrEmpty(User.Email))
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2110);
                inputResult = false;
            }
            else if (string.IsNullOrEmpty(User.Password) && User.Id <= 0)
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2120);
                inputResult = false;
            }
            else if (string.IsNullOrEmpty(User.CPassword) && User.Id <= 0)
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2130);
                inputResult = false;
            }
            else if (!string.IsNullOrEmpty(User.CPassword) && !string.IsNullOrEmpty(User.Password) && User.Id <= 0 && User.Password != User.CPassword)
            {
                iMessage.ShowWarning(mtString,iMessage.WMSG_TRAN_U_2170);
                inputResult = false;
            }
            else if (string.IsNullOrEmpty(User.PhoneNo))
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2140);
                inputResult = false;
            }
            else if (string.IsNullOrEmpty(User.SDob))
            {
                iMessage.ShowWarning(mtString,iMessage.WMSG_TRAN_U_2150);
            }
            else if (string.IsNullOrEmpty(User.Address))
            {
                iMessage.ShowWarning(mtString, iMessage.WMSG_TRAN_U_2160);
                inputResult = false;
            }
            return inputResult;

        }
    }
}
