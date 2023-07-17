using RestAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace RestAPI.Services;

public class PlaylistService
{

    IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

    public PlaylistService()
    {
        var _playlistCollection = new Dictionary<string, Playlist>();
        Playlist p1 = new Playlist("1", "p1", new() { "m1", "m2", "m3" });
        _playlistCollection.Add("1", p1);

        Playlist p2 = new Playlist("2", "p2", new() { "m4", "m5", "m6" });
        _playlistCollection.Add("2", p2);

        Playlist p3 = new Playlist("3", "p3", new() { "m7", "m8", "m9" });
        _playlistCollection.Add("3", p3);

        Playlist p4 = new Playlist("4", "p4", new() { "m10", "m11", "m12" });
        _playlistCollection.Add("4", p4);

        cache.Set("playlists", _playlistCollection);
    }

    public Dictionary<string, Playlist> Get()
    {
        return cache.Get("playlists") as Dictionary<string, Playlist> ?? new Dictionary<string, Playlist>();
    }

    public Playlist Get(string id)
    {
        var playlistCollection = Get();
        if (playlistCollection.TryGetValue(id, out var p))
        {
            return p;
        }
        throw new KeyNotFoundException($"Key '{id}' not found in the dictionary.");
    }
    public void Create(Playlist playlist)
    {
        var playlistCollection = Get();
        if (playlist == null || playlist.Id == null)
            throw new ArgumentNullException(nameof(playlist.Id), "Key cannot be null.");

        playlistCollection.Add(playlist.Id, playlist);
        cache.Set("playlists", playlistCollection);
        return;
    }

    public void Put(string id, Playlist playlist)
    {
        var playlistCollection = Get();
        if (playlistCollection.TryGetValue(id, out var p))
        {
            p.movieIds = playlist.movieIds;
            p.username = playlist.username;
            cache.Set("playlists", playlistCollection);
            return;
        }
        throw new KeyNotFoundException($"Key '{id}' not found in the dictionary.");
    }

    public void Delete(string id)
    {
        var playlistCollection = Get();
        playlistCollection.Remove(id);
        cache.Set("playlists", playlistCollection);
        return;
    }

    public void AddToPlaylistAsync(string id, string movieId)
    {
        var playlistCollection = Get();
        if (playlistCollection.TryGetValue(id, out var p))
        {
            p.movieIds.Add(movieId);
            cache.Set("playlists", playlistCollection);
            return;
        }
        throw new KeyNotFoundException($"Key '{id}' not found in the dictionary.");
    }

}