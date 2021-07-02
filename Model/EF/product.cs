namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            orderDetails = new HashSet<orderDetail>();
        }

        [Key]
        public int id_product { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int? id_category { get; set; }

        public int? id_supplies { get; set; }

        public int? price { get; set; }

        [StringLength(200)]
        public string images { get; set; }

        public int? sale { get; set; }

        public int? hot { get; set; }

        public int? vieww { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [Column(TypeName = "ntext")]
        public string contentt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderDetail> orderDetails { get; set; }

        public virtual supplier supplier { get; set; }
    }
}
