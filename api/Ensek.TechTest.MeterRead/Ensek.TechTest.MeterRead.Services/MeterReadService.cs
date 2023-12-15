using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Ensek.TechTest.MeterRead.Services.Interfaces;

namespace Ensek.TechTest.MeterRead.Services
{
    public class MeterReadService : IMeterReadService
    {
        private readonly  IUserAccountRepository _userAccountRepository;
        private readonly IMeterReadRepository _meterReadRepository;
        private readonly IFileReadService _fileReadService;
        private readonly IMeterReadValidatorService _validatorService;
        public MeterReadService(
            IUserAccountRepository userAccountRepository,
            IMeterReadRepository meterReadRepository,
            IFileReadService fileReadService,
            IMeterReadValidatorService validatorService
            )
        {
            _userAccountRepository = userAccountRepository;
            _fileReadService = fileReadService;
            _meterReadRepository = meterReadRepository;
            _validatorService = validatorService;
        }

        public async Task<UploadResponse> UploadCsv(MemoryStream memoryStream)
        {
            int successCount = 0;

            try
            {
                var records = _fileReadService.ReadFile(memoryStream);

                foreach (var item in records)
                {
                    var readingCreated = await ProcessMeterReading(item);
                    if(readingCreated)
                    {
                        successCount += 1;
                    }
                }

                return new UploadResponse
                {
                    SuccessCount = successCount,
                    FailureCount = records.Count - successCount
                };
            }
            catch (Exception e)
            {
                return new UploadResponse
                {
                    Status = "Failure"
                };
            }
        }

        public async Task<bool> CreateReading(MeterReadingDto meterReading)
        {
            return await ProcessMeterReading(meterReading);
        }

        private async Task<bool> ProcessMeterReading(MeterReadingDto meterReading)
        {
            var validationResult = _validatorService.ValidateMeterReading(meterReading);

            if (validationResult.IsValid)
            {
                var userAccount = await _userAccountRepository.GetUserAccountAsync(validationResult.AccountId);

                if (userAccount != null)
                {
                    var meterReadExists = await _meterReadRepository.MeterReadExistsAsync(userAccount.Id, validationResult.ReadingDateTime, meterReading.MeterReadingValue);

                    if (!meterReadExists)
                    {
                        await _meterReadRepository.CreateReadingAsync(userAccount.Id, validationResult.ReadingDateTime, meterReading.MeterReadingValue);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
