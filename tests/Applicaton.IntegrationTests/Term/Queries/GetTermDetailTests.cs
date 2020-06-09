using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;
using GlossaryBuilder.Application.Term.Queries.GetTermDetail;

namespace GlossaryBuilder.Application.IntegrationTests.Term.Queries
{
    using static Testing;
    
    public class GetTermDetailTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTermId()
        {
            var command = new GetTermDetailQuery()
            {
                Id = 99
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldReturnTermAssociatedWithId()
        {
            var command = new CreateTermCommand
            {
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            var termCreated = await SendAsync(command);

            var query = new GetTermDetailQuery
            {
                Id = termCreated.Id
            };

            var result = await SendAsync(query);

            result.TermText.Should().Be(termCreated.TermText);
            result.Definition.Should().Be(termCreated.Definition);
        }
    }
}