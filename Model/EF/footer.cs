namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("footer")]
    public partial class footer
    {
        [Key]
        [StringLength(50)]
        public string id_footer { get; set; }

        [Column(TypeName = "ntext")]
        public string contentt { get; set; }

        public bool? status { get; set; }
    }
}
