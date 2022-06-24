using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SolucaoSimpar2.Models
{
    
    [Table("tb_motorista")]
    public class Motorista
    {
        [Column("id")]
        [Display(Name = "Codigo")]
        public int MotoristaId { get; set; }

        [Column("ds_nome")]
        [Display(Name = "Nome")]
        public string PrimeiroNome { get; set; }

        [Column("ds_sobrenome")]
        [Display(Name = "Sobrenome")]
        public string UltimoNome { get; set; }

        [Display(Name = "Caminhão")]
        public int CaminhaoId { get; set; }
        public virtual Caminhao Caminhao { get; set; }

        public string Endereco { get; set; }

        public virtual ICollection<Viagem> Viagens { get; set; }
    }
    
}
