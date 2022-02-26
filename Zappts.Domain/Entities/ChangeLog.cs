using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zappts.Domain.Entities
{

    public class Changelog
    {
        public Changelog()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public string Processo { get; set; }
        public string NovoRegistro { get; set; }
        public string RegistroAnterior { get; set; }
        public string RegistroAtual { get; set; }
        public string RegistroExcluido { get; set; }
        public string Data { get; set; }

    }
}
