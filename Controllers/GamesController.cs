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
    public class GamesController : ApiController
    {
        private DBContext db = new DBContext();
        private GamesService obj = new GamesService();


        // GET: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGames()
        {
            var query = from b in db.Games
                        orderby b.GameId
                        select b;

            if (query == null)
            {
                return NotFound();
            }



            return Ok(query);





        }

        // GET: api/Games/3
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(db.Games.Where(x => x.GameId == id).FirstOrDefault());






        }


        // GET: api/Games/GetGamesInProgress
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGamesInProgress()
        {
            //{ "games" : ["gameid1", "gameid2"] }
            //var Games = db.Games.Where(x => x.Status == "InProgress");


            var Games = from b in db.Games
                        where b.Status == "InProgress"
                        select b.GameId;
            if (Games == null)
            {
                return NotFound();
            }
            


            return Ok(Games);






        }


        // GET: api/Games/3
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetStateOfTheGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            //TODO ,Add winner & if it's empty dont include it

            return Ok(db.Games.Where(x => x.GameId == id).FirstOrDefault());






        }

        // PUT: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult PutGame(int id, string Stat)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var game = db.Games.Find(id);


            if (game == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
           
            obj.PutGame(id,Stat);


         

           

            return Ok(db.Games.Where(x => x.GameId == id).FirstOrDefault());
        }

        // POST: api/Games
        [ResponseType(typeof(Game))]

        public IHttpActionResult CreateNewGame(int player1, int player2, string Stat)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var game = new Game { Player1 = player1, Player2 = player2, Status = Stat };
            db.Games.Add(game);
            db.SaveChanges();



            return CreatedAtRoute("DefaultApi", new { id = game.GameId }, game);

        }
        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public HttpResponseMessage DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            HttpResponseMessage response;
            if (game == null)
            {


                response = Request.CreateResponse(HttpStatusCode.NotFound, "Game not found ");

                return response;

            }
            else if (game.Status == "Done")
            {
                response = Request.CreateResponse(HttpStatusCode.Gone, "Game is already in DONE state.");

                return response;
            }


            db.Games.Remove(game);
            db.SaveChanges();


            response = Request.CreateResponse(HttpStatusCode.OK, game);

            return response;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.GameId == id) > 0;
        }

    }
}