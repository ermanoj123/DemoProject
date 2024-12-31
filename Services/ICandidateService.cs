using DemoProject.Models;
using FluentResults;

namespace DemoProject.Services
{
    public interface ICandidateService
    {
        Task<Result<CandidateResponse>> AddOrUpdateCandidateAsync(CandidatesRequest candidateDto);
    }
}
