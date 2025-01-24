using BlazorApp5.Classes;

namespace BlazorApp5.Servicos
{
    public interface IClienteService
    {
        public Task<bool> Add(Cliente idCliente);
        public Task<bool> Delete(Guid idCliente);
        public Task<Cliente> Update(Guid id,  Cliente cliente);
        public Task<Cliente> Get(Guid id);
        public Task<IEnumerable<Cliente>> GetAllCliente();

    }
}
