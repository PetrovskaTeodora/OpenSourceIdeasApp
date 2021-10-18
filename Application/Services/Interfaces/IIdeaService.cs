using Application.DTO_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IIdeaService
    {
        IEnumerable<IdeaDTO> GetAll(Guid userId);
        IdeaDTO GetById(Guid id);
        bool Add(IdeaDTO idea);
        bool Update(IdeaDTO idea);
        bool Delete(Guid id);

    }
}
