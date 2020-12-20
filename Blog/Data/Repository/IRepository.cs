using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPost();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();
    }
}