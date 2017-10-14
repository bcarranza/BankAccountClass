using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Definición de una clase que lleva el control de una cuenta bancaria
    /// </summary>
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        private string _customerName;
        private double _balance;
        private bool _frozen;

        /// <summary>
        /// Constructor de la clase administradora de cuenta bancaria
        /// </summary>
        /// <param name="customerName">Nombre inicial del cliente de la cuenta bancaria.</param>
        /// <param name="balance">Deposito o saldo inicial de la cuenta.</param>
        public BankAccount (string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        /// <summary>
        /// Propiedad publica encargada de proporcionar el nombre de la cuenta.
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
        }

        /// <summary>
        /// Propiedad publica encargada de proporcionar el saldo actual de la cuenta.
        /// </summary>
        public double Balance
        {
            get { return _balance; }
        }

        /// <summary>
        /// Método encargado de debitar un monto a la cuenta bancaria
        /// </summary>
        /// <param name="amount"> monto a debitar </param>
        public void Debit(double amount)
        {
            if (_frozen)
            {
                throw new ArgumentFroozenAccount("Account frozen");
            }
            if (amount>_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            
            if(amount<=0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            _balance -= amount; //codigo realizado intencionalmente para que falle.
        }

        /// <summary>
        /// Metodo que acredita dinero a nuestra cuenta
        /// </summary>
        /// <param name="amount">Monto a acreditar</param>
        public void Credit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            _balance += amount;
        }

        /// <summary>
        /// Congelar una cuenta bancaria.
        /// </summary>
        public void FreezeAccount()
        {
            _frozen = true;
        }
        /// <summary>
        /// Descongelar una cuenta bancaria.
        /// </summary>
        public void UnfreezeAccount()
        {
            _frozen = false;
        }

        /// <summary>
        /// Metodo principal de ejecución
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                BankAccount ba = new BankAccount("Roxana Zeceña", 1000);
                ba.Credit(500);
                ba.Debit(250);
                Console.WriteLine("Current balance is ${0}", ba.Balance);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
