using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IIdeaRepository
    {
        List<Idea> GetAll();
        Idea GetById(Guid id);
        int Insert(Idea idea);
        int Update(Idea idea);
        int Delete(Guid id);
    }
}
