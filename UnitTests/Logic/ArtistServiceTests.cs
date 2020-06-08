using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Logic.services;
using Xunit;

namespace SpotifyGenerator.Tests.Logic
{
    public class ArtistServiceTests
    {
        ArtistService artistService = new ArtistService(null);
        ArtistDTO artistDTO1 = new ArtistDTO {id= "2Ex4vjQ6mSh5woTlDWto6d", name= "Masayoshi Takanaka"};
        ArtistDTO artistDTO2 = new ArtistDTO { id = "5FsfZj0Mp6YwEWytuJUcWt", name = "Jinsang"};

        public ArtistServiceTests()
        {

            artistService.AddArtistToList(artistDTO1);
        }

        [Fact]
        public void AddArtistToList_ShouldAddArtistToList()
        {
            //Arrange

            //Act
            artistService.AddArtistToList(artistDTO2);
            //Assert
            Assert.Contains(artistService.Artists, artist => artist.Artistid == artistDTO2.id);
        }

        [Fact]
        public void RemoveArtistById_ShouldRemoveArtistFromList()
        {
            //Arrange
            artistService.AddArtistToList(artistDTO2);
            //Act
            artistService.RemoveArtistById(artistDTO1.id);
            //Assert
            Assert.DoesNotContain(artistService.Artists, artist => artist.Artistid == artistDTO1.id);
        }

        [Fact]
        public void GetAllArtistIds_ShouldGetAllArtistIds()
        {
            //Arrange
            var expected = "2Ex4vjQ6mSh5woTlDWto6d,5FsfZj0Mp6YwEWytuJUcWt,";
            //Act
            artistService.AddArtistToList(artistDTO2);
            var actual = artistService.GetAllArtistIds();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
