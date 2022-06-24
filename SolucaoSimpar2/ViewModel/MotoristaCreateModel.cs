using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolucaoSimpar2.Models;

namespace SolucaoSimpar2.ViewModel
{
    public class MotoristaCreateModel
    {
        public Motorista Motorista { get; set; }
        public IEnumerable<SelectListItem> Caminhoes { get; set; }
    }
}
