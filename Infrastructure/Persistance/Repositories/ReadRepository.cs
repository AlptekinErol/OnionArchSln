using Application.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } // her defasında içeride dbContext çağırmak yerine 1 kere yazıp Table değerine atadık
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking(); // bildiğimiz gibi read işlemlerinde EFCore'un tracknige gerek yok performans düşürüyor
            if (include is not null) queryable = include(queryable);   // expression burada Queryable nesne alarak Includable bir nesneye döndürerek ilişkisel veri getirecek bir include methodu oluşturuyor
            if (predicate is not null) queryable = queryable.Where(predicate);  // expression burada yine queryable nesne alarak bunu bool bir sonuca döndürerek spesifik bir filtreme yapmamızı sağlıyor
            if (orderBy is not null)                                              // queryable nesne ordered nesneye dönerek sıralanmış bir veri geri döndürüyor ( eğer null değilse )
                return await orderBy(queryable).ToListAsync();                      // to list ile basıyor

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {

            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();  // örnek : currentPage= 1 ( 1-1 * 0).Take(3) => 3 adet veri aldı
                                                                                                                  // ardından currentPage=2 (2-1)*3.Take(3) => 3 e kadar skip sonra bir +3 daha ( 6 etti)
                                                                                                                  // yani 6 etti ( her defasında 3 veri ekleyip öncesini skipliyor ( 6ya kadar skip sonra +3 ) => 9 etti   

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            // queryable.Where(predicate);
            return await queryable.FirstOrDefaultAsync(predicate);

        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null)
                Table.Where(predicate);
            return await Table.CountAsync();
        }

        Task<IList<T>> IReadRepository<T>.GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool enableTracking)
        {
            throw new NotImplementedException();
        }

        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking = false)
        {
            if(!enableTracking) Table.Where(predicate);
            return  Table.Where(predicate);
        }
    }
}
