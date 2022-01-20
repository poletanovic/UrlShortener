using Application.Common.Dtos;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.News
{
    public class GetAllNewsWithPaginationQuery : IRequest<PaginatedList<GetNewsResponse>>
    {
        public GetAllNewsRequest Model { get; set; }

        public GetAllNewsWithPaginationQuery(GetAllNewsRequest model)
        {
            Model = model;
        }
    }    
}
