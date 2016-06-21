namespace CFSE.Domain.CFSE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SecurityQuestion")]
    public partial class SecurityQuestion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Questions_Es { get; set; }

        [Required]
        [StringLength(500)]
        public string Questions_En { get; set; }

        public bool Enabled { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
