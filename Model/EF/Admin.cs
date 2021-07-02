namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_admin { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(200)]
        public string avatar { get; set; }

        [StringLength(50)]
        public string active { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(200)]
        public string remember_tolen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? update_at { get; set; }
    }
}
