namespace SampleDb.Chinook.Entities;

public partial class MediaType
{
    // public MediaType()
    // {
    //     Tracks = new HashSet<Track>();
    // }

    public int MediaTypeId { get; set; }
    public string? Name { get; set; }

    public ICollection<Track>? Tracks { get; set; }
}