using MediatR;

namespace Application.UrlModels
{
    public class DeleteUrlModelCommand : IRequest<bool>
    {
        public int Id { get; set; } 

    }

}
