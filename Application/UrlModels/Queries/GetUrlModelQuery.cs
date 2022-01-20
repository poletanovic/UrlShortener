using MediatR;
using Application.Common.Dtos;

namespace Application.UrlModels.Queries
{
    public class GetUrlModelQuery : IRequest<GetUrlModelResponse>
    {
        public int Id { get; set; }

    }

}
