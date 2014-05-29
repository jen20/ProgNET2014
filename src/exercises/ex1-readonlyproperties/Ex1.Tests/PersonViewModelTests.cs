using NUnit.Framework;

namespace Ex1.Tests
{
    [TestFixture]
    public class PersonViewModelTests
    {
        [Test]
        public void FullNameIsMadeUpFromFirstNameAndLastName()
        {
            var sut = new PersonViewModel {FirstName = "Jane", LastName = "Appleseed"};

            Assert.AreEqual("Jane Appleseed", sut.FullName);
        }

        [Test]
        public void FullNameUpdatesWhenFirstNameChanges()
        {
            var sut = new PersonViewModel {FirstName = "Jane", LastName = "Appleseed"};
            sut.FirstName = "Joe";

            Assert.AreEqual("Joe Appleseed", sut.FullName);
        }

        [Test]
        public void FullNameUpdatesWhenLastNameChanges()
        {
            var sut = new PersonViewModel {FirstName = "Jane", LastName = "Appleseed"};
            sut.LastName = "Smith";

            Assert.AreEqual("Jane Smith", sut.FullName);
        }
    }
}
