using ApplicationTrackingSystem.Domain.Enums;

public record RegisterDto(string Email, string Password, UserRole Role);