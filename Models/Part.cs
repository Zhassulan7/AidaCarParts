using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AidaCarParts.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        public string PartName { get; set; }
        public string PartCode { get; set; }
        public string Note { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Volume { get; set; }
        public string Weight { get; set; }
        public string Availibility { get; set; }
        public string Cost { get; set; }
        public string OEM { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
        public int SectionAndSubsectionId { get; set; }
        public int Numerate { get; set; }
    }
    public class SectionsAndSubsections
    {
        [Key]
        public int Id { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
    }
}
