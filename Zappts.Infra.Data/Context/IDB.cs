using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zappts.Infra.Data.Context
{
    public interface IDB
    {
        public ApplicationDbContext Context { get; set; }
        void Commit();
    }
}
