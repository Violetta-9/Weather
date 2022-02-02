using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weather.Application.Queries;

namespace Weather.Application.QueryHandlers
{
    public class TestQueryHandler : IRequestHandler<TestQuery, int>
    {
        public TestQueryHandler()
        {
            
        }
        public async Task<int> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            return 0;
        }
    }
}
