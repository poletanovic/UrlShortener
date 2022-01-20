using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewsEntity = Domain.Entities.News;

namespace Application.News.Commands
{

    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, CreateNewsResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public CreateNewsCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<CreateNewsResponse> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<NewsEntity>(
                request.Model,
                opt => opt.Items["AuthorId"] = _context.Authors.FirstOrDefault(o => o.Username == _currentUser.Username)?.Id ?? 0);

            _context.News.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateNewsResponse>(entity);
        }

    }
}
