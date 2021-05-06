using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyonProjesi.Models.Siniflar
{
    public class Cariler
    {
         [Key]
        public int Cariid { get; set; }

        [Column (TypeName = "VarChar")]
        [StringLength(30, ErrorMessage ="En Fazla 30 Karakter Girebilirsiniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsiniz")]
        [Required(ErrorMessage ="Bu Alanı Boş Bırakamazsınız...")]
        public string CariSoyad { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}