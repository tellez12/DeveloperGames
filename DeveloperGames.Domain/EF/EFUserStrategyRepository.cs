using DeveloperGames.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperGames.Domain.Entities;
using DeveloperGames.Domain.Utils;
using System.Data.Entity;
namespace DeveloperGames.Domain.EF
{
    public class EFUserStrategyRepository : EFBaseRepository, IUserStrategyRepository
    {
        public IQueryable<UserStrategy> GetUserStrategies
        {
            get { return Db.UserStrategies; }
        }

        public UserStrategy GetUserStrategy(int id)
        {
            return Db.UserStrategies.Find(id);
        }

        public Message Create(UserStrategy userStrategy)
        {
            try
            {
                Db.UserStrategies.Add(userStrategy);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", userStrategy.GetType()));
            }
        }

        public Message Update(UserStrategy userStrategy)
        {
            try
            {
                Db.Entry(userStrategy).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", userStrategy.GetType()));
            }
        }

        public Message Delete(int id)
        {
            UserStrategy userStrategy = GetUserStrategy(id);
            try
            {
                Db.UserStrategies.Remove(userStrategy);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", userStrategy.GetType()));
            }
        }
    }
}
