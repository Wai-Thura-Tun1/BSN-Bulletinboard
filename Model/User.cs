using Bulletinboard.Model;

namespace Model
{
    public class User : IUser, ICommonProperty
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PhoneNo = string.Empty;
            Address = string.Empty;
            Dob = null;
            Role = 1;
            IsActive = true;
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            CreatedUserId = string.Empty;
            UpdatedDate = null;
            UpdatedUserId = null;
            DeletedDate = null;
            DeletedUserId = null;
            Keyword = string.Empty;
            FullName = string.Empty;
            CreatedUser = string.Empty;
            SRole = string.Empty;
            SDob = string.Empty;
            SActive = string.Empty;
            NPass = string.Empty;
        }

        #region Properties

        /// <summary>
        /// Define id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Define lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Define email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Define password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Define phone
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Define address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Define dob
        /// </summary>
        public DateTime? Dob { get; set; }

        /// <summary>
        /// Define role
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Define isactive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Define isdeleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Define createddate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Define createduserid
        /// </summary>
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Define fullname
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Define createduser
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Define srole
        /// </summary>
        public string SRole { get; set; }

        /// <summary>
        /// Define sdob
        /// </summary>
        public string? SDob { get; set; }

        /// <summary>
        /// Define npass
        /// </summary>
        public string? NPass { get; set; }

        /// <summary>
        /// Define sactive
        /// </summary>
        public string? SActive { get; set; }

        /// <summary>
        /// Define updateddate
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Define updateduserid
        /// </summary>
        public string? UpdatedUserId { get; set; }

        /// <summary>
        /// Define deleteddate
        /// </summary>
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Define deleteduserid
        /// </summary>
        public string? DeletedUserId { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }

        /// <summary>
        /// Define keyword
        /// </summary>
        public string? Keyword { get; set; }
        #endregion

    }
}
