using Application.Common.Dtos;
using Application.Common.Mappings;
using AutoMapper;
using UrlModelEntity = Domain.Entities.UrlModel;

namespace Application.Common.Profiles
{
    public class UrlModelProfile : Profile
    {
        public UrlModelProfile()
        {
            //Source -> Target
            CreateMap<CreateUrlModelRequest, UrlModelEntity>()
                .ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom((src, dest, destMember, context) => context.Items["AuthorId"]));
            CreateMap<UrlModelEntity, CreateUrlModelResponse>();

            //CreateMap<UpdateNewsRequest, NewsEntity>();

            CreateMap<UrlModelEntity, GetUrlModelResponse>();
        }
    }
}
