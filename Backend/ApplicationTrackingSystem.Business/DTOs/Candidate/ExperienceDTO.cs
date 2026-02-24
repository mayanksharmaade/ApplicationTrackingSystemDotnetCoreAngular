public record ExperienceDto(int Id,
    string JobTitle,
    string CompanyName,
    DateTime StartDate,
    DateTime? EndDate,
    bool IsCurrent,
    string? Description);