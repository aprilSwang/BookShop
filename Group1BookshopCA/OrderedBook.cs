namespace Group1BookshopCA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderedBook
    {
        [Key]
        public int OrderID { get; set; }

        public int? BookID { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
