using DeveloperGames.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IUserStrategyRepository EFUserStrategyRepository { get; }
    }
}
