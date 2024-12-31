using DemoProject.Context;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _dbContext;

        public CandidateRepository(CandidateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            // Retrieve the existing candidate by email
            var existingCandidate = await _dbContext.CandidateDtos
                .FirstOrDefaultAsync(c => c.Email == candidateDto.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidateDto.FirstName;
                existingCandidate.LastName = candidateDto.LastName;
                existingCandidate.PhoneNumber = candidateDto.PhoneNumber;
                existingCandidate.PreferredCallTime = candidateDto.PreferredCallTime;
                existingCandidate.LinkedInProfileUrl = candidateDto.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidateDto.GitHubProfileUrl;
                existingCandidate.FreeTextComment = candidateDto.FreeTextComment;
                existingCandidate.UpdatedDate = candidateDto.CreatedDate;

                _dbContext.CandidateDtos.Update(existingCandidate);
            }
            else
            {
                await _dbContext.CandidateDtos.AddAsync(candidateDto);
            }
            await _dbContext.SaveChangesAsync();
            return  candidateDto;
        }
    }
}
