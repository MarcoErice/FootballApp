namespace FootballApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Matches
    {
        public int Id { get; set; }

        public int Arena_Id { get; set; }

        public int HomeTeam_Id { get; set; }

        public int HomeTeam_Score { get; set; }

        public int GuestTeam_Id { get; set; }

        public int GuestTeam_Score { get; set; }

        public int Round { get; set; }

        public virtual Arenas Arenas { get; set; }

        public virtual Teams Teams { get; set; }

        public virtual Teams Teams1 { get; set; }
    }
}
