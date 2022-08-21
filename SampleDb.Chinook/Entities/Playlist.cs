// ReSharper disable CollectionNeverUpdated.Global
namespace SampleDb.Chinook.Entities;

public partial class Playlist
{
    public int PlaylistId { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Track>? Tracks { get; set; }
}