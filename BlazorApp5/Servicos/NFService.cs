using BlazorApp5.Classes;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Servicos
{
    public class NFService : INFService
    {
        private readonly AppDataContext context;
        public NFService(AppDataContext _context) 
        {
            context = _context;
        }
        public Task<bool> AddNF(NotaFiscal nf)
        {
            try
            {
                context.NotaFiscals.Add(nf);
                context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteNF(NotaFiscal nf)
        {
            try
            {
                context.NotaFiscals.Remove(nf);
                context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteNFbyId(Guid id)
        {
            NotaFiscal item = await context.NotaFiscals.FirstOrDefaultAsync<NotaFiscal>(x => x.Id == id);
            if (item != null)
            {
                return await DeleteNF(item);
            }
            else
            { 
                return false;
            }
        }

        public Task<NotaFiscal> GetNotaFiscalById(Guid id)
        {
            var result = context.NotaFiscals.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotasFicasis()
        {
            var lista = await context.NotaFiscals.ToListAsync();
            return lista;
        }

        public Task<int> NumeroNotaFiscal()
        {
            int result = context.NotaFiscals.Count();
            result++;
            return Task.FromResult(result);
        }

        public async Task<NotaFiscal> UpdateNF(Guid idNota, NotaFiscal nota)
        {
            var nf = await context.NotaFiscals.FirstOrDefaultAsync(a => a.Id == idNota);

            if (nf != null)
            {
                nf.DataEmissao = nota.DataEmissao;
                nf.DataExercicio = nota.DataExercicio;
                nf.DescricaoDoServico = nota.DescricaoDoServico;
                nf.CodigoValidacao = nota.CodigoValidacao;
                nf.AliquotaIss = nota.AliquotaIss;
                nf.ValorIss = nota.ValorIss;
                nf.Desconto = nota.Desconto;
                nf.VecimentoIss = nota.VecimentoIss;
                nf.ValorTotal = nota.ValorTotal;
                nf.NumeroNF = nota.NumeroNF;
                nf.NomeFornecedor = nota.NomeFornecedor;
                nf.NomeCliente = nota.NomeCliente;
                nf.FornecedorId = nota.FornecedorId;
                nf.ClienteId = nota.ClienteId;
                context.Update(nf);
                context.SaveChanges();
                return nf;
            }
            else
            {
                return null;
            }
        }
    }
}
