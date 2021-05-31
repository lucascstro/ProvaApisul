using System;
using System.IO;

namespace ProvaAdimissionalApisul.Services
{
    public class RegistroVotacao
    {
        //propriedades do registro
        public int Andar { get; set; }
        public char Elevador { get; set; }
        public char  Turno { get; set; }

        public RegistroVotacao(int andar, char elevador, char turno)
        {
            Andar = andar;
            Elevador = elevador;
            Turno = turno;
        }
    }
}
