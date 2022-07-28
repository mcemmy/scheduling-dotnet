using System;
using Shouldly;
using StaffScheduler.Core.Domain.Extensions;
using Xunit;

namespace StaffScheduler.Tests.CoreTest.Domain
{
    public class DateExtensionTest
    {
        [Fact]
        public void ShouldReturnDateOfLimit()
        {
            var date = new DateTime(2022, 05, 03);
            var expectedDate = new DateTime(2022, 03, 03);
            
            var maxDate = date.Within(2);

            maxDate.ShouldBe(expectedDate);
        }
    }
}
