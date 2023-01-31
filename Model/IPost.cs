namespace Bulletinboard.Model
{
    public interface IPost
    {
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
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }
    }
}
