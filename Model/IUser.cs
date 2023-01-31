namespace Bulletinboard.Model
{
    public interface IUser
    {
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
        /// Define isdelete
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }
    }
}
