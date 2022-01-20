using System.Linq;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Threading;

namespace Application.News.Queries
{
    public class GetNewsWithPaginationQueryHandler : IRequestHandler<GetAllNewsWithPaginationQuery, PaginatedList<GetNewsResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
         
        public GetNewsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetNewsResponse>> Handle(GetAllNewsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                .OrderByDescending(o => o.Created)
                .ProjectTo<GetNewsResponse>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(request.Model.PageNumber, request.Model.PageSize);
        }
    }
}
