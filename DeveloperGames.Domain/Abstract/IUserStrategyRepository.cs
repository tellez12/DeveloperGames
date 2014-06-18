using DeveloperGames.Domain.Entities;
using DeveloperGames.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Abstract
{
    public interface IUserStrategyRepository
    {
        IQueryable<UserStrategy> GetUserStrategies { get; }

        UserStrategy GetUserStrategy(int id);

        Message Create(UserStrategy userStrategy);

        Message Update(UserStrategy userStrategy);

        Message Delete(int id);


    }
}
