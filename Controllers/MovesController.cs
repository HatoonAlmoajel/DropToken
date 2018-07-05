using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DropTokenApi.Models;
using DropTokenApi.Services;

namespace DropTokenApi.Controllers
{
    public class MovesController : ApiController
    {
        private DBContext db = new DBContext();


        private MovesService obj = new MovesService();


        // GET: api/Games/3
        [ResponseType(typeof(Move))]
        public IQueryable GetMovesByGameId(int id)
        {



            var Moves = from b in db.Moves
                        where b.GameId == id
                        select b;
            if (Moves == null)
            {
                return null;
            }

            return Moves;






        }


        // GET: api/Moves
        public IQueryable<Move> GetMoves()
        {
            return db.Moves;
        }

        // GET: api/Moves/5
        [ResponseType(typeof(Move))]
        public IHttpActionResult GetMove(int id)
        {
            Move move = db.Moves.Find(id);
            if (move == null)
            {

                return NotFound();
            }

            return Ok(move);
        }

        // PUT: api/Moves/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMove(int id, Move move)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != move.MoveId)
            {
                return BadRequest();
            }

            db.Entry(move).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Moves
        [ResponseType(typeof(Move))]
        public IHttpActionResult PostMove(int gameid, int playerid, int col)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game game = db.Games.Find(gameid);
            if (game == null)
            {
                return NotFound();
            }
            else if (game.Status == "Done")
            {
                return BadRequest("Game Ended");

            }

            // check if it's player's turn
            var lastMove = db.Moves.Where(x => x.GameId == gameid).OrderByDescending(x => x.MoveId).First();
                         
           if( lastMove.PlayerId==playerid)
            {
                return BadRequest("It's not the player's turn");
            }


            Move move=obj.PostMove(gameid, playerid, col);
            if(move==null)
            {
                return BadRequest("Column is full or Col number is invalid");
            }
            //return CreatedAtRoute("DefaultApi", new { id = move.MoveId }, move);
            return Ok(move);
        }

        // DELETE: api/Moves/5
        [ResponseType(typeof(Move))]
        public IHttpActionResult DeleteMove(int id)
        {
            Move move = db.Moves.Find(id);
            if (move == null)
            {
                return NotFound();
            }

            db.Moves.Remove(move);
            db.SaveChanges();

            return Ok(move);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MoveExists(int id)
        {
            return db.Moves.Count(e => e.MoveId == id) > 0;
        }


    }
}