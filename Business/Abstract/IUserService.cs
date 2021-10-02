using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService : ICrudService<User>
    {
        List<OperationClaim> GetClaims(User user);
        new void Add(User user);
        User GetByMail(string email);
        IResult ChangePassword(ChangePasswordDto changePasswordDto);
        IDataResult<int> GetTotalUserCount();
    }
}
