using MediatR;
using Application.Common.Dtos;

namespace Application.News.Queries
{
    public class GetNewsQuery : IRequest<GetNewsResponse>
    {
        public int Id { get; set; }

    }

}
