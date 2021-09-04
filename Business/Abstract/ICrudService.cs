using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICrudService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<T> GetById(int id);
    }
}
