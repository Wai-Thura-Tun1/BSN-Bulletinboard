namespace Bulletinboard.Back.DataAccess
{
    public class iConstance
    {
    
        /// <summary>
        /// Define enum for data status
        /// </summary>
        enum DataStatus
        {
            None = 0,
            Add = 1,
            Update = 2,
            Delete = 3
        }

        /// <summary>
        /// Define result for no data
        /// </summary>
        public const int RESULT_NODATA = 0;
         
        /// <summary>
        /// Define result for success
        /// </summary>
        public const int RESULT_SUCCESS = 1;

        /// <summary>
        /// Define result for failure
        /// </summary>
        public const int RESULT_FAILURE = 3;

        /// <summary>
        /// Define datastatus for none
        /// </summary>
        public const int DATASTATUS_NONE = (int)DataStatus.None;

        /// <summary>
        /// Define datastatus for add
        /// </summary>
        public const int DATASTATUS_ADD = (int)DataStatus.Add;

        /// <summary>
        /// Define datastatus for update
        /// </summary>
        public const int DATASTATUS_UPDATE = (int)DataStatus.Update;

        /// <summary>
        /// Define datastatus for delete
        /// </summary>
        public const int DATASTATUS_DELETE = (int)DataStatus.Delete;
    }
}
