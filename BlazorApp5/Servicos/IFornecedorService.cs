using BlazorApp5.Classes;

namespace BlazorApp5.Servicos
{
    public interface IFornecedorService
    {
        public Task<bool> Add(Fornecedor fornecedor);
        public Task<bool> Delete(Guid idFornecedor);
        public Task<Fornecedor> Update(Guid id,  Fornecedor fornecedor);
        public Task<Fornecedor> Get(Guid id);
        public Task<IEnumerable<Fornecedor>> GetAllFornecedor();

    }
}
