using Application.Common.Dtos;
using MediatR;

namespace Application.UrlModels
{
    public class CreateUrlModelCommand : IRequest<CreateUrlModelResponse>
    {
        public CreateUrlModelRequest Model { get; set; }  
        
        public CreateUrlModelCommand(CreateUrlModelRequest model)
        {
            Model = model;
        }
    }

}
