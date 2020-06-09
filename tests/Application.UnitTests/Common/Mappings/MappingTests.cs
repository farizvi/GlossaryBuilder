using AutoMapper;
using GlossaryBuilder.Application.Common.Mappings;
using NUnit.Framework;
using System;
using GlossaryBuilder.Application.Term.Queries.GetTermDetail;

namespace GlossaryBuilder.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        // [Test]
        // public void ShouldHaveValidConfiguration()
        // {
        //     _configuration.AssertConfigurationIsValid();
        // }
        
        [Test]
        [TestCase(typeof(Domain.Entities.Term), typeof(TermVM))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
