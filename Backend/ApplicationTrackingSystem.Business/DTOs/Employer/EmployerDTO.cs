public record EmployerDto(
    int Id, int UserId, string CompanyName, string? Industry, string? CompanySize,
    string? Website, string? Description, string? LogoUrl, string? City, string? Country,
    bool IsApprovedByAdmin, DateTime CreatedAt);
