using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string realAlphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string origMsg = "I am starting to really like c sharp";
            int[] offsets = new int[5] { 3, -6, 18, 34, 0 };
            Random rnd = new Random();
            bool passed = false;

            for (int i = 0; i < offsets.Length; i++)
            {
                passed = false;
                string randAlphabet = new string(realAlphabet.OrderBy(r => rnd.Next()).ToArray());
                CaesarCipher.Message myMessage = new Message(randAlphabet, offsets[i], origMsg);
                if(offsets[i] > 27)
                {
                    offsets[i] = offsets[i] % 27;
                }
                if(offsets[i] < 0)
                {
                    offsets[i] = Math.Abs(offsets[i]);
                }
                CaesarCipher.Message.newAlphabet(myMessage);
                CaesarCipher.Message.Encode(myMessage);
                CaesarCipher.Message.Decode(myMessage, offsets[i]);
                if (myMessage.decodedMsg == myMessage.message)
                {
                    passed = true;
                }
                else
                {
                    passed = false;
                }
                Console.WriteLine(passed);
            }
            //CaesarCipher.Message myMessage = new Message(" ABCDEFGHIJKLMNOPQRSTUVWXYZ", 10, "Hi there");
            //CaesarCipher.Message.newAlphabet(myMessage);
            //CaesarCipher.Message.Encode(myMessage);
            //CaesarCipher.Message.Decode(myMessage, 10);
            Console.ReadLine();
        }
    }
}
