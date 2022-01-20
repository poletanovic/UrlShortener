using MediatR;
using Application.Common.Dtos;

namespace Application.News
{
    public class UpdateNewsCommand : IRequest<bool>
    {
        public UpdateNewsRequest Model { get; set; }

        public UpdateNewsCommand(UpdateNewsRequest model)
        {
            Model = model;
        }

    }
}
