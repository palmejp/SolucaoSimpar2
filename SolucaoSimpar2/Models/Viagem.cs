using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolucaoSimpar2.Models
{
    [Table("tb_viagem")]
    public class Viagem
    {
        [Column("id")]
        [Display(Name = "CodigoViagem")]
        public int ViagemId { get; set; }

        [Column("dt_viagem")]
        [Display(Name = "Data da Viagem")]
        public string DataViagem { get; set; }

        [Column("ds_local_entrega")]
        [Display(Name = "Local de Entrega")]
        public string LocalEntrega { get; set; }

        [Column("ds_local_saida")]
        [Display(Name = "Local de Saida")]
        public string LocalSaida { get; set; }

        [Column("ds_km_total")]
        [Display(Name = "Km Total")]
        public string KmTotal { get; set; }

        [Display(Name = "Motorista")]
        public int MotoristaId { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}
