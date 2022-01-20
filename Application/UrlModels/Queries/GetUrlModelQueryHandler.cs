using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System.Threading;
using AutoMapper;
using Application.Common.Dtos;

namespace Application.UrlModels.Queries
{

    public class GetUrlModelCommandHandler : IRequestHandler<GetUrlModelQuery, GetUrlModelResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUrlModelCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUrlModelResponse> Handle(GetUrlModelQuery request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var entity = await _context.UrlModels.FindAsync(request.Id);

            return _mapper.Map<GetUrlModelResponse>(entity);
        }

        private void ValidateRequest(GetUrlModelQuery request)
        {
            if (request == null)
            {
                throw new BadRequestException(nameof(request), "Command is null.");
            }

        }


    }
}
