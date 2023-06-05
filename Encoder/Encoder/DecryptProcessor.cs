using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder
{
    abstract class DecryptProcessor
    {
        public abstract char Process(char symbol);
    }

    internal class DecrementDecrypt : DecryptProcessor
    {
        public override char Process(char symbol)
        {
            return (char)(symbol - 1);
        }
    }
    internal class ZeroDecrypt : DecryptProcessor
    {
        public override char Process(char symbol)
        {
            return symbol;
        }
    }
    internal class IncrementDecrypt : DecryptProcessor
    {
        public override char Process(char symbol)
        {
            return (char)(symbol + 1);
        }
    }
    internal class NegativeDecrypt : DecryptProcessor
    {
        public override char Process(char symbol)
        {
            return (char)(255 - symbol);
        }
    }
    internal class DecryptContainer
    {
        public DecryptContainer(string key)
        {
            foreach (char item in key)
            {
                switch (item)
                {
                    case 'I':
                        decryptors.Add(new DecrementDecrypt());
                        break;
                    case 'D':
                        decryptors.Add(new IncrementDecrypt());
                        break;
                    case 'Z':
                        decryptors.Add(new ZeroDecrypt());
                        break;
                    case 'N':
                        decryptors.Add(new NegativeDecrypt());
                        break;
                }
            }
        }
        public List<DecryptProcessor> decryptors = new List<DecryptProcessor>();
    }
    internal class Decryptor
    {
        public string Decrypt(string key, string textToDecrypt)
        {
            DecryptContainer container = new DecryptContainer(key);
            string textDecrypt = "";

            int i = 0;
            foreach (char symbol in textToDecrypt)
            {
                char newSymbol = container.decryptors[i].Process(symbol);
                textDecrypt += newSymbol;
                if (i == container.decryptors.Count - 1) i = 0;
                else i++;
            }
            return textDecrypt;
        }
    }
}
