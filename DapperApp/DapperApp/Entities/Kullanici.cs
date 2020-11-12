using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Entities
{
    [Table("KULLANICI")]
    public class Kullanici
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("ADI")]
        public string Adi { get; set; }
        [Column("SEHIR")]
        public string Sehir { get; set; }
    }
}
