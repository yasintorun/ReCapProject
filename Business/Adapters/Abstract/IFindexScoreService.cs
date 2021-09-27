using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.Abstract
{
    public interface IFindexScoreService
    {
        int GetUserFindexScore(int userId);
    }
}
