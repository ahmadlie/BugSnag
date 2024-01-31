using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<TDto,TEntity>
    {
        void Create(TDto dto);
    }
}
