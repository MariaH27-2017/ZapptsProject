using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zappts.Domain.Entities
{
    public class Livros : BaseEntity
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
        public int QtdPaginas { get; set; }

    }
}
