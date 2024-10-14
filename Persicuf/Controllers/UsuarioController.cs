using DB.Data;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Persicuf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private PersicufContext _context;

        public UsuarioController( PersicufContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Usuario> Get() => _context.Usuarios.ToList();
    }
}
