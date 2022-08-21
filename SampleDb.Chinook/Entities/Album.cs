// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable CollectionNeverUpdated.Global
namespace SampleDb.Chinook.Entities;

public partial class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; } = null!;
    public int ArtistId { get; set; }

    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}