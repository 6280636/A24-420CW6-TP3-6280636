using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A24_420CW6_TP3_6280636.Data;
using A24_420CW6_TP3_6280636.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace A24_420CW6_TP3_6280636.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly A24_420CW6_TP3_6280636Context _context;

        public ScoresController(A24_420CW6_TP3_6280636Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore()
        {
            //return await _context.Score.ToListAsync();
            if (_context == null || _context.Score == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Veuillez réessayez plus tard." });
            }

            return await _context.Score
                .Where(s => s.IsPublic == true)
                .OrderByDescending(s => s.scoreValue)
                .Take(10)
                .ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            //return await _context.Score.ToListAsync();
            if (_context.Score == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return user.Scores;
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                 new { Message = "Utilisateur non trouve." });


        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
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

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            if (_context.Score == null)
            {
                return Problem("Entity set xxxx is null.");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
            }

            // Buscar si el Score ya existe
            var existingScore = await _context.Score.FindAsync(score.Id);

            if (existingScore != null)
            {
                // Caso: Modificar un Score existente
                existingScore.IsPublic = score.IsPublic; // Actualizar la visibilidad

                // Actualiza otros campos si es necesario (opcional)
                //existingScore.scoreValue = score.scoreValue; // Por ejemplo

                // Guardar cambios
                await _context.SaveChangesAsync();
                return Ok(existingScore); // Retornar el Score actualizado
            }
            else
            {
                // Caso: Crear un nuevo Score
                score.User = user;
                user.Scores.Add(score); // Asociar el nuevo Score al usuario

                _context.Score.Add(score); // Agregar el nuevo Score a la base de datos
                await _context.SaveChangesAsync();

                // Retornar el nuevo Score creado
                return CreatedAtAction("GetComment", new { id = score.Id }, score);
            }

        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            var score = await _context.Score.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _context.Score.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreExists(int id)
        {
            return _context.Score.Any(e => e.Id == id);
        }
    }
}
