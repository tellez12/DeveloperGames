using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.EF
{
    public class EFBaseRepository:IDisposable
    {
        protected ApplicationDbContext Db = new ApplicationDbContext();

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
