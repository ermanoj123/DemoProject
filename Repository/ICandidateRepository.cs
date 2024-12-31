using DemoProject.Models;

namespace DemoProject.Repository
{
    public interface ICandidateRepository
    {
        Task<CandidateDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto);
    }
}
