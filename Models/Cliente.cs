using System.ComponentModel.DataAnnotations;

namespace dotnet_web_api.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string ValorRenda { get; set; }
        public required string CPF { get; set; }
        public required bool Ativo { get; set; }

    }
}