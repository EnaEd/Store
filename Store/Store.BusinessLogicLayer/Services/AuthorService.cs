using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorModel>> GetAuthorsAsync()
        {
            IEnumerable<AuthorModel> authors = _mapper.Map<IEnumerable<AuthorModel>>(await _authorRepository.GetAllAsync());
            if (!authors.Any())
            {
                throw new UserException { Code = Enums.ErrorCode.NotFound, Description = Constant.Errors.AUTHOR_NOT_FOUND };
            }

            return authors;
        }
    }
}
