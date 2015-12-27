namespace HrManagement.DLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Column("House/Road")]
        [Required]
        [StringLength(50)]
        public string House_Road { get; set; }

        [StringLength(50)]
        public string PoliceStation { get; set; }

        [StringLength(50)]
        public string PostOffice { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
