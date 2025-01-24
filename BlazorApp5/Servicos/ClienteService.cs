using BlazorApp5.Classes;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly AppDataContext context;
        public ClienteService(AppDataContext _context)
        {
            this.context = _context;
        }

        public async Task<Cliente> Get(Guid id)
        {
            var f =   context.Clientes.FirstOrDefaultAsync(a => a.Id == id);
            return f.Result;
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Update(Guid id, Cliente cliente)
        {
            var clienteBanco = await context.Clientes.FirstOrDefaultAsync(a => a.Id == id);
            if (clienteBanco != null)
            {
                clienteBanco.NomeFantasia = cliente.NomeFantasia;
                clienteBanco.RasaoSocial = cliente.RasaoSocial;
                clienteBanco.CNPJ_CPF = cliente.CNPJ_CPF;
                clienteBanco.Inscricao_estadual = cliente.Inscricao_estadual;
                clienteBanco.Inscricao_Municipal = cliente.Inscricao_Municipal;
                clienteBanco.CEP = cliente.CEP;
                clienteBanco.Endereco = cliente.Endereco;
                clienteBanco.Bairro = cliente.Bairro;
                clienteBanco.Cidade = cliente.Cidade;
                clienteBanco.Estado = cliente.Estado;
                clienteBanco.Email = cliente.Email;
                clienteBanco.Telefone = cliente.Telefone;
                clienteBanco.Numero = cliente.Numero;
                context.Clientes.Update(clienteBanco);
                context.SaveChanges();
                return clienteBanco;
            }
            else 
            {
                return null;
            }
        }

        public async Task<bool> Add(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(Guid idCliente)
        {
            try
            {
                Cliente f = await Get(idCliente);
                context.Clientes.Remove(f);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
