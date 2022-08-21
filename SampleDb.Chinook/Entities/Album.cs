﻿// ReSharper disable PartialTypeWithSinglePart

namespace SampleDb.Chinook.Entities;

public partial class Album
{
    public Album()
    {
        // Tracks = new HashSet<Track>();
    }

    public int AlbumId { get; set; }
    public string Title { get; set; } = null!;
    public int ArtistId { get; set; }

    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}