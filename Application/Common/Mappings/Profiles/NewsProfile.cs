using Application.Common.Dtos;
using Application.Common.Mappings;
using AutoMapper;
using NewsEntity = Domain.Entities.News;

namespace Application.Common.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            //Source -> Target
            CreateMap<CreateNewsRequest, NewsEntity>()
                .ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom((src, dest, destMember, context) => context.Items["AuthorId"]));
            CreateMap<NewsEntity, CreateNewsResponse>();

            CreateMap<UpdateNewsRequest, NewsEntity>();

            CreateMap<NewsEntity, GetNewsResponse>();
        }
    }
}
