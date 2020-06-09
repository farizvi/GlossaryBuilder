using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;
using GlossaryBuilder.Application.Term.Commands.UpdateTerm;

namespace GlossaryBuilder.Application.IntegrationTests.Term.Commands
{
    using static Testing;
    
    public class UpdateTermTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTermId()
        {
            var command = new UpdateTermCommand
            {
                Id = 99,
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTerm()
        {
            var command = new CreateTermCommand
            {
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            var termCreated = await SendAsync(command);

            var updateCommand = new UpdateTermCommand
            {
                Id = termCreated.Id,
                TermText = "Test Term Updated",
                Definition =  "Test Definition updated"
            };

            await SendAsync(updateCommand);

            var updatedTerm = await FindAsync<Domain.Entities.Term>(termCreated.Id);
            updatedTerm.TermText.Should().Be(updateCommand.TermText);
            updatedTerm.LastModified.Should().NotBeNull();
            
        }
    }
}