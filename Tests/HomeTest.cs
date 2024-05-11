using Applied2Reminder.Components.Pages;
using Bunit;
using Xunit;

namespace Applied2Reminder.Tests
{
    public class HomeTest
    {
        const string SOURCETYPECHECKBOXID = "#SourceTypeCheckbox";

        /// <summary>
        /// Checks the source type checkbox.
        /// </summary>
        /// <remarks>
        /// This method verifies that the source type checkbox has three states
        /// There is an implied assertion that the indeterminate state is true.
        /// There is an implied assertion that the checkbox starts unchecked.
        /// These state toggle in a pendulum fashion:
        /// 1. checked,
        /// 2. checked (implied indeterminate),
        /// 3. unchecked,
        /// 4. unchecked (implied indeterminate),
        /// 5. checked,
        /// and so on.
        /// </remarks>
        [Fact]
        public async Task CheckSourceTypeCheckbox()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Home>();
            await cut.InvokeAsync(() =>
            {
                var interactor = cut.Find(SOURCETYPECHECKBOXID);
                var checkbox = interactor.QuerySelector("input[type=checkbox]");

                // Implied assert: checkbox starts unchecked
                Assert.NotNull(checkbox);
                Assert.False(bool.Parse(checkbox.GetAttribute("value")!));

                // First interaction with the checkbox should check it
                interactor.Click();
                checkbox = interactor.QuerySelector("input[type=checkbox]");

                Assert.NotNull(checkbox);
                Assert.True(bool.Parse(checkbox.GetAttribute("value")!));

                // Second interaction with the checkbox should keep it checkeds
                interactor.Click();
                checkbox = interactor.QuerySelector("input[type=checkbox]");

                Assert.NotNull(checkbox);
                Assert.True(bool.Parse(checkbox.GetAttribute("value")!));

                // Third interaction with the checkbox should uncheck it
                interactor.Click();
                checkbox = interactor.QuerySelector("input[type=checkbox]");

                Assert.NotNull(checkbox);
                Assert.False(bool.Parse(checkbox.GetAttribute("value")!));
            });
        }
    }
}