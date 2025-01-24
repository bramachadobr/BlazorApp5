using BlazorApp5.Classes;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Servicos
{
    public class FornecedorService : IFornecedorService
    {
        private readonly AppDataContext context;
        public FornecedorService(AppDataContext _context)
        {
            this.context = _context;
        }

        public async Task<Fornecedor> Get(Guid id)
        {
            var f =   context.Fornecedore.FirstOrDefaultAsync(a => a.Id == id);
            return f.Result;
        }

        public async Task<IEnumerable<Fornecedor>> GetAllFornecedor()
        {
            return await context.Fornecedore.ToListAsync();
        }

        public async Task<Fornecedor> Update(Guid id, Fornecedor fornecedor)
        {
            var FornecedorBanco = await context.Fornecedore.FirstOrDefaultAsync(a => a.Id == id);
            if (FornecedorBanco != null)
            {
                FornecedorBanco.NomeFantasia = fornecedor.NomeFantasia;
                FornecedorBanco.RasaoSocial = fornecedor.RasaoSocial;
                FornecedorBanco.CNPJ_CPF = fornecedor.CNPJ_CPF;
                FornecedorBanco.Inscricao_estadual = fornecedor.Inscricao_estadual;
                FornecedorBanco.Inscricao_Municipal = fornecedor.Inscricao_Municipal;
                FornecedorBanco.CEP = fornecedor.CEP;
                FornecedorBanco.Endereco = fornecedor.Endereco;
                FornecedorBanco.Bairro = fornecedor.Bairro;
                FornecedorBanco.Cidade = fornecedor.Cidade;
                FornecedorBanco.Estado = fornecedor.Estado;
                FornecedorBanco.Email = fornecedor.Email;
                FornecedorBanco.Telefone = fornecedor.Telefone;
                FornecedorBanco.Numero = fornecedor.Numero;
                context.Fornecedore.Update(FornecedorBanco);
                context.SaveChanges();
                return FornecedorBanco;
            }
            else 
            {
                return null;
            }
        }

        public async Task<bool> Add(Fornecedor fornecedor)
        {
            try
            {
                context.Fornecedore.Add(fornecedor);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid idFornecedor)
        {
            try
            {
                Fornecedor f = await Get(idFornecedor);
                context.Fornecedore.Remove(f);
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
