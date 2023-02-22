using Bulletinboard.Model;

namespace Model
{
    public class Post:IPost,ICommonProperty
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Post()
        {
            this.Id = 0;
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.IsPublished = true;
            this.IsDeleted = false;
            this.CreatedDate = DateTime.Now;
            this.CreatedUserId = string.Empty;
            this.UpdatedDate = null;
            this.UpdatedUserId = null;
            this.DeletedDate = null;
            this.DeletedUserId = null;
            this.SPublished = string.Empty;
            this.CreatedAt = null;
            this.CreatedBy = string.Empty;
            this.Keyword = string.Empty;
        }

        /// <summary>
        /// Define id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Define description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Define ispublished
        /// </summary>
        public bool IsPublished { get; set; }

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
        /// Define updateddatae
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
        /// Define spublished
        /// </summary>
        public string SPublished { get; set; }

        /// <summary>
        /// Define createdat
        /// </summary>
        public string? CreatedAt { get; set; }

        /// <summary>
        /// Define createdby
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }

        /// <summary>
        /// Define keyword
        /// </summary>
        public string? Keyword { get; set; }
    }
}
