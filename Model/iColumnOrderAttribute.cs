namespace Bulletinboard.Model
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class iColumnOrderAttribute: Attribute
    {
        /// <summary>
        /// Define Index
        /// </summary>
        private readonly int Index;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index"></param>
        public iColumnOrderAttribute(int index)
        {
            this.Index = index;
        }

        /// <summary>
        /// Define SortIndex
        /// </summary>
        private int SortIndex
        {
            get
            {
                return this.Index;
            }
        }
    }
}
