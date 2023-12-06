using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMgmtCFA.Models;
using System.Collections;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryMgmtCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly LibraryMgmtCFADbContext _context;
        IConfiguration configuration;

        public RegistrationsController(LibraryMgmtCFADbContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
          if (_context.Registration == null)
          {
              return NotFound();
          }
            return await _context.Registration.ToListAsync();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
          if (_context.Registration == null)
          {
              return NotFound();
          }
            var registration = await _context.Registration.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Registration>> GetRegistration(string email, string password)
        {
            Hashtable err = new Hashtable();
            try
            {
                var authUser = await _context.Registration.FirstOrDefaultAsync(record => record.email == email && record.password == password);
                {
                    return Ok(authUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet("{email}/{password}")]
        //public IActionResult GetRegistration(string email, string password)
        //{
        //    try
        //    {
        //        var authUser =  _context.Registration.FirstOrDefault(i => i.email == email && i.password == password);
        //        if (authUser == null)
        //        {
        //            return Unauthorized();
        //        }
                
//                    var issuer = configuration["Jwt:Issuer"];
//                    var audience = configuration["Jwt:Audience"];
//                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
//                    var signingCredentials = new SigningCredentials(
//                                            new SymmetricSecurityKey(key),
//                                            SecurityAlgorithms.HmacSha512Signature
//                                        );
//                    var claims = new List<Claim>
//{
//      new Claim(JwtRegisteredClaimNames.Email, email),
//};




//                    var expires = DateTime.UtcNow.AddMinutes(10);
//                    var tokenDescriptor = new SecurityTokenDescriptor
//                    {
//                        Subject = new ClaimsIdentity(claims),
//                        Expires = DateTime.UtcNow.AddMinutes(10),
//                        Issuer = issuer,
//                        Audience = audience,
//                        SigningCredentials = signingCredentials
//                    };
//                    var tokenHandler = new JwtSecurityTokenHandler();
//                    var token = tokenHandler.CreateToken(tokenDescriptor);
//                    var jwtToken = tokenHandler.WriteToken(token);
//                    return Ok(jwtToken);
                
        //     }
            
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // PUT: api/Registrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            if (id != registration.userid)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Registrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
          if (_context.Registration == null)
          {
              return Problem("Entity set 'LibraryMgmtCFADbContext.Registration'  is null.");
          }
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.userid }, registration);
        }

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            if (_context.Registration == null)
            {
                return NotFound();
            }
            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationExists(int id)
        {
            return (_context.Registration?.Any(e => e.userid == id)).GetValueOrDefault();
        }
    }
}
