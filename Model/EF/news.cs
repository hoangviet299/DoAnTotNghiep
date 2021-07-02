namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [Key]
        public int id_new { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(250)]
        public string images1 { get; set; }

        [StringLength(250)]
        public string images2 { get; set; }

        [StringLength(250)]
        public string images3 { get; set; }

        public string description { get; set; }

        [Column(TypeName = "ntext")]
        public string contentt { get; set; }

        public int? hot { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }
    }
}
