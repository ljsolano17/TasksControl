using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Tasks : ICRUD<data.Tasks>
    {
        private SolutionDbContext _context;
        public Tasks(SolutionDbContext context)
        {
            _context = context;
        }
        public void Delete(data.Tasks entity)
        {
            new DAL.Tasks(_context).Delete(entity);
        }

        public IEnumerable<data.Tasks> GetAll()
        {
            return new DAL.Tasks(_context).GetAll();
        }

        public data.Tasks GetById(int id)
        {
            return new DAL.Tasks(_context).GetById(id);
        }

        public void Insert(data.Tasks entity)
        {
            new DAL.Tasks(_context).Insert(entity);
        }

        public void Update(data.Tasks entity)
        {
            new DAL.Tasks(_context).Update(entity);
        }
    }
}
