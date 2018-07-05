namespace DropTokenApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Move
    {
        public int MoveId { get; set; }

        public int Col { get; set; }

        [StringLength(50)]
        public string Result { get; set; }

        public DateTime TimeStamp { get; set; }

        public int PlayerId { get; set; }

        public int GameId { get; set; }

      //  public virtual Game Game { get; set; }

     //   public virtual Player Player { get; set; }
    }
}
