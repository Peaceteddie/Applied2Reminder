using System.ComponentModel.DataAnnotations;

namespace Applied2Reminder;

public class JobSource
{
    [Key] public required string Name { get; set; }
    public JobSources SourceType { get; set; } = 0;
    public string? Description { get; set; }
    public string? Url { get; set; }
}


public enum JobSources
{
    Company,
    Recruiter
}