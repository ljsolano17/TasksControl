using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Tasks : ICRUD<data.Tasks>
    {
        private Repository<data.Tasks> _repo = null;
        public Tasks(SolutionDbContext context)
        {
            _repo = new Repository<data.Tasks>(context);
        }
        public void Delete(data.Tasks entity)
        {
            _repo.Delete(entity);
            _repo.Commit();
        }

        public IEnumerable<data.Tasks> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Tasks GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Insert(data.Tasks entity)
        {
            _repo.Insert(entity);
            _repo.Commit();
        }

        public void Update(data.Tasks entity)
        {
            _repo.Update(entity);
            _repo.Commit();
        }
    }
}
