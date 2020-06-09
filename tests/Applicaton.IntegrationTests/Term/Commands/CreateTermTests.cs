using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;

namespace GlossaryBuilder.Application.IntegrationTests.Term.Commands
{
    using static Testing;
    
    public class CreateTermTests : TestBase
    {
        [Test]
        public void ShouldValidateRequiredFields()
        {
            var command = new CreateTermCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTermWithValidValues()
        {
            var command = new CreateTermCommand
            {
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            var termCreated = await SendAsync(command);

            var term = await FindAsync<Domain.Entities.Term>(termCreated.Id);

            term.Should().NotBeNull();
            term.TermText.Should().Be(command.TermText);
            term.Definition.Should().Be(command.Definition);
        }
    }
}