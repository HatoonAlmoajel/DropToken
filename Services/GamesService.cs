using System.Linq;
using DropTokenApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DropTokenApi.Services
{
    public class GamesService
    {
        private DBContext db = new DBContext();



        public  void PutGame(int gameid,string Stat)
        {
            var game = db.Games.Find(gameid);
            game.Status = Stat;

            db.Entry(game).State = EntityState.Modified;



            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
        }

        }
}