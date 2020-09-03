using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ColorRepository : LEnglishRepository<Color>, IRepository<Color>
    {
        public ColorRepository(DBContext dbctx) : base(dbctx)
        {
        }
    }
}
