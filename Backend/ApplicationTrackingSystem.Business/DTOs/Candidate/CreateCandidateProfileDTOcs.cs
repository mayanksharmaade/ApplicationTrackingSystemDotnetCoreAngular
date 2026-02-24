public record CreateCandidateProfileDto(
    string FirstName,
    string LastName,
    string? PhoneNumber,
    DateTime? DateOfBirth,
    string? Address, 
    string? City,
    string? Country,
    string? Summary,
    string? LinkedInUrl,
    string? GitHubUrl);