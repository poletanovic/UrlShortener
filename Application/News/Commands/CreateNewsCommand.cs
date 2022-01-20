using Application.Common.Dtos;
using MediatR;

namespace Application.News
{
    public class CreateNewsCommand : IRequest<CreateNewsResponse>
    {
        public CreateNewsRequest Model { get; set; }  
        
        public CreateNewsCommand(CreateNewsRequest model)
        {
            Model = model;
        }
    }

}
