namespace Bulletinboard.Model
{
    public interface ICommonProperty
    {
        /// <summary>
        /// Define createddate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Define createduserid
        /// </summary>
        public string CreatedUserId { get; set; }

        /// <summary>
        /// Define updatedate
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
    }
}
