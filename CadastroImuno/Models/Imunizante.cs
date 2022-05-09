using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroImuno.Models
{
    [Table("Imunizante")]
    public class Imunizante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Fabricante { get; set; }
        [Required]
        public string AnoLote { get; set; }
    }


}
