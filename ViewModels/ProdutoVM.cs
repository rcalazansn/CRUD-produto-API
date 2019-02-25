using System;

namespace backend.ViewModels
{
    public class ProdutoPostVM
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public decimal Valor { get; set; }
    }

    public class ProdutoPutVM
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public decimal Valor { get; set; }

    }
}