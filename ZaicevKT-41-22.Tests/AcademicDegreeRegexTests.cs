using Xunit;

namespace ZaicevKT_41_22.Tests
{
    public class AcademicDegreeRegexTests
    {
        [Fact]
        public void AcademicDegreeName_ValidFormat_ShouldMatchPattern()
        {
            // Arrange
            var valid = "Кандидат наук";
            var invalid1 = "кандидат наук";
            var invalid2 = "Кандидат  наук";
            var invalid3 = "КандидатНаук";

            var pattern = @"^[А-ЯЁ][а-яё]+ [а-яё]+$";

            // Assert
            Assert.Matches(pattern, valid);
            Assert.DoesNotMatch(pattern, invalid1);
            Assert.DoesNotMatch(pattern, invalid2);
            Assert.DoesNotMatch(pattern, invalid3);
        }
    }
}
