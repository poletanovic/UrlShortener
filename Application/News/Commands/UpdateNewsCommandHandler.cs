using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using NewsEntity = Domain.Entities.News;
using MediatR;
using System.Threading;
using AutoMapper;

namespace Application.News.Commands
{

    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public UpdateNewsCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequestAsync(request);

            var entity = await _context.News.FindAsync(request.Model.Id);

            entity.Title = request.Model.Title;
            entity.Text = request.Model.Text;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task ValidateRequestAsync(UpdateNewsCommand request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

            if (request.Model == null)
            {
                throw new BadRequestException(nameof(request.Model), "Param is null.");
            }

            var entity = await _context.News.FindAsync(request.Model.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NewsEntity), request.Model.Id);
            }

            if (entity.AuthorId != _context.Authors.FirstOrDefault(o => o.Username == _currentUser.Username)?.Id)
            {
                throw new BadRequestException(nameof(request.Model), "Only the author can modify.");
            }

        }
    }
}
