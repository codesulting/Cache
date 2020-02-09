using System;
using System.ComponentModel.DataAnnotations;

namespace Cache.Models
{
    public class Firearm
    {
        public int ID { get; set; }

        public string ManufacturerImporter { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public string Type { get; set; }

        public string CaliberGauge { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAcquired { get; set; }

        public decimal Cost { get; set; }

        public string PurchaseLocation { get; set; }

        public string SoldTransferredTo { get; set; }
    }
}