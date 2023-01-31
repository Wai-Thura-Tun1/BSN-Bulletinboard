using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulletinboard.Back.DataAccess
{
    public class DataContext<T> where T : class
    {
        /// <summary>
        /// Define dbcontext
        /// </summary>
        private readonly DbContext _context;
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public DataContext(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Select list 
        /// </summary>
        /// <returns>
        /// The <see cref="Task{IEnumerable{T}}"/>
        /// </returns>
        public async Task<IEnumerable<T>> SelectList()
        {
            return await _context.Set<T>().ToListAsync();

        }

        /// <summary>
        /// Select one with expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>
        /// The <see cref="Task{T}"/>
        /// </returns>
        public async Task<T> Select(Expression<Func<T,bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstAsync();
        }

        /// <summary>
        /// Dispose context
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
