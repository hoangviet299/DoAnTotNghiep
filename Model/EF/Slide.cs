namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_slide { get; set; }

        [StringLength(200)]
        public string images { get; set; }

        public int? displayorder { get; set; }

        [StringLength(200)]
        public string link { get; set; }

        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }

        public bool? status { get; set; }
    }
}
