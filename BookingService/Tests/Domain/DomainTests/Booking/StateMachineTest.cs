using Domain.DomainEntities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings
{
    public class StateMachineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
            //Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
            //Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Canceled));
            //Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
            //Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldSetStatusToRefoudedWhenRefoundingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Refound);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
            //Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldSetStatusToReopenedWhenReopeningABookingWithCanceledStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            booking.ChangeState(Action.Reopen);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
            //Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Refound);
            Assert.That(booking.CurrentStatus, Is.Not.EqualTo(Status.Refounded));
        }
    }
}
