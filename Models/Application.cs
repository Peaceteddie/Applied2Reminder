using System.ComponentModel.DataAnnotations;

namespace Applied2Reminder;

public class Application
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    = "";
    [Required]
    public JobSource? Source { get; set; }
    = new JobSource() { Name = "", SourceType = JobSources.Company };
    public string? Description { get; set; }
    = "";
    public string? Url { get; set; }
    = "";
}
