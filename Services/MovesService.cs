using System;
using System.Text;
using System.Linq;
using DropTokenApi.Models;

namespace DropTokenApi.Services
{
    public class MovesService
    {

        private DBContext db = new DBContext();

        private static char[][] Board = new char[4][];

        private GamesService obj = new GamesService();
      

        public Move PostMove(int gameid, int playerid, int col)
        {

            
            

            var numberofTokensinCol = from b in db.Moves
                        where b.Col == col
                        select b;

            // check if col is not full and col value is between 0-3
            if (numberofTokensinCol.Count() < 4 && col>=1 && col<4)
            {


                DateTime timeStamp = DateTime.Now;
                var move = new Move { GameId = gameid, PlayerId = playerid, Col = col, TimeStamp = timeStamp, Result = "stillGoing" };

                db.Moves.Add(move);
                db.SaveChanges();


                IQueryable<Move> GameMoves = getGameMoves(gameid);


                Board[0] = new char[4] { '.', '.', '.', '.' };
                Board[1] = new char[4] { '.', '.', '.', '.' };
                Board[2] = new char[4] { '.', '.', '.', '.' };
                Board[3] = new char[4] { '.', '.', '.', '.' };
                foreach (var item in GameMoves)
                {
                    int column = item.Col;

                    for (int row = 0; row < 4; row++)
                    {
                        if (Board[row][column] == '.' && item.PlayerId == playerid)
                        {

                            Board[row][column] = 'X';
                            break;
                        }
                    }
                }

                if (CheckIfWinMove(col, numberofTokensinCol.Count()-1) || GameMoves.Count() == 16)
                {
                    //update game status to Done 
                    var game = db.Games.Find(gameid);
                    obj.PutGame(gameid, "Done");





                }
                return move;
            }
            else
            {
                return null;

            }
            

           
            
        }

        
        public IQueryable<Move> getGameMoves(int gameid)
        {
            var GameMoves = from b in db.Moves
                            where (b.GameId == gameid)

                            select b;

            return GameMoves;
        }
        private static bool contains(String haystack, String needle)
        {
            return haystack.IndexOf(needle) >= 0;
        }

        
           




            

        public static bool CheckIfWinMove(int col,int row)
        {
            //TODO select moves from db


            char sym = 'X';
            char[] arr = new char[4];
            arr[0] = sym;
            arr[1] = sym;
            arr[2] = sym;
            arr[3] = sym;
            // Return new string key

           


           

            string streak = new string(arr);
            bool horizontal = contains(h(row), streak);
            bool vertical = contains(v(col), streak);
            bool diagonal1 = contains(d1(), streak);
            bool diagonal2 = contains(d2(), streak);

            if(horizontal||vertical||diagonal1||diagonal2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /**
         * The contents of the row (h for horizontal) containing the last played token.
         */
        private  static String h(int row)
        {
            

            return new String(Board[row]);
        }

        /**
         * The contents of the column(v for vertical) containing the last played token.
         */
        private static String v(int col)
        {
            StringBuilder sb = new StringBuilder(4);
            for (int h = 0; h < 4; h++)
            {
                sb.Append(Board[h][col]);
            }
            return sb.ToString();
        }

        /**
         * The contents of the "/" diagonal containing the last played token
         */
        private static String d1()
        {
            StringBuilder sb = new StringBuilder(4);
            int w = 3;
            for (int h = 0; h < 4; h++)
            {
                ////int w = mycol + myrow - h;
               // if (0 <= w && w < 4)
               // {
                    sb.Append(Board[h][w]);
                w--;
               // }
            }
            return sb.ToString();
        }

        /**
         * The contents of the "\" diagonal containing the last played chip
         * (coordinates have a constant difference).
         */
        private static String d2()
        {
            StringBuilder sb = new StringBuilder(4);
            for (int h = 0; h < 4; h++)
            {
                
               
                    sb.Append(Board[h][h]);
               
            }
            return sb.ToString();
        }
    }
}