using Mendi.Blazor.TrueSPA.Common.Commands;

namespace Mendi.Blazor.TrueSPA.CLI.Test.Tests
{
    public class BuildPageRoutesTest
    {
        [Test]
        public void BuildPageRoute_WithValidPathButNoMethod_ShouldProcessSuccessfully()
        {
            // Arrange
            var command = new BuildPageRoutes();
            //specify a valid blazor assembly project path
            var filePath = @"C:\Remote\Mendi.Blazor.TrueSPA\TestSample";

            Assert.DoesNotThrowAsync(async () =>
            {
                await command.Execute(path: filePath);
            });
        }

        [Test]
        public void BuildPageRoute_WithValidPathButWithExistingMethod_ShouldProcessSuccessfully()
        {
            // Arrange
            var command = new BuildPageRoutes();
            //specify a valid blazor assembly project path
            var filePath = @"C:\Remote\Mendi.Blazor.TrueSPA\TestSample";

            Assert.DoesNotThrowAsync(async () =>
            {
                await command.Execute(path: filePath, force: true);
            });
        }

    }
}
