using Bulletinboard.Back.DataAccess;
using Bulletinboard.Back.DataAccess.Data;
using Bulletinboard.CommonLibrary;
using Microsoft.EntityFrameworkCore;
using User = Bulletinboard.Back.DataAccess.Data.User;

namespace DataAccess.Repositories
{
    public class UserRepository
    {
        /// <summary>
        /// Define datacontext for user table
        /// </summary>
        private DataContext<User> _dataContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository()
        {
            _dataContext = new DataContext<User>(new BsnbulletinboardContext());
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// The <see cref="bool"/>
        /// </returns>
        public async Task<bool> LoginAsync(Model.User model)
        {
            try
            {
                var query = await _dataContext.Select(x => x.Email == model.Email && x.IsDeleted == false);
                _dataContext.Dispose();
                if (query != null)
                {
                    bool verifyPass = BCrypt.Net.BCrypt.Verify(model.Password, query.Password);
                    if (verifyPass)
                    {
                        model.Id = query.Id;
                        model.Role = query.Role;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return false;
            }
            
        }

        /// <summary>
        /// fetch user list and filter with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>
        /// The <see cref="Task{List{Model.User}?}"/>
        /// </returns>
        public async Task<List<Model.User>?> GetUserList(string searchString)
        {
            try
            {
                await using var _context = new BsnbulletinboardContext();
                var query = (from u in _context.Users
                             join c in _context.Users on u.CreatedUserId equals c.Id.ToString()
                             where u.IsDeleted == false
                             orderby u.Id descending
                             select new Model.User
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 FullName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 SRole = u.Role == 1 ? "Admin" : "User",
                                 SDob = u.Dob != null ? u.Dob.Value.ToString("MM/dd/yyyy") : "",
                                 SActive = u.IsActive ? "Active" : "InActive",
                                 PhoneNo = u.PhoneNo,
                                 Address = u.Address,
                                 Dob = u.Dob,
                                 Role = u.Role,
                                 IsActive = u.IsActive,
                                 IsDeleted = u.IsDeleted,
                                 CreatedDate = u.CreatedDate,
                                 CreatedUserId = u.CreatedUserId,
                                 CreatedUser = c.FirstName + " " + c.LastName,
                             }).ToList();
                if (!string.IsNullOrEmpty(searchString))
                {
                    string keyword = searchString.ToLower();
                    query = query.Where(x =>
                    x.FullName.ToLower().Contains(keyword) ||
                    x.Email.ToLower().Contains(keyword) ||
                    x.SRole.ToLower().Contains(keyword) ||
                    x.CreatedUser.ToLower().Contains(keyword)).ToList();
                }

                return query;
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new List<Model.User>();
            }

        }

        /// <summary>
        /// get role lists
        /// </summary>
        /// <returns>
        /// The <see cref="Task{List{Model.Role}}"/>
        /// </returns>
        public async Task<List<Model.Role>?> GetRoleList()
        {
            try
            {
                List<Model.Role> roles = new List<Model.Role>();
                Model.Role role1 = new()
                {
                    Id = 0,
                    Name = "User"
                };
                roles.Add(role1);
                Model.Role role2 = new()
                {
                    Id = 1,
                    Name = "Admin"
                };
                roles.Add(role2);
                return roles;
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new List<Model.Role>();
            }
        }

        /// <summary>
        /// Save user data into table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> SaveUser(Model.User obj)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {

                    var exitUser = await _context.Users.Where(x => x.Email == obj.Email).FirstOrDefaultAsync();
                    _dataContext.Dispose();
                    if(exitUser != null)
                    {
                        return iConstance.RESULT_NODATA;
                    }else
                    {
                        User user = CopyClassMember(obj);
                        if (user != null)
                        {
                            _context.Users.Add(user);
                            _context.SaveChanges();
                            return iConstance.RESULT_SUCCESS;
                        }
                    }
                    
                    return iConstance.RESULT_NODATA;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Update user data into table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> UpdateUser(Model.User obj)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {

                    var currentUser = await _dataContext.Select(x => x.Id == obj.Id);
                    _dataContext.Dispose();
                    if(currentUser != null)
                    {
                        currentUser.FirstName = obj.FirstName;
                        currentUser.LastName = obj.LastName;
                        currentUser.Email = obj.Email;
                        currentUser.PhoneNo = obj.PhoneNo;
                        currentUser.Address = obj.Address;
                        currentUser.Dob = iConvert.ToDateTime(obj.SDob);
                        currentUser.Role = obj.Role;
                        currentUser.IsActive = obj.IsActive;
                        currentUser.UpdatedDate = DateTime.Now;
                        currentUser.UpdatedUserId = obj.UpdatedUserId;
                        _context.Users.Update(currentUser);
                        _context.SaveChanges();
                        return iConstance.RESULT_SUCCESS;
                    }
                    return iConstance.RESULT_FAILURE;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> DeleteUser(Model.User obj)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    var deleteUser = await _dataContext.Select(x => x.Id == obj.Id);
                    _dataContext.Dispose();
                    if (deleteUser != null)
                    {
                        deleteUser.IsDeleted = obj.IsDeleted;
                        deleteUser.DeletedDate = DateTime.Now;
                        deleteUser.DeletedUserId = obj.DeletedUserId;
                        _context.Users.Update(deleteUser);
                        _context.SaveChanges();
                        return iConstance.RESULT_SUCCESS;
                    }
                    return iConstance.RESULT_FAILURE;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Get user data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{Model.User}"/>
        /// </returns>
        public async Task<Model.User> GetUserById(int id)
        {
            try
            {
                var query = await _dataContext.Select(x => x.Id == id);
                _dataContext.Dispose();
                if (query != null)
                {
                    Model.User user = new Model.User();
                    user.Id = query.Id;
                    user.FirstName = query.FirstName;
                    user.LastName = query.LastName;
                    user.Email = query.Email;
                    user.Password = query.Password;
                    user.PhoneNo = query.PhoneNo;
                    user.Role = query.Role;
                    user.SRole = query.Role == 1 ? "Admin" : "User";
                    user.Dob = query.Dob;
                    user.Address = query.Address;
                    user.IsActive = query.IsActive;
                    user.IsDeleted = query.IsDeleted;
                    user.CreatedDate = query.CreatedDate;
                    user.CreatedUserId = query.CreatedUserId;
                    return user;
                }
                return new Model.User();
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new Model.User();
            }
        }

        /// <summary>
        /// Change password 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> ChangePassword(Model.User user)
        {
            try
            {
                using (var context = new BsnbulletinboardContext())
                {
                    var currentUser = await _dataContext.Select(x => x.Id == user.Id);
                    _dataContext.Dispose();
                    if (currentUser != null && BCrypt.Net.BCrypt.Verify(user.Password,currentUser.Password) == true)
                    {
                        currentUser.Password = BCrypt.Net.BCrypt.HashPassword(user.NPass);
                        currentUser.UpdatedDate = DateTime.Now;
                        currentUser.UpdatedUserId = user.UpdatedUserId;
                        context.Users.Update(currentUser);
                        context.SaveChanges();
                        return iConstance.RESULT_SUCCESS;
                    }
                    return iConstance.RESULT_FAILURE;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Prepare data for insert and update state
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="User"/>
        /// </returns>
        private User CopyClassMember(Model.User obj)
        {
            User user = new();
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.CreatedDate = obj.CreatedDate;
            user.CreatedUserId = obj.CreatedUserId;
            user.Address = obj.Address;
            user.PhoneNo = obj.PhoneNo;
            user.Role = obj.Role;
            user.Dob = obj.Dob;
            user.IsActive = obj.IsActive;
            user.IsDeleted = false;
            user.UpdatedUserId = obj.UpdatedUserId;
            if(obj.DataStatus == iConstance.DATASTATUS_UPDATE)
            {
                user.UpdatedDate = DateTime.Now;
            }
            else if (obj.DataStatus == iConstance.DATASTATUS_ADD)
            {
                user.CreatedDate = DateTime.Now;
                user.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);
            }
            return user;
        }
    }


}
