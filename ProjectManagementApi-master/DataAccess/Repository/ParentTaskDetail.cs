using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess
{
    public class ParentTaskDetail : IParentTaskDetails
    {
        private readonly ProjectManagerApiDbContext _dbContext;
        public ParentTaskDetail()
        {
        }
        public ParentTaskDetail(ProjectManagerApiDbContext dbContext)
        {
            _dbContext = dbContext;          
        }       
        public async Task<IEnumerable<ParentTaskDetails>> GetAll()
        {
      return await _dbContext.ParentTask.AsNoTracking().ToListAsync();
    }
        public async Task<ParentTaskDetails> Get(int id)
        {
      return await _dbContext.ParentTask.FirstOrDefaultAsync(t => t.ParentId== id);
    }
        public async Task<int> Insert(ParentTaskDetails parentTaskDetails)
        {
      _dbContext.ParentTask.Add(parentTaskDetails);

      return await _dbContext.SaveChangesAsync();
    }
        public Task<int> Edit(ParentTaskDetails parentTaskDetails)
        {
            throw new System.NotImplementedException();
        }
        public Task<int> Delete(ParentTaskDetails parentTaskDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}
