using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarCliente
{
    public class Cliente
    {
        [Key]
        public string? Email { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CPF { get; set; }    
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public DateTime DataNascimento { get; set; }

       
    }
}
