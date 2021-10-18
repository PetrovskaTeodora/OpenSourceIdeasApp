using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly OpenSourceIdeasDbContext _context;

        public IdeaRepository(OpenSourceIdeasDbContext context)
        {
            _context = context;
        }

        public List<Idea> GetAll(Guid userId)
        {
            return _context.Ideas.Where(x=>x.UserId==userId).ToList();
        }

        public Idea GetById(Guid id)
        {
            return _context.Ideas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Idea idea)
        {
            var ideaWithSameUniqueCode = _context.Ideas.Where(x => x.UniqueCode == idea.UniqueCode && x.UserId == idea.UserId).FirstOrDefault();
            if (ideaWithSameUniqueCode != null) return -1;

            idea.DateCreated = DateTime.UtcNow;
            _context.Ideas.Add(idea);
            return _context.SaveChanges();
        }

        public int Update(Idea idea)
        {
            var ideaWithSameUniqueCode = _context.Ideas.Where(x => x.UniqueCode == idea.UniqueCode);
            if (ideaWithSameUniqueCode != null) return -1;

            var entity = _context.Ideas.FirstOrDefault(x => x.Id == idea.Id);

            if (entity == null) return -1;

            entity.Id = idea.Id;
            entity.Title = idea.Title;
            entity.Description = idea.Description;
            entity.UniqueCode = idea.UniqueCode;

            _context.Ideas.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Guid id)
        {
            var entity = _context.Ideas.FirstOrDefault(x => x.Id == id);

            if (entity == null) return -1;

            _context.Ideas.Remove(entity);

            return _context.SaveChanges();
        }

    }
}
