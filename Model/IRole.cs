namespace Model
{
    public interface IRole
    {
        /// <summary>
        /// Define id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }
    }
}
