using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System.Threading;
using NewsEntity = Domain.Entities.News;

namespace Application.News.Commands
{

    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public DeleteNewsCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequestAsync(request);

            var entity = await _context.News.FindAsync(request.Id);
            _context.News.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task ValidateRequestAsync(DeleteNewsCommand request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

            var entity = await _context.News.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NewsEntity), request.Id);
            }

            if (entity.AuthorId != _context.Authors.FirstOrDefault(o => o.Username == _currentUser.Username)?.Id)
            {
                throw new BadRequestException(nameof(NewsEntity), "Only the author can modify.");
            }

        }
    }
}
