using BlazorApp5.Classes;

namespace BlazorApp5.Servicos
{
    public class NFService : INFService
    {
        private readonly AppDataContext _appDataContext;
        public NFService(AppDataContext context) 
        { 
            _appDataContext = context;
        }
        public Task<bool> AddNF(NotaFiscal nf)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteNF(NotaFiscal nf)
        {
            throw new NotImplementedException();
        }

        public Task<NotaFiscal> GetNotaFiscalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotaFiscal>> GetNotasFicasis()
        {
            throw new NotImplementedException();
        }

        public Task<int> NumeroNotaFiscal()
        {
            throw new NotImplementedException();
        }

        public Task<NotaFiscal> UpdateNF(NotaFiscal nf)
        {
            throw new NotImplementedException();
        }
    }
}
