﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WhlMicroservices.AuthenticationCenter
{
    /// <summary>
    /// 非对称可逆加密  完后获取Token
    /// </summary>
    public class CustomRSSJWTervice : ICustomJWTService
    {
        #region Option注入
        private readonly JWTTokenOptions _JWTTokenOptions;
        public CustomRSSJWTervice(IOptionsMonitor<ConfigInformation> jwtTokenOptions)
        {
            this._JWTTokenOptions = jwtTokenOptions.CurrentValue.JWTTokenOptions;
        }
        #endregion

        public string GetToken(string userName, string password, User user)
        {


            #region 使用加密解密Key  非对称 
            string keyDir = Directory.GetCurrentDirectory();
            if (RSAHelper.TryGetKeyParameters(keyDir, true, out RSAParameters keyParams) == false)
            {
                keyParams = RSAHelper.GenerateAndSaveKey(keyDir);
            }
            #endregion

            //string jtiCustom = Guid.NewGuid().ToString();//用来标识 Token
            Claim[] claims = new[]
            {
                  new Claim(ClaimTypes.Name, user.username),
                  new Claim("id", user.id.ToString())
            };

            SigningCredentials credentials = new SigningCredentials(new RsaSecurityKey(keyParams), SecurityAlgorithms.RsaSha256Signature);

            var token = new JwtSecurityToken(
               issuer: this._JWTTokenOptions.Issuer,
               audience: this._JWTTokenOptions.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(60),//5分钟有效期
               signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(token);
            return tokenString;
        }
    }
}
