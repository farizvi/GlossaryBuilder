using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;
using GlossaryBuilder.Application.Term.Commands.DeleteTerm;

namespace GlossaryBuilder.Application.IntegrationTests.Term.Commands
{
    using static Testing;
    
    public class DeleteTermTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTermId()
        {
            var command = new DeleteTermCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }
        
        [Test]
        public async Task ShouldDeleteTerm()
        {
            var command = new CreateTermCommand
            {
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            var termCreated = await SendAsync(command);


            await SendAsync(new DeleteTermCommand
            {
                Id = termCreated.Id
            });

            var term = await FindAsync<Domain.Entities.Term>(termCreated.Id);

            term.Should().BeNull();
        }
    }
}