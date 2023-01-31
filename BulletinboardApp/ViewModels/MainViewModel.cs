using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinboardApp.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        /// <summary>
        /// Define instance
        /// </summary>
        private static MainViewModel _instance = new();
        public static MainViewModel Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Define pagepath
        /// </summary>
        private string _pagePath { get; set; }
        public string PagePath
        {
            get
            {
                return _pagePath;
            }
            set
            {
                _pagePath = value;
                OnPropertyChanged("PagePath");
            }
        }
    }
}
