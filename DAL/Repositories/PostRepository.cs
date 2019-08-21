using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PostRepository:IPostRepository
    {
        /// <summary>
        /// Query by ID
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns></returns>
        public Post FindById(int id)
        {
            using (EFContext context = new EFContext())
            {
                var entity = context.Posts.FirstOrDefault(t=>t.Id==id);
                return entity;
            }
        }

        /// <summary>
        /// Query all data (no pagination, use cautiously in large quantities)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> FindAll()
        {

            using (EFContext context = new EFContext())
            {
                var list = context.Posts.ToList();
                return list;
            }
        }


        /// <summary>
        /// Write Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public int Insert(Post entity)
        {
            using (EFContext context = new EFContext())
            {
                var i = context.Posts.Add(entity).Id;
                context.SaveChanges();
                // The I returned is long, and here you can process it according to your business needs.
                return i;
            }
        }

        /// <summary>
        /// Updating Entity Data
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public bool Update(Post entity)
        {
            using (EFContext context = new EFContext())
            {
                // This approach is conditioned on the primary key.
                var post = context.Posts.FirstOrDefault(t => t.Id == entity.Id);
                if (post != null)
                {
                    post.IsDeleted = entity.IsDeleted;
                    post.PublishedAt = entity.PublishedAt;
                    post.Title = entity.Title;
                    post.ViewCount = entity.ViewCount;
                    post.AllowShow = entity.AllowShow;
                    post.AuthorId = entity.AuthorId;
                    post.AuthorName = entity.AuthorName;
                    post.Content = post.Content;
                    post.CreatedAt = post.CreatedAt;
                    context.SaveChanges();
                }
                return post.Id!=0;
            }
        }

        /// <summary>
        /// Delete a data by entity
        /// </summary>
        /// <param name="entity">blog entity class </param>
        /// <returns></returns>
        public bool Delete(Post entity)
        {
            using (EFContext context = new EFContext())
            {
                var i = context.Posts.Remove(entity).Id;
                context.SaveChanges();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete the data for the specified ID
        /// </summary>
        /// <param name="id">primary key ID</param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            using (EFContext context = new EFContext())
            {
                var i = context.Posts.Remove(context.Posts.FirstOrDefault(t=>t.Id==(int)id)).Id;
                context.SaveChanges();
                return i > 0;
            }
        }

        /// <summary>
        /// Delete data from the specified ID collection (batch deletion)
        /// </summary>
        /// <param name="ids">primary key ID set </param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            int i = 0;
            using (EFContext context = new EFContext())
            {
                foreach (int item in ids)
                {
                    i = context.Posts.Remove(context.Posts.FirstOrDefault(t=>t.Id==item)).Id;
                }
                context.SaveChanges();
                return i > 0;
            }
        }
    }
}
