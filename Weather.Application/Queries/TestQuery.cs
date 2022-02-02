using MediatR;

namespace Weather.Application.Queries
{
    public class TestQuery : IRequest<int>
    {
        public long TestParam { get; set; }
    }
}
