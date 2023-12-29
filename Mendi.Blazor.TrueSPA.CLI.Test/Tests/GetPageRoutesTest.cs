using Mendi.Blazor.TrueSPA.Common.Commands;

namespace Mendi.Blazor.TrueSPA.CLI.Test
{
    [TestFixture]
    public class GetPageRoutesTest
    {

        [Test]
        public void GenerateAppRoutesFromFile_WithValidFile_ShouldProcessSuccessfully()
        {
            // Arrange
            var command = new GetPageRoutes();
            //specify a valid blazor assembly project path
            var filePath = @"C:\Remote\Mendi.Blazor.TrueSPA\TestSample";

            Assert.DoesNotThrowAsync(async () =>
            {
                await command.Execute(filePath);
            });
        }

    }
}
