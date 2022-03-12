using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        // PROPRIEDADES E ATRIBUTOS
        public double Saldo { get; }

        public double ValorSaque { get; }

        // CONSTRUTORES
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }

        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }

    }
}
