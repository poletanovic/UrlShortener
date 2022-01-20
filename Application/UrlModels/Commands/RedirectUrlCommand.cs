using Application.Common.Dtos;
using MediatR;

namespace Application.UrlModels
{
    public class RedirectUrlCommand : IRequest<string>
    {
        public string url { get; set; }

        public RedirectUrlCommand(string Url)
        {
            Url = url;
        }
    }

}
