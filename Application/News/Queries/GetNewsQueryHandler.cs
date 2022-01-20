using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System.Threading;
using AutoMapper;
using Application.Common.Dtos;

namespace Application.News.Queries
{

    public class GetNewsCommandHandler : IRequestHandler<GetNewsQuery, GetNewsResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNewsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetNewsResponse> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var entity = await _context.News.FindAsync(request.Id);

            return _mapper.Map<GetNewsResponse>(entity);
        }

        private void ValidateRequest(GetNewsQuery request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

        }


    }
}
