namespace DropTokenApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
          
        }

        public int PlayerId { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string Gender { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public DateTime Registerd { get; set; }

        
    }
}
