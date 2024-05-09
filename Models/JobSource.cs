namespace Applied2Reminder;

public class JobSource
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required JobSources SourceType { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
}


public enum JobSources
{
    Company,
    Recruiter
}