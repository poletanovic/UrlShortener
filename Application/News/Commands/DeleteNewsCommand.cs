using MediatR;

namespace Application.News
{
    public class DeleteNewsCommand : IRequest<bool>
    {
        public int Id { get; set; } 

    }

}
