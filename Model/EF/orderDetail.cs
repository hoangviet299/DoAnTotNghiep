namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orderDetail")]
    public partial class orderDetail
    {
        [Key]
        public int id_orderDetail { get; set; }

        public int? id_product { get; set; }

        public int? id_order { get; set; }

        public int? quantity { get; set; }

        public decimal? price { get; set; }

        public virtual order order { get; set; }

        public virtual product product { get; set; }
    }
}
