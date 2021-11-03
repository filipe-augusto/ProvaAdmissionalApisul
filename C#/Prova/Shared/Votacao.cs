using System.ComponentModel.DataAnnotations;

namespace Prova.Shared
{
    public class Votacao
    {
        public int andar { get; set; }
        [MaxLength(1, ErrorMessage = "Maximo um caracter.")]
        public char elevador { get; set; }
        [MaxLength(1, ErrorMessage = "Maximo um caracter.")]
        public char turno { get; set; }
    }
}
