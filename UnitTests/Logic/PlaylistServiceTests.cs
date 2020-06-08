using SpotifyGenerator.Logic.models;
using SpotifyGenerator.Logic.services;
using Xunit;

namespace SpotifyGenerator.Tests
{
    public class PlaylistServiceTests
    {
        PlaylistService playlistService;
        Track track1;
        Track track2;

        public PlaylistServiceTests()
        {
            playlistService = new PlaylistService();
            playlistService.playlist = new Playlist();
            track1 = new Track
            {
                Id = "1ktTvtLqGslRYEbW2vrTCZ",
                Uri = "spotify:track:1ktTvtLqGslRYEbW2vrTCZ"
            };
            track2 = new Track
            {
                Id = "5T3Nbpj3ilbWKfusX57hH7",
                Uri = "spotify:track:5T3Nbpj3ilbWKfusX57hH7"
            };
            playlistService.playlist.Tracks.Add(track1);
            playlistService.playlist.Tracks.Add(track2);
        }

        [Fact]
        public void RemoveTrack_ShouldRemoveTrack()
        {
            //Arrange

            //Act
            playlistService.playlist.RemoveTrack("5T3Nbpj3ilbWKfusX57hH7");

            //Assert
            Assert.DoesNotContain(track2, playlistService.playlist.Tracks);
        }

        [Fact]
        public void GetUris_ShouldGetAllUris()
        {
            //Arrange
            var expected = "spotify:track:1ktTvtLqGslRYEbW2vrTCZ,spotify:track:5T3Nbpj3ilbWKfusX57hH7,";
            //Act
            var actual = playlistService.playlist.GetUris();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
