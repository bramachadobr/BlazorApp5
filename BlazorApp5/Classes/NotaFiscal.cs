using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp5.Classes
{
    public class NotaFiscal
    {
        [Key]
        public Guid Id { get; set; }

        public string? urlQrCode { get; set; }

        public byte[]? QrCodeImage { get; set; }

        public int Numero { get; set; }
        [Required]
        public string? NumeroNF { get; set; }
        [Required]
        public DateTime? DataEmissao { get; set; }
        [Required]
        public string? CodigoValidacao { get; set; }
        [Required]
        public Guid FornecedorId { get; set; }
        [Required]
        public string? NomeFornecedor { get; set; }
        public Guid ClienteId { get; set; }
        [Required]
        public string? NomeCliente { get; set; }
        [Required]
        public string? DescricaoDoServico { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Desconto { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorIss { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AliquotaIss { get; set; }
        public DateTime? DataExercicio { get; set; }
        public DateTime? VecimentoIss { get; set; }
    }
}