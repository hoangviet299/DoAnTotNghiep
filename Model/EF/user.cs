namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Key]
        public int id_user { get; set; }

        [StringLength(200)]
        public string phone { get; set; }

        [StringLength(200)]
        public string avatar { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string confirmName { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string firrstName { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? email_verified_at { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(200)]
        public string about { get; set; }

        [StringLength(200)]
        public string remember_token { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }
    }
}
