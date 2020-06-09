using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;
using GlossaryBuilder.Application.Term.Commands.DeleteTerm;
using GlossaryBuilder.Application.Term.Commands.UpdateTerm;
using GlossaryBuilder.Application.Term.Queries.GetTermDetail;
using GlossaryBuilder.Application.Term.Queries.GetTerms;

namespace GlossaryBuilder.WebUI.Controllers
{
    public class TermsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<TermsVM>> Get()
        {
            return await Mediator.Send(new GetTermsQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TermVM>> Get(int id)
        {
            return await Mediator.Send(new GetTermDetailQuery{ Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<CreatedTermVM>> Create(CreateTermCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTermCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTermCommand { Id = id });

            return NoContent();
        }
    }
}