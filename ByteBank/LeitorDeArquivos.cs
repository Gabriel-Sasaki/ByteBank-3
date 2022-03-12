using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        // PROPRIEDADES E ATRIBUTOS
        public string Arquivo { get; }

        // CONSTRUTORES
        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        // MÉTODOS
        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            throw new IOException();

            return "Linha do arquivo";

        }
    }
}
