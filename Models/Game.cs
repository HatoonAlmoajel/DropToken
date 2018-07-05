namespace DropTokenApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       /* public Game()
        {
            //Moves = new HashSet<Move>();
        }*/

        public int GameId { get; set; }

        public int Player1 { get; set; }

        public int Player2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        
      //  public virtual ICollection<Move> Moves { get; set; }

       // public virtual Player Player { get; set; }

       // public virtual Player Player3 { get; set; }
    }
}
