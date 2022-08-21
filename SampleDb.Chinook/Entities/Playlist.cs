namespace SampleDb.Chinook.Entities;

public partial class Playlist
{
    // public Playlist()
    // {
    //     Tracks = new HashSet<Track>();
    // }

    public int PlaylistId { get; set; }
    public string? Name { get; set; }

    public ICollection<Track>? Tracks { get; set; }
}