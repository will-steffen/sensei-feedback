using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Feedback.DataAccess.Entities
{
    public class BaseDataAccess<T> where T : BaseModel
    {
        protected ApplicationContext Context;

        public BaseDataAccess(ApplicationContext ctx)
        {
            Context = ctx;
        }

        private void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual T GetById(long id)
        {            
            return GetBaseQueryable().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> GetByIds(List<long> ids)
        {
            return GetBaseQueryable().Where(x => ids.Contains(x.Id));
        }

        public virtual void Save(T model)
        {
            DbSet<T> set = Context.Set<T>();
            if (model.Id == 0)
            {
                set.Add(model);
            }
            else
            {
                set.Attach(model);
                Context.Entry(model).State = EntityState.Modified;
            }
            SaveChanges();
        }

        public virtual void Save(List<T> modelList)
        {
            modelList.ForEach(model =>
            {
                DbSet<T> set = Context.Set<T>();

                if (model.Id == 0)
                {
                    set.Add(model);
                }
                else
                {
                    set.Attach(model);
                    Context.Entry(model).State = EntityState.Modified;
                }
            });
            SaveChanges();
        }

        public virtual void Delete(T model)
        {
            Context.Set<T>().Remove(model);
            SaveChanges();
        }

        public IEnumerable<T> List()
        {            
            return GetBaseQueryable();
        }

        public virtual IQueryable<T> GetBaseQueryable()
        {
            return Context.Set<T>();
        }
    }
}
