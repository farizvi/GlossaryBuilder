using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using GlossaryBuilder.Application.Term.Commands.CreateTerm;
using GlossaryBuilder.Application.Term.Queries.GetTerms;

namespace GlossaryBuilder.Application.IntegrationTests.Term.Queries
{
    using static Testing;
    
    public class GetTermsTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllTerms()
        {
            var command = new CreateTermCommand
            {
                TermText = "Test Term",
                Definition = "Test Definition"
            };

            await SendAsync(command);

            command = new CreateTermCommand
            {
                TermText = "Test Term2",
                Definition = "Test Definition2"
            };
            
            await SendAsync(command);
            
            var query = new GetTermsQuery();
            
            var result = await SendAsync(query);
            
            result.Should().NotBeNull();
            result.Terms.Should().HaveCount(2);
        }
    }
}