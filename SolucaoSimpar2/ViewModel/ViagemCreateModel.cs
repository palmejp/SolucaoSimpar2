using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolucaoSimpar2.Models;

namespace SolucaoSimpar2.ViewModel
{
    public class ViagemCreateModel
    {
        public Viagem Viagem { get; set; }
        public IEnumerable<SelectListItem> Motoristas { get; set; }
    }
}
