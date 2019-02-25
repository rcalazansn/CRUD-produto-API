using backend.Data;
using backend.Models;

namespace backend.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoContext context)
            : base(context) { }
    }
}