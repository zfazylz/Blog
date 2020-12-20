using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPost(Post post)
        {
            _dbContext.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return _dbContext.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _dbContext.Posts.FirstOrDefault(x => x.Id == id);
        }

        public void RemovePost(int id)
        {
            _dbContext.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _dbContext.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _dbContext.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}