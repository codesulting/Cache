using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cache.Models
{
    public class Firearm
    {
        public int ID { get; set; }

        [Display(Name = "Manufacturer/Importer")]
        public string ManufacturerImporter { get; set; }

        public string Model { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        public string Type { get; set; }

        [Display(Name = "Caliber/Gauge")]
        public string CaliberGauge { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Acquired")]
        public DateTime DateAcquired { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        [Display(Name = "Purchase Location")]
        public string PurchaseLocation { get; set; }

        [Display(Name = "Sold/Transferred To")]
        public string SoldTransferredTo { get; set; }

        public string Notes { get; set; }
    }
}