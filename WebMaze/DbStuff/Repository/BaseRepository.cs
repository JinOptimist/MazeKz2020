using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public abstract class BaseRepository<Model> where Model : BaseModel
    {
        protected WebMazeContext context;
        protected DbSet<Model> dbSet;

        public BaseRepository(WebMazeContext context)
        {
            this.context = context;
            dbSet = context.Set<Model>();
        }

        public Model Get(long id)
        {
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Model> GetAll()
        {
            return dbSet.ToList();
        }

        public void Save(Model user)
        {
            dbSet.Add(user);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            var model = Get(id);
            dbSet.Remove(model);
        }
    }
}
