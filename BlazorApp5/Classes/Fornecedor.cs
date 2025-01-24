using System.ComponentModel.DataAnnotations;

namespace BlazorApp5.Classes
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        [Required]
        public string? RasaoSocial { get; set; }
        [Required]
        public string? NomeFantasia { get; set; }
        [Required]
        public string? CNPJ_CPF { get; set; }
        [Required]
        public string? Inscricao_estadual { get; set; }
        [Required]
        public string? Inscricao_Municipal { get; set; }
        [Required]
        public string? Endereco { get; set; }
        [Required]
        public string? Bairro { get; set; }
        [Required]
        public int? Numero { get; set; }
        [Required]
        public string? CEP { get; set; }
        [Required]
        public string? Cidade { get; set; }
        [Required]
        public string? Estado { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefone { get; set; }

    }
}
