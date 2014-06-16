using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperGames.Domain.Entities
{
    public class UserStrategy
    {
        public virtual ApplicationUser User { get; set; }

        public String UserCode { get; set; }


    }
}
