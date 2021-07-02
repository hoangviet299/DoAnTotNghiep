namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            orderDetails = new HashSet<orderDetail>();
        }

        [Key]
        public int id_order { get; set; }

        public DateTime? create_date { get; set; }

        public int? id_customer { get; set; }

        [StringLength(200)]
        public string shipname { get; set; }

        [StringLength(200)]
        public string shipmobie { get; set; }

        [StringLength(200)]
        public string shipaddress { get; set; }

        [StringLength(200)]
        public string shipemail { get; set; }

        public int? status { get; set; }

        public virtual customer customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderDetail> orderDetails { get; set; }
    }
}
