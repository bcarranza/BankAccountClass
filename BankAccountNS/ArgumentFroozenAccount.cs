using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    public class ArgumentFroozenAccount: ArgumentException
    {
        private string _message;

        public string getMessage
        {
            get { return _message; }
        }

        public ArgumentFroozenAccount(string message)
        {
            _message = message;
        }

    }
}
