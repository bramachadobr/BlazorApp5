﻿using BlazorApp5.Classes;

namespace BlazorApp5.Servicos
{
    public interface INFService
    {
        public Task<bool> AddNF(NotaFiscal nf);
        public Task<bool> DeleteNF(NotaFiscal nf);
        public Task<NotaFiscal> UpdateNF(NotaFiscal nf);
        public Task<IEnumerable<NotaFiscal>> GetNotasFicasis();
        public Task<NotaFiscal> GetNotaFiscalById(Guid id);

        public Task<int> NumeroNotaFiscal();
    }
}
