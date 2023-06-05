using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    internal class Encryptor
    {
        public delegate char EncyrptFunction(char symbol);
        EncyrptFunction encryptFunc;
        public string key;

        public Encryptor(EncyrptFunction func, string key)
        {
            encryptFunc = func;
            this.key = key;
        }

        public char Encrypt(char symbol)
        {
            return encryptFunc(symbol);
        }
    }
}
