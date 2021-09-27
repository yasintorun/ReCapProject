using Business.Adapters.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.Concrete
{
    public class FakeFindexScoreAdapter : IFindexScoreService
    {
        public int GetUserFindexScore(int userId)
        {
            Random random = new Random();
            return random.Next(1901);
        }
    }
}
