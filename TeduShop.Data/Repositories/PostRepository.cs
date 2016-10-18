using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        //IEnumerable<Post> GetAll(string[] a);
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory):base(dbFactory)
        {
           
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from a in DbContext.Posts
                        join b in DbContext.PostTags on a.ID equals b.PostID
                        where b.TagID == tag &&a.Status
                        orderby a.CreateDate  descending
                        select a;
            totalRow = query.Count();
            query = query.Skip((pageIndex-1)*pageSize).Take(pageSize);
            return query;
        }
    }
}
