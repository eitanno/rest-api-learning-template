namespace RestAPI.Models;

public class Playlist
{

    public string? Id { get; set; }

    public string username { get; set; } = null!;

    public List<string> movieIds { get; set; } = null!;

    public Playlist()
    {

    }


    public Playlist(string Id, string username, List<string> movieIds)
    {
        this.Id = Id;
        this.username = username;
        this.movieIds = movieIds;
    }

}