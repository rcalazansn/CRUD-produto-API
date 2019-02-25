using System;

namespace backend.Models
{
    public class Produto : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public decimal Valor { get; set; }
    }
}