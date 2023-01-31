using Bulletinboard.Back.DataAccess;
using Bulletinboard.Back.DataAccess.Data;
using System.Data;

namespace DataAccess.Repositories
{
    public class PostRepository
    {
        /// <summary>
        /// Define datacontext for posts table
        /// </summary>
        private DataContext<Post> _dataContext;

        /// <summary>
        /// Constructor
        /// </summary>
        public PostRepository()
        {
            _dataContext = new DataContext<Post>(new BsnbulletinboardContext());
        }

        /// <summary>
        /// Fetch post lists and filter with search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>
        /// The <see cref="Task{List{Model.Post}?}"/>
        /// </returns>
        public async Task<List<Model.Post>?> GetPostList(string searchString)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    var query = (from p in _context.Posts
                                 join u in _context.Users on p.CreatedUserId equals u.Id.ToString()
                                 where p.IsDeleted == false
                                 orderby p.Id descending
                                 select new Model.Post
                                 {
                                     Id = p.Id,
                                     Title = p.Title,
                                     Description = p.Description,
                                     SPublished = p.IsPublished ? "Published" : "Unpublished",
                                     CreatedAt = p.CreatedDate.ToString("MM/dd/yyyy"),
                                     CreatedBy = u.FirstName + " " + u.LastName,
                                     CreatedUserId = p.CreatedUserId,
                                 }).ToList();
                    if(!string.IsNullOrEmpty(searchString))
                    {
                        string keyword = searchString.ToLower();
                        query = query.Where(x =>
                        x.Title.ToLower().Contains(keyword) ||
                        x.Description.ToLower().Contains(keyword) ||
                        x.SPublished.ToLower().Contains(keyword) ||
                        x.CreatedBy.ToLower().Contains(keyword)
                        ).ToList();
                    }
                    return query;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new List<Model.Post>();
            }
        } 

        /// <summary>
        /// Save post data into table
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> SavePost(Model.Post obj)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    Post post = new()
                    {
                        Title = obj.Title,
                        Description = obj.Description,
                        IsPublished = obj.IsPublished,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        CreatedUserId = obj.CreatedUserId
                    };
                    _context.Posts.Add(post);
                    _context.SaveChanges();
                    return iConstance.RESULT_SUCCESS;
                }

            }
            catch (Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task{Model.Post}"/>
        /// </returns>
        public async Task<Model.Post> GetPostById(int id)
        {
            try
            {
                var query = await _dataContext.Select(x => x.Id == id);
                _dataContext.Dispose();
                if (query != null)
                {
                    Model.Post post = new()
                    {
                        Id = query.Id,
                        Title = query.Title,
                        Description = query.Description,
                        IsPublished = query.IsPublished,
                    };
                    return post;
                }
                return new Model.Post();
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new Model.Post();
            }
        }

        /// <summary>
        /// Update post data into table
        /// </summary>
        /// <param name="post"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> UpdatePost(Model.Post post)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    var currentUser = await _dataContext.Select(x => x.Id == post.Id);
                    _dataContext.Dispose();
                    if (currentUser != null)
                    {
                        currentUser.Title = post.Title;
                        currentUser.Description = post.Description;
                        currentUser.IsPublished = post.IsPublished;
                        currentUser.UpdatedDate = DateTime.Now;
                        currentUser.UpdatedUserId = post.UpdatedUserId;
                        _context.Posts.Update(currentUser);
                        _context.SaveChanges();
                        return iConstance.RESULT_SUCCESS;
                    }
                    
                }
                return iConstance.RESULT_FAILURE;
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Upload data from excel to table
        /// </summary>
        /// <param name="postList"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> UploadPost(List<Model.Post> postList)
        {
            try
            {
                using(var context = new BsnbulletinboardContext())
                {
                    List<Post> posts = new();
                    foreach(var post in postList)
                    {
                        Post addPost = new Post()
                        {
                            Title = post.Title,
                            Description = post.Description,
                            IsPublished = post.IsPublished,
                            IsDeleted = false,
                            CreatedDate = DateTime.Now,
                            CreatedUserId = post.CreatedUserId,
                        };
                        posts.Add(addPost);
                    }
                    context.Posts.AddRange(posts);
                    context.SaveChanges();
                    return iConstance.RESULT_SUCCESS;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// The <see cref="int"/> 1 = success, 3 = fail
        /// </returns>
        public async Task<int> DeletePost(Model.Post obj)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    var deletePost = await _dataContext.Select(x => x.Id == obj.Id);
                    if(deletePost != null)
                    {
                        deletePost.IsDeleted = true;
                        deletePost.DeletedDate = DateTime.Now;
                        deletePost.DeletedUserId = obj.DeletedUserId;
                        _context.Posts.Update(deletePost);
                        _context.SaveChanges();
                        return iConstance.RESULT_SUCCESS;
                    }
                    return iConstance.RESULT_FAILURE;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return iConstance.RESULT_FAILURE;
            }
        }

        /// <summary>
        /// Download post data
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The <see cref="Task{List{Model.Post}}"/>
        /// </returns>
        public async Task<List<Model.Post>> DownloadPost(Model.User user)
        {
            try
            {
                using(var _context = new BsnbulletinboardContext())
                {
                    List<Model.Post> postList = new();
                    if(user.Role < 1)
                    {
                        postList = (from p in _context.Posts
                         where p.IsDeleted == false && p.CreatedUserId == user.Id.ToString()
                         orderby p.Id descending
                         select new Model.Post
                         {
                             Id = p.Id,
                             Title = p.Title,
                             Description = p.Description,
                             SPublished = p.IsPublished ? "Published" : "Unpublished",
                             IsPublished = p.IsPublished
                         }).ToList();
                    }
                    else
                    {
                        postList = (from p in _context.Posts
                                 where p.IsDeleted == false
                                 orderby p.Id descending
                                 select new Model.Post
                                 {
                                     Id = p.Id,
                                     Title = p.Title,
                                     Description = p.Description,
                                     SPublished = p.IsPublished ? "Published" : "Unpublished",
                                     IsPublished = p.IsPublished
                                 }).ToList();
                    }

                    return postList;
                }
            }
            catch(Exception ex)
            {
                CommonSetting.Log.Logger.Error(ex.Message);
                return new List<Model.Post>();
            }
        }
    }
}
