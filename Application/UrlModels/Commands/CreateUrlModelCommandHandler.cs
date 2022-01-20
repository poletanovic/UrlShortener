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
using UrlModelEntity = Domain.Entities.UrlModel;

namespace Application.UrlModels.Commands
{

    public class CreateUrlModelCommandHandler : IRequestHandler<CreateUrlModelCommand, CreateUrlModelResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public CreateUrlModelCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<CreateUrlModelResponse> Handle(CreateUrlModelCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UrlModelEntity>(
                request.Model,
                opt => opt.Items["AuthorId"] = _context.Authors.FirstOrDefault(o => o.Username == _currentUser.Username)?.Id ?? 0);

            await ValidateRequestAsync(entity);

            //da uradimo skracivanje linka
            entity.ShortName = CreateHash(entity.LongName);

            _context.UrlModels.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateUrlModelResponse>(entity);
        }
        private async Task ValidateRequestAsync(UrlModelEntity request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

            //validacija da li link postoji u za tog autora i taj longname
            if (_context.UrlModels.Any(o => o.LongName.Equals(request.LongName) && o.AuthorId == request.AuthorId))
            {
                throw new BadRequestException(nameof(request), "This link already exists for the user!");
            }

            //provjera na regexu da li je ispravan url
            if(!Uri.IsWellFormedUriString(request.LongName, UriKind.RelativeOrAbsolute))
            {
                throw new BadRequestException(nameof(request), "This link is not well formed!");
            }

        }

        public static string CreateHash(string input)
        {
            return String.Format("{0:X}", input.GetHashCode());
        }

    }
}
