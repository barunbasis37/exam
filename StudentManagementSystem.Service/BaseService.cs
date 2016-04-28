using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Model;
using StudentManagementSystem.Repo;

namespace StudentManagementSystem.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected BaseRepository<T> Repository;

        public BaseService(BaseRepository<T> repository)
        {

            Repository = repository;
        }

        public virtual bool Add(T entity)
        {
            var add = Repository.Add(entity);
            var save = Repository.Save();
            return save;
        }

        public bool Delete(T entity)
        {
            bool deleted = Repository.Delete(entity);
            Repository.Save();
            return deleted;
        }

        public bool Delete(string id)
        {
            var entity = Repository.Filter(x => x.Id == id).FirstOrDefault();
            bool deleted = Repository.Delete(entity);
            Repository.Save();
            return deleted;
        }

        public virtual bool Edit(T entity)
        {
            bool edit = Repository.Edit(entity);
            Repository.Save();
            return edit;
        }

        public T GetById(string id)
        {
            return Repository.GetById(id);
        }
    }
}
