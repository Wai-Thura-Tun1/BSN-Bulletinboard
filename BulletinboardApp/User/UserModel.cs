using Bulletinboard.Model;
using OfficeOpenXml.ExternalReferences;
using System;
using System.ComponentModel;

namespace BulletinboardApp.User
{
    public class UserModel : IUser, INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserModel()
        {
            this.Id = 0;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.PhoneNo = string.Empty;
            this.Address = string.Empty;
            this.Dob = null;
            this.Role = 0;
            this.IsActive = false;
            this.IsDeleted = false;
            this.SCreatedDate = string.Empty;
            this.CreatedUser = string.Empty;
            this.SRole = string.Empty;
            this.SDob = string.Empty;
            this.FullName = string.Empty;
            this.SActive = string.Empty;
            this.NewPassword = string.Empty;
        }

        /// <summary>
        /// Define id
        /// </summary>
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Define fullname
        /// </summary>
        private string? _fullname;
        public string? FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
                OnPropertyChanged("FullName");
            }
            
        }

        /// <summary>
        /// Define srole
        /// </summary>
        private string? _srole;
        public string? SRole
        {
            get
            {
                return _srole;
            }
            set
            {
                _srole = value;
                OnPropertyChanged("SRole");
            }
        }

        /// <summary>
        /// Define screateddate
        /// </summary>
        private string? _screateddate;
        public string? SCreatedDate
        {
            get
            {
                return _screateddate;
            }
            set
            {
                _screateddate = value;
                OnPropertyChanged("SCreatedDate");
            }
        }

        /// <summary>
        /// Define sdob
        /// </summary>
        private string? _sdob;
        public string? SDob
        {
            get
            {
                return _sdob;
            }
            set
            {
                _sdob = value;
                OnPropertyChanged("SDob");
            }
        }

        /// <summary>
        /// Define createduser
        /// </summary>
        private string? _createduser;
        public string? CreatedUser
        {
            get
            {
                return _createduser;
            }
            set
            {
                _createduser = value;
                OnPropertyChanged("CreatedUser");
            }
        }

        /// <summary>
        /// Define sactive
        /// </summary>
        private string? _sactive;
        public string? SActive
        {
            get
            {
                return _sactive;
            }
            set
            {
                _sactive = value;
                OnPropertyChanged("SActive");
            }
        }

        /// <summary>
        /// Define firstname
        /// </summary>
        private string _firstname;
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Define lastname
        /// </summary>
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Define email
        /// </summary>
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Define password
        /// </summary>
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Define cpassword
        /// </summary>
        private string _cpassword;
        public string CPassword
        {
            get
            {
                return _cpassword;
            }
            set
            {
                _cpassword = value;
                OnPropertyChanged(nameof(CPassword));
            }
        }

        /// <summary>
        /// Define new password
        /// </summary>
        private string _newpassword;
        public string NewPassword
        {
            get
            {
                return _newpassword;
            }
            set
            {
                _newpassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }


        /// <summary>
        /// Define phoneno
        /// </summary>
        private string _phoneno;
        public string PhoneNo
        {
            get
            {
                return _phoneno;
            }
            set
            {
                _phoneno = value;
                OnPropertyChanged("PhoneNo");
            }
        }

        /// <summary>
        /// Define address
        /// </summary>
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Define dob
        /// </summary>
        private DateTime? _dob;
        public DateTime? Dob
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }

        /// <summary>
        /// Define role
        /// </summary>
        private int _role;
        public int Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }

        /// <summary>
        /// Define isactive
        /// </summary>
        private bool _isactive;
        public bool IsActive
        {
            get
            {
                return _isactive;
            }
            set
            {
                _isactive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// DEfine isdeleted
        /// </summary>
        private bool _isdeleted;
        public bool IsDeleted
        {
            get
            {
                return _isdeleted;
            }
            set
            {
                _isdeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
        
        /// <summary>
        /// Define keyword
        /// </summary>
        private string? _keyword;
        public string? Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(Keyword));
            }
        }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }

        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invoke property change
        /// </summary>
        /// <param name="parameter"></param>
        public void OnPropertyChanged(string parameter)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(parameter));
            }
        }
    }
}
