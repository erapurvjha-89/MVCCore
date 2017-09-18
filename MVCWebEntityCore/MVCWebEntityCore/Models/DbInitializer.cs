using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebEntityCore.Models
{
    public static class DbInitializer

    {
        public static void Initialize(ProjDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
    public static class DbInitializer1

    {
        public static void Initialize(ProjDBContext1 context)
        {
            context.Database.EnsureCreated();
        }
    }
}
