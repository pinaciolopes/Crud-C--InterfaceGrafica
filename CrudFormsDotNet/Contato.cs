using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contato2
{
    
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public Contato(int id, string nome, string telefone, string email)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }
        public Contato()
        {
        }
    }
}

