using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace ASF.Data
{
    public class AbstractDAC<TEntity> where TEntity : class
    {
        
        protected LeatherContext createContext()
        {
            return new LeatherContext();
        }

        /// <summary>
        /// Find entity using numerci id
        /// </summary>
        /// <typeparam name="T">Entity to find</typeparam>
        /// <param name="id"></param>
        /// <returns>The entity</returns>
        protected T FindById<T> (LeatherContext ctx, long id)
        {

            
                var prop = ctx.GetType().GetProperty(typeof(T).Name);

                var getter = prop.GetGetMethod();

                var dbset = getter.Invoke(ctx,null);

                var findMethod = dbset.GetType().GetMethod("Find");
                var result = findMethod.Invoke(dbset,new object[] { new object[] { id } });

                return (T) result;
        }

        public T FindById<T>(long id)
        {
            using (var ctx = createContext())
            {
                return FindById<T>(ctx, id);
            }
        }

        protected List<TEntity> SelectAll(LeatherContext ctx)
        {
            return SelectAll(ctx,500);
        }

        public List<TEntity> SelectAll()
        {
            using (var ctx = createContext())
            {
                return SelectAll(ctx);
            }
        }

        protected List<TEntity> SelectAll(LeatherContext ctx,int max)
        {
            
            return ctx.Set<TEntity>().Take(max).ToList();
            
        }

        public List<TEntity> SelectAll(int max)
        {
            using (var ctx = createContext())
            {
                return SelectAll(ctx,max);
            }
        }
        



        protected TEntity Save(LeatherContext ctx, TEntity entity)
        {

            if (entity.GetType().GetProperty("Id") != null)
            {
                int? id = (int) entity.GetType().GetProperty("Id").GetMethod.Invoke(entity,null);

                if (id != null && id > 0)
                {
                    var updated = ctx.Set<TEntity>().Attach(entity);
                    ctx.Entry(updated).State = EntityState.Modified;
                    return updated;
                }
            }
            
            var saved = ctx.Set<TEntity>().Add(entity);
            
            return saved;
        }

        public TEntity Save(TEntity entity)
        {
            using (var ctx = createContext())
            {
                var result = Save(ctx, entity);
                ctx.SaveChanges();
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected TEntity SelectById(LeatherContext ctx, int id)
        {
            return ctx.Set<TEntity>().Find(id);   
        }


        public TEntity SelectById(int id)
        {
            using (var ctx = createContext())
            {
                return SelectById(ctx, id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            using (var dbc = createContext())
            {
                var entity = SelectById(dbc, id);
                dbc.Entry(entity).State = EntityState.Deleted;
                dbc.SaveChanges();
            }
        }


    }


}