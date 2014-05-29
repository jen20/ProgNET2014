using Microsoft.Reactive.Testing;
using NUnit.Framework;
using ReactiveUI.Testing;

namespace Ex3.Tests
{
    [TestFixture]
    public class PersonViewModelTests
    {
        [Test]
        public void ChangeNamePretendsToCallServerButOurTestRunsFast()
        {
            (new TestScheduler()).With(sched =>
            {
                var sut = new PersonViewModel {FirstName = "Jane", LastName = "Appleseed"};
                Assert.IsTrue(sut.ChangeName.CanExecute(null));

                sut.ChangeName.Execute(null);

                sched.AdvanceByMs(1000);
                Assert.AreEqual(null, sut.ServerResult);

                sched.AdvanceByMs(10000);
                Assert.AreEqual("Hello World", sut.ServerResult);
            });
        }

        [Test]
        public void ChangeNameCanOnlyBeExecutedIfFirstNameAndLastNameAreFilled()
        {
            var sut = new PersonViewModel();

            Assert.IsFalse(sut.ChangeName.CanExecute(null));

            sut.FirstName = "Jane";
            Assert.IsFalse(sut.ChangeName.CanExecute(null));

            sut.LastName = "Appleseed";
            Assert.IsTrue(sut.ChangeName.CanExecute(null));
        }

        [Test]
        public void FullNameIsMadeUpFromFirstNameAndLastName()
        {
            var sut = new PersonViewModel { FirstName = "Jane", LastName = "Appleseed" };

            Assert.AreEqual("Jane Appleseed", sut.FullName);
        }

        [Test]
        public void FullNameUpdatesWhenFirstNameChanges()
        {
            var sut = new PersonViewModel { FirstName = "Jane", LastName = "Appleseed" };
            sut.FirstName = "Joe";

            Assert.AreEqual("Joe Appleseed", sut.FullName);
        }

        [Test]
        public void FullNameUpdatesWhenLastNameChanges()
        {
            var sut = new PersonViewModel { FirstName = "Jane", LastName = "Appleseed" };
            sut.LastName = "Smith";

            Assert.AreEqual("Jane Smith", sut.FullName);
        }
    }
}
