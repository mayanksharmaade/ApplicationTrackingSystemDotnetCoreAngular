public record EducationDto(int Id,
    string Institution,
    string Degree,
    string? FieldOfStudy,
    int? StartYear,
    int? EndYear, 
    string? Grade);