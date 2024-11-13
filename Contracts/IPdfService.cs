using EliteAthleteApp.Repositories;

namespace EliteAthleteApp.Contracts
{
    public interface IPdfService
    {
        // GENERATES TRAINING MODULE IN PDF
        Task<byte[]> GetTrainingModulePDFAsync(int trainingModuleId);
    }
}
