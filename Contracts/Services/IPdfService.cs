using EliteAthleteApp.Repositories;

namespace EliteAthleteApp.Contracts.Services
{
    public interface IPdfService
    {
        // GENERATES TRAINING MODULE IN PDF
        Task<byte[]> GetTrainingModulePDFAsync(int trainingModuleId);
    }
}
