public record CreateEmployerProfileDto(
    string CompanyName, string? Industry, string? CompanySize,
    string? Website, string? Description, string? Address, string? City, string? Country);