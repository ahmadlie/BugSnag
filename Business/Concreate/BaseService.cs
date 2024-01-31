using AutoMapper;
using Business.Abstract;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class BaseService<TDto,TEntity> : IBaseService<TDto,TEntity>
                            where TEntity : class
    {
        protected AppDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        protected IMapper _mapper;
        public BaseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _mapper = mapper;
        }
        public void Create(TDto dto)
        {
           var ent =  _mapper.Map<TEntity>(dto);
            _dbSet.Add(ent);
            _dbContext.SaveChanges();
        }
    }
}
