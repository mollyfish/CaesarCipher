using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.Tests
{
    [TestClass()]
    public class MessageTests
    {
        static string realAlphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string origMsg = "Hi there";
        int[] offsets = new int[5] {3,6,18,64,0};
        static Random rnd = new Random();
        bool passed = false;

        [TestMethod()]
        public void newAlphabetTest()
        {
            
            for (int i = 0; i < offsets.Length; i++)
            {
                passed = false;
                string randAlphabet = new string(realAlphabet.OrderBy(r => rnd.Next()).ToArray());
                CaesarCipher.Message myMessage = new Message(randAlphabet, offsets[i], origMsg);
                CaesarCipher.Message.newAlphabet(myMessage);
                CaesarCipher.Message.Encode(myMessage);
                CaesarCipher.Message.Decode(myMessage, offsets[i]);
                if(myMessage.decodedMsg == myMessage.message)
                {
                     passed = true;
                } else
                {
                    passed = false;
                }
                Assert.IsTrue(passed);
            }
            //Console.WriteLine(randAlphabet);
            //Console.ReadLine();
        }
    }
}