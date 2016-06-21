namespace CFSE.Domain.CFSE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permission()
        {
            MtmRole2Permission = new HashSet<MtmRole2Permission>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEs { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEn { get; set; }

        [StringLength(100)]
        public string DescriptionEs { get; set; }

        [StringLength(100)]
        public string DescriptionEn { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MtmRole2Permission> MtmRole2Permission { get; set; }
    }
}
