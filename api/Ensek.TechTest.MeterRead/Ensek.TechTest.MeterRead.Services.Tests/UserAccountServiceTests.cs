using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Moq;

namespace Ensek.TechTest.MeterRead.Services.Tests
{
    [TestFixture]
    public class UserAccountServiceTests
    {
        private Mock<IUserAccountRepository> _mockRepository;
        private UserAccountService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IUserAccountRepository>();
            _service = new UserAccountService(_mockRepository.Object);
        }

        [Test]
        public async Task GetAllUsersAsync_ReturnsAllUsers()
        {
            // Arrange
            var fakeUsers = new List<UserAccountDto>
            {
                new UserAccountDto { Id = 1, AccountId = 1, FirstName = "First", LastName = "FirstLast"  },
                new UserAccountDto { Id = 2, AccountId = 2, FirstName = "Second", LastName = "SecondLast" }
            };

            _mockRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(fakeUsers);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.AreEqual(fakeUsers.Count, result.Count);

            _mockRepository.Verify(repo => repo.GetAllUsersAsync(), Times.Once);
        }
    }
}
