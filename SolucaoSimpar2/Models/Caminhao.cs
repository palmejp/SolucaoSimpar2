using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolucaoSimpar2.Models
{
    [Table("tb_caminhao")]
    public class Caminhao
    {
        [Column("id")]
        [Display(Name = "CodigoCaminhao")]
        public int CaminhaoId { get; set; }

        [Column("ds_marca")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Column("ds_modelo")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Column("ds_placa")]
        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Column("ds_eixo")]
        [Display(Name = "Eixo")]
        public string Eixo { get; set; }

        public virtual ICollection<Motorista> Motoristas { get; set; }
    }
}
