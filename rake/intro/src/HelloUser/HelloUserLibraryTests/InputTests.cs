using NUnit.Framework;
using HelloUserLibrary;
using NUnit.Framework.SyntaxHelpers;

namespace HelloUserLibraryTests.InputTests
{
    [TestFixture]
    public class when_getting_input_from_the_user
    {
        [ExpectedException(typeof(OnlyNumericInputException), ExpectedMessage = "Input must be alpha numeric, preferably a name")]
        [Test]
        public void should_not_allow_only_number()
        {
            new Input("123444");
            Assert.Fail("input class accepted all numeric values");
        }

        [Test]
        public void should_welcome_the_new_rake_user_to_the_dark_side()
        {
            Input input = new Input("Darth Vader");
            Assert.That(input.Response, Is.EqualTo("Welcome to the dark side Darth Vader.  Come learn the art of Rake."));
        }
    }
}
