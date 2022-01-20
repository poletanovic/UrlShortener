using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System.Threading;
using UrlModelEntity = Domain.Entities.UrlModel;

namespace Application.UrlModels.Commands
{

    public class DeleteUrlModelCommandHandler : IRequestHandler<DeleteUrlModelCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public DeleteUrlModelCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteUrlModelCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequestAsync(request);

            var entity = await _context.UrlModels.FindAsync(request.Id);
            _context.UrlModels.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task ValidateRequestAsync(DeleteUrlModelCommand request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

            var entity = await _context.UrlModels.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UrlModelEntity), request.Id);
            }

            if (entity.AuthorId != _context.Authors.FirstOrDefault(o => o.Username == _currentUser.Username)?.Id)
            {
                throw new BadRequestException(nameof(UrlModelEntity), "Only the author can delete.");
            }

        }
    }
}
