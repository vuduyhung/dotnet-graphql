using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Query
{
    // resolver funtions
    // public string Hello()
    // {
    //     return "Hello, World!";
    // }

    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();

        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    [GraphQLDescription("Retrieves a specific playlist.")]
    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        var playlist = new Playlist(response);

        return playlist;
    }
}
