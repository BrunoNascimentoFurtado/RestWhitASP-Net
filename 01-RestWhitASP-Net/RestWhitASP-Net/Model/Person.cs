using System.ComponentModel.DataAnnotations.Schema;

namespace RestWhitASP_Net.Model
{
    [Table ("Cliente")]
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }
        public string nome { get; set; }
        [Column("cadastro")]
        public DateTime Dt_cadastro { get; set; }
        [Column("nascimento")]
        public DateTime dt_nascimento { get; set; }
        public string? tipo { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public string? cep { get; set; }
        public string? logradouro { get; set; }
        public string? numero { get; set; }
        public string? bairro { get; set; }
        public string? complemento { get; set; }
        public string? cidade { get; set; }
        public string? uf { get; set; }
    }
}
