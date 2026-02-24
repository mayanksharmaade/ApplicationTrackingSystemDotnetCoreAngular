public record EmployerDashboardDto(
    int TotalJobs, int ActiveJobs, int TotalApplications,
    int Shortlisted, int Rejected, int UnderReview, int InterviewScheduled);