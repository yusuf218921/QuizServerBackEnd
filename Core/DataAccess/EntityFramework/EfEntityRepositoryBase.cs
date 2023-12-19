using Core.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    // EntityFramework kullanılarak oluşturulmuş,
    // CRUD (Create, Read, Update , Delete) işlemlerini // yerine getiren,
    // Generic, RepositoryBase sınıfı (DataAccess Katmanındaki sınıfların miras aldığı sınıf)

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // Veri tabanına veri ekleyen metod, Generic bir Entity(Db tabloları) alıyor
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        // Veri tabanına veri silen metod, Generic bir Entity(Db tabloları) alıyor
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        // Veri tabanından veri çeken metod, Generic bir Entity(Db tabloları) alıyor
        // Hangi verinin çekileceği sorgusu LINQ kullanılarak yapılıyor,
        // Filtrelemeye göre TEK bir değeri(birden fazla getirmez) ya da default değeri döndürüyor.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        // // Veri tabanından veri çeken metod, Generic bir Entity(Db tabloları) alıyor
        // Hangi verinin çekileceği sorgusu LINQ kullanılarak yapılıyor,
        // Filtreleme null olabilir (Filtresiz bütün değerler istenirse)
        // Duruma göre filtreye uyan tüm değerleri getirir
        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        // Veri tabanında veri güncelleyen metod, Generic bir Entity(Db tabloları) alıyor
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}