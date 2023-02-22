using Bulletinboard.Model;
using System;

namespace Bulletinboard.Front.AppLibrary.Model
{
    public class User : IUser, ICommonProperty
    {
        /// <summary>
        /// Constructor
        /// </summary>
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User()
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.ConstructModel();
            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="keyword"></param>
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User(string keyword)
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.ConstructModel();
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.Keyword = keyword;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User(string email, string pass)
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.ConstructModel();
            this.Email = email;
            this.Password = pass;
        }

        /// <summary>
        /// Constructor Helper
        /// </summary>
        private void ConstructModel()
        {
            this.Id = 0;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Address = string.Empty;
            this.PhoneNo = string.Empty;
            this.Dob = null;
            this.Role = 0;
            this.IsActive = false;
            this.IsDeleted = false;
            this.CreatedDate = DateTime.Now;
            this.CreatedUserId = string.Empty;
            this.UpdatedDate = null;
            this.UpdatedUserId = null;
            this.DeletedDate = null;
            this.DeletedUserId = null;
            this.FullName = string.Empty;
            this.CreatedUser = string.Empty;
            this.SRole = string.Empty;
            this.SDob = string.Empty;
            this.SActive = string.Empty;
            this.NPass = string.Empty;
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
        /// Define createduser
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Define fullname
        /// </summary>
        public string FullName { get; set; }

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
        /// Define keyword
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }
        #endregion
    }
}
