﻿using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        //Summary : Lamda expressionlar halinde yazılarak kodun daha rahat okunabilirliği ve dinamik bir yapı oluşturur ama geneleneksel bir şekilde de interfaceler oluşturulabilir ( traversal projemde ki gibi)
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                   bool enableTracking = false);

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
                                  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                  bool enableTracking = false, int currentPage=1,int pageSize=3);

        Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);  // nullable olabilir çünkü count null gelebilir fakat yukaridaki metotlar null olamaz çünkü verinin kendisi geliyor...
    }
}