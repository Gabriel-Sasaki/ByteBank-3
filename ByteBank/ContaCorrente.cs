// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        // PROPRIEDADES E ATRIBUTOS
        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }

        public int Agencia { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        // CONSTRUTORES
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
               // Lançando uma nova exceção do tipo ArgumentException com a devida mensagem
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                // Lançando uma nova exceção do tipo ArgumentException com a devida mensagem
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        // MÉTODOS E FUNÇÕES
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;

                // Lançando uma nova exceção com uma nova mensagem e passando o objeto ex de argumento, ou seja, criando uma InnerException (exceção interna)
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
    }
}
