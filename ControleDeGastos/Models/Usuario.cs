using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
        }
        public Usuario(int id, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
        }
    }
}
