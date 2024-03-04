using System.IdentityModel.Tokens.Jwt;

namespace WebAppRazorpage.ApiModel.Base
{
    public class JwtDecode
    {
        public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            return token;
        }
        public static DecodedToken DecodeJwt(JwtSecurityToken token)
        {
            var keyId = token.Header.Kid;
            var audience = token.Audiences.ToList();
            var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
            return new DecodedToken { 
                KeyId = keyId 
            };  
        }
    }
}
