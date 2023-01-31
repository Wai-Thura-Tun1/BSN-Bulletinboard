using Bulletinboard.Model;
using System;
using System.ComponentModel;

namespace BulletinboardApp.Post
{
    public class PostModel : IPost, INotifyPropertyChanged
    {
        /// <summary>
        /// Define id
        /// </summary>
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// Define title
        /// </summary>
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Define description
        /// </summary>
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Define ispublished
        /// </summary>
        private bool _ispublished;
        public bool IsPublished
        {
            get
            {
                return _ispublished;
            }
            set
            {
                _ispublished = value;
                OnPropertyChanged(nameof(IsPublished));
            }
        }

        /// <summary>
        /// Define isdeleted
        /// </summary>
        private bool _isdeleted;
        public bool IsDeleted
        {
            get
            {
                return _isdeleted;
            }
            set
            {
                _isdeleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }

        /// <summary>
        /// Define createduserid
        /// </summary>
        private string _createduserid;
        public string CreatedUserId
        {
            get
            {
                return _createduserid;
            }
            set
            {
                _createduserid = value;
                OnPropertyChanged(nameof(CreatedUserId));
            }
        }

        /// <summary>
        /// Define spublished
        /// </summary>
        private string _spublished;
        public string SPublished
        {
            get
            {
                return _spublished;
            }
            set
            {
                _spublished = value;
                OnPropertyChanged(nameof(SPublished));
            }
        }

        /// <summary>
        /// Define createdat
        /// </summary>
        private string _createdat;
        public string CreatedAt
        {
            get
            {
                return _createdat;
            }
            set
            {
                _createdat = value;
                OnPropertyChanged(nameof(CreatedAt));
            }
        }

        /// <summary>
        /// Define createdby
        /// </summary>
        private string _createdby;
        public string CreatedBy
        {
            get
            {
                return _createdby;
            }
            set
            {
                _createdby = value;
                OnPropertyChanged(nameof(CreatedBy));
            }
        }

        /// <summary>
        /// Define keyword
        /// </summary>
        private string _keyword;
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(Keyword));
            }
        }

        /// <summary>
        /// Define datastatus
        /// </summary>
        public int DataStatus { get; set; }

        /// <summary>
        /// Property change event
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invoke when property change
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
