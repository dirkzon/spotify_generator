﻿using SpotifyGenerator.Domain.interfaces;
using System.Threading.Tasks;

namespace SpotifyGenerator.Logic.services
{
    public class TokenService : ITokenService
    {
        private ITokenAccess _tokenAccess;

        public TokenService(ITokenAccess access)
        {
            _tokenAccess = access;
        }

        //haalt een token op aan de hand van de code
        public async Task<string> GetToken(string code, string redirect)
        {
            return await _tokenAccess.GetAccessToken(code, redirect);
        }
    }
}
