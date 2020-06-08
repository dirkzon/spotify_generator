using SpotifyGen.Domain;
using SpotifyGen.Domain.DTO;
using SpotifyGenerator.Domain.DataTransferObjects;
using SpotifyGenerator.Domain.interfaces;
using SpotifyGenerator.Logic.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyGenerator.Logic.services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistAccess;
        public Playlist playlist;

        public PlaylistService(IPlaylistRepository access)
        {
            _playlistAccess = access;
        }

        public async Task<PlaylistDTO> CreatePlaylist(string playlistname, int limit, string artistid, string token, double[] answers)
        {
            var respone = await _playlistAccess.CreatePlaylist(limit, artistid, token, answers);
            playlist = new Playlist();
            playlist.Name = playlistname;
            playlist.Description = "New playlist, made with playlist generator";
            foreach (var trackdto in respone.tracks)
            {
                Track track = new Track { 
                    Id = trackdto.id,
                    Uri = trackdto.uri
                };
                playlist.Tracks.Add(track);
            }
            return respone;
        }

        public async Task<DbPlaylistDTO> PostPlaylist(UserDTO user, string token)
        {
            var postplaylist = new PostPlaylistDTO { 
                Name = playlist.Name,
                Description = playlist.Description,
                Uris = playlist.GetUris()
            };
            string id = await _playlistAccess.PostPlaylist(postplaylist, user, token);
            var result = new DbPlaylistDTO
            {
                CreationDate = DateTime.Now,
                PlaylistId = id,
                PlaylistName = playlist.Name,
                UserId = user.id
            };
            return result;
        }

        public string RemoveTrack(string trackid)
        {
            playlist.RemoveTrack(trackid);
            return trackid;
        }

        public string GetAllUris()
        {
            return playlist.GetUris();
        }
    }
}
