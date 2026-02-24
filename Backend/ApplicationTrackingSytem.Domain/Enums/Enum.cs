namespace ApplicationTrackingSystem.Domain.Enums;

public enum UserRole { Admin, Employer, Candidate }

public enum ProficiencyLevel { Beginner, Intermediate, Advanced, Expert }

public enum JobType { FullTime, PartTime, Contract, Internship, Remote }

public enum ExperienceLevel { Entry, Mid, Senior, Lead, Executive }

public enum JobStatus { Draft, Active, Closed, Expired }

public enum ApplicationStatus
{
    Submitted,
    UnderReview,
    Shortlisted,
    Interview,
    OfferMade,
    Accepted,
    Rejected,
    Withdrawn
}

public enum InterviewType { Phone, Video, InPerson, Technical }

public enum EmailStatus { Pending, Sent, Failed }