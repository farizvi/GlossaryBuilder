using GlossaryBuilder.Application.Common.Interfaces;
using System;

namespace GlossaryBuilder.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
