namespace SampleDb.Chinook.Entities;

public partial class Genre
{
    // public Genre()
    // {
    //     Tracks = new HashSet<Track>();
    // }

    public int GenreId { get; set; }
    public string? Name { get; set; }

    public ICollection<Track>? Tracks { get; set; }
}