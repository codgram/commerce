using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Organization
{
    public class TransferLine : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferLineId { get; set; }

        public int TransferHeaderId { get; set; }

        public TransferHeader? TransferHeader { get; set; }

        public int LineNo { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantityToShip { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantityToReceive { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantityShipped { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal QuantityReceived { get; set; }



    }
}
