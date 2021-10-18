using Application.DTO_Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IIdeaRepository _ideaRepository;
        private readonly IMapper _mapper;

        public IdeaService(IIdeaRepository ideaRepository, IMapper mapper)
        {
            _ideaRepository = ideaRepository;
            _mapper = mapper;
        }
        public bool Add(IdeaDTO idea)
        {
            if (idea == null) throw new ArgumentNullException("idea");

            var result = _ideaRepository.Insert(_mapper.Map<Idea>(idea));

            if (result == 1) return true;
            return false;

        }

        public IEnumerable<IdeaDTO> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<IdeaDTO>>(_ideaRepository.GetAll(userId));
        }

        public IdeaDTO GetById(Guid id)
        {
            return _mapper.Map<IdeaDTO>(_ideaRepository.GetById(id));
        }

        public bool Update(IdeaDTO idea)
        {
            if (idea == null) throw new ArgumentNullException("idea");

            var result = _ideaRepository.Update(_mapper.Map<Idea>(idea));

            if (result == 1) return true;
            return false;
        }
        public bool Delete(Guid id)
        {
            var result = _ideaRepository.Delete(id);

            if (result == 1) return true;
            return false;
        }
    }
}
