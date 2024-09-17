using OnionDemo.Application.Command;
using OnionDemo.Domain.Entity;
using OnionDemo.Domain.Test.BookingTests.Fakes;
using Xunit;

namespace OnionDemo.Domain.Test.BookingTests
{
    public class AccommodationCommandTests
    {
        [Fact]
        public void TestCreateAccommodationById()
        {
            // Arrange
            var accommodationRepository = new FakeAccommodationRepository();
            var hostRepository = new FakeHostRepository();
            var unitOfWork = new FakeUnitOfWork();
            var accommodationCommand = new AccommodationCommand(accommodationRepository, hostRepository, unitOfWork);

            var host = new Host(); // Assuming you have a Host class
            hostRepository.AddHost(host);

            var fakeAccommodation = new FakeAccommodation(1, host.Id);

            // Act
            accommodationRepository.AddAccommodation(fakeAccommodation);
            var result = accommodationRepository.GetAccommodation(fakeAccommodation.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(host.Id, result.HostId);
        }

        // Add more tests as needed
    }
}

