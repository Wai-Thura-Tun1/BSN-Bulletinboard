using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Role: IRole
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Role()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }

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
