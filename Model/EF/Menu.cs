namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_menu { get; set; }

        [StringLength(200)]
        public string text { get; set; }

        [StringLength(200)]
        public string link { get; set; }

        public int? displayorđer { get; set; }

        [StringLength(50)]
        public string target { get; set; }

        public bool? status { get; set; }

        public int? id_menutype { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
