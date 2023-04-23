using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuais_Domain.Entities
{
    public class Manuais
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Deleted { get; set; }
    }
}
