using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UrlModels.Commands
{

    public class RedirectUrlCommandHandler : IRequestHandler<RedirectUrlCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public RedirectUrlCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<string> Handle(RedirectUrlCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequestAsync(request);

            var author = _context.Authors.FirstOrDefault(o => o.Username.Equals(_currentUser.Username));
            if (author == null)
            {
                throw new BadRequestException(nameof(request), "Author is null.");
            }

            var entity = _context.UrlModels.FirstOrDefault(o => o.AuthorId == author.Id && o.LongName.Equals(request.url));
            if (entity == null)
            {
                throw new BadRequestException(nameof(request), "Entity is null.");
            }

            return entity.LongName;
        }
        private async Task ValidateRequestAsync(RedirectUrlCommand request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

            if (string.IsNullOrEmpty(request.url))
            {
                throw new BadRequestException(nameof(request), "Url is null.");
            }           

        }


    }
}
