using Bulletinboard.Model;
using System;

namespace Bulletinboard.Front.AppLibrary.Model
{
    public class Post : IPost, ICommonProperty
    {
        /// <summary>
        /// Constructor
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Post() => this.ConstructModel();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="search"></param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Post(string? search)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.ConstructModel();
            this.Keyword = search;
        }

        /// <summary>
        /// Constructor Helper
        /// </summary>
        private void ConstructModel()
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
        /// Define keyword
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }
    }

}
