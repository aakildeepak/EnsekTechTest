using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Ensek.TechTest.MeterRead.Services.Interfaces;
using Moq;

namespace Ensek.TechTest.MeterRead.Services.Tests
{
    [TestFixture]
    public class MeterReadServiceTests
    {
        private Mock<IUserAccountRepository> _mockUserAccountRepository;
        private Mock<IMeterReadRepository> _mockMeterReadRepository;
        private Mock<IFileReadService> _mockFileReadService;
        private Mock<IMeterReadValidatorService> _mockValidatorService;
        private MeterReadService _service;

        [SetUp]
        public void Setup()
        {
            _mockUserAccountRepository = new Mock<IUserAccountRepository>();
            _mockMeterReadRepository = new Mock<IMeterReadRepository>();
            _mockFileReadService = new Mock<IFileReadService>();
            _mockValidatorService = new Mock<IMeterReadValidatorService>();
            _service = new MeterReadService(_mockUserAccountRepository.Object, _mockMeterReadRepository.Object, _mockFileReadService.Object, _mockValidatorService.Object);
        }

        [Test]
        public async Task UploadCsv_ReturnsCorrectCounts()
        {
            // Arrange
            var fakeMeterReadings = new List<MeterReadingDto>
            {
                new MeterReadingDto { AccountId = "2344", MeterReadingDateTime = "22/04/2019  09:24:00", MeterReadingValue = "10021" }
            };

            var fakeValidationResult = new Models.MeterReadValidationResult { IsValid = true };

            _mockFileReadService.Setup(service => service.ReadFile(It.IsAny<MemoryStream>())).Returns(fakeMeterReadings);
            _mockValidatorService.Setup(service => service.ValidateMeterReading(It.IsAny<MeterReadingDto>()))
                                 .Returns(fakeValidationResult);
            _mockUserAccountRepository.Setup(repo => repo.GetUserAccountAsync(It.IsAny<int>()))
                                      .ReturnsAsync(new UserAccountDto { Id = 1, AccountId = 1, FirstName = "First", LastName = "FirstLast" });
            _mockMeterReadRepository.Setup(repo => repo.MeterReadExistsAsync(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>()))
                                    .ReturnsAsync(false);

            var memoryStream = new MemoryStream();

            // Act
            var result = await _service.UploadCsv(memoryStream);

            // Assert
            Assert.AreEqual(fakeMeterReadings.Count, result.SuccessCount);
            Assert.AreEqual(0, result.FailureCount);
        }
    }
}
