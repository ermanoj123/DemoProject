using Azure;
using Azure.Core;
using DemoProject.Models;
using DemoProject.Repository;
using FluentResults;
using System.Text.RegularExpressions;

namespace DemoProject.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ILogger<CandidateService> _logger;
        public CandidateService(ICandidateRepository candidateRepository, ILogger<CandidateService> logger)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;   
        }
        public async Task<Result<CandidateResponse>> AddOrUpdateCandidateAsync(CandidatesRequest candidateDto)
        {
            var response = new CandidateResponse();
            if (!string.IsNullOrWhiteSpace(candidateDto.Email) && !IsValidEmail(candidateDto.Email))
            {
                _logger.LogInformation("Invalid email format: {@Email}", candidateDto.Email);
                return Result.Fail("Invalid email format.");
            }
            var candidate = new CandidateDto()
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                Email = candidateDto.Email,
                PreferredCallTime = candidateDto.PreferredCallTime,
                LinkedInProfileUrl = candidateDto.LinkedInProfileUrl,
                GitHubProfileUrl = candidateDto.GitHubProfileUrl,
                FreeTextComment = candidateDto.FreeTextComment,
                CreatedDate = DateTime.UtcNow,
            };
            var candidateResponse = await _candidateRepository.AddOrUpdateCandidateAsync(candidate);
            if (candidateResponse != null)
            {
                _logger.LogInformation("Candidate upserted successfully: {@candidateResponse}", candidateResponse);
                response.IsSuccess = true;
                return response;
            }
            _logger.LogInformation("Error occures while adding or updating the record: {@candidateResponse}", candidateResponse);
            response.IsSuccess = false;
                return response;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
