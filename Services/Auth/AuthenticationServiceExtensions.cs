using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PLM.Models.EF;

namespace PLM.Services.Auth
{
    public class RolAppClaimsTransformation(plmDbContext context) : IClaimsTransformation
    {
        private readonly plmDbContext _context = context;

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;

            if (identity.HasClaim(c => c.Type == "UsuarioValido"))
                return principal;

            var nombreUsuario = identity.Name;

            var usuario = await _context.Usuarios
                .Include(u => u.IdRol)
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Activo == true);

            if (usuario is null)
                return principal;

            var nombresRoles = usuario.IdRol.Select(r => r.Nombre);

            identity.AddClaims(
                nombresRoles
                    .Select(rol => new Claim(identity.RoleClaimType, rol))
                    .Append(new Claim("UsuarioValido", "true"))
            );

            return principal;
        }
    }
}