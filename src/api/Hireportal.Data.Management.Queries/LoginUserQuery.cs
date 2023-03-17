using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Hireportal.Common;
using Hireportal.Common.Extensions;
using Hireportal.Data.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hireportal.Data.Request.Contracts;
using Hireportal.Entites.Profile;
using Hireportal.Data.Request.Queries;

namespace Hireportal.Data.Management.Queries
{
    internal class LoginUserQuery : IRequestHandler<LoginUserRequest, LoginResultDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Settings.JwtConfiguration configuration;

        public LoginUserQuery(IUnitOfWork unitOfWork, IOptions<Settings> options)
        {
            this.unitOfWork = unitOfWork;
            configuration = options.Value.Jwt;
        }

        public async Task<LoginResultDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            var entity = await repository.Get(f => f.UserName == request.Data.UserName, cancellationToken);
            if (entity == null)
            {
                return null;
            }
            var password = request.Data.Password.CreateHash();
            if (entity.Password != password)
            {
                return null;
            }

            var claims = new Dictionary<string, object>();
            claims.Add(ClaimTypes.NameIdentifier, entity.Id);
            claims.Add(ClaimTypes.GivenName, entity.UserName);
            claims.Add(ClaimTypes.Role, entity.UserType);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(configuration.ExpiresInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key)),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Claims = claims,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            var jwtToken = handler.WriteToken(token);
            return new LoginResultDto
            {
                Token = jwtToken,
                DisplayName = entity.UserName,
                UserType = entity.UserType
            };
        }
    }
}
