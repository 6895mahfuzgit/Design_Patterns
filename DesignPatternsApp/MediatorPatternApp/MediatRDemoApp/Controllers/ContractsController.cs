using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemoApp.Context;
using MediatRDemoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private IMediator _mediator;

        public ContractsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<Contract> Get([FromRoute] Query query)
        {
            return await _mediator.Send(query);
        }
    }

    public class Query : IRequest<Contract>
    {
        public int Id { get; set; }
    }

    public class ContractHandler : IRequestHandler<Query, Contract>
    {
        private ContactContext _contactContext;

        public ContractHandler(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public async Task<Contract> Handle(Query request, CancellationToken cancellationToken)
        {
            return this._contactContext.Contractss.Where(x => x.Id == request.Id).SingleOrDefault();
        }
    }
}
