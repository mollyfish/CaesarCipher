using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Message
    {
        public string alphabet;
        public int offset;
        public string message;
        public string newAlph;
        public string encodedMsg;
        public string decodedMsg;

        public Message(string alphabet, int offset, string message)
        {
            this.alphabet = alphabet;
            if(offset < 28)
            {
                this.offset = offset;
            } else
            {
                this.offset = offset % 27;
            }
            this.offset = Math.Abs(this.offset);
            this.message = message.ToUpper();
            this.newAlph = "";
            this.encodedMsg = "";
            this.decodedMsg = "";
        }

        public static string newAlphabet(Message msg)
        {
            string tail = msg.alphabet.Substring(0, msg.offset);
            for(int i = 0; i < (msg.alphabet.Length - msg.offset); i++)
            {
                msg.newAlph += msg.alphabet[i + msg.offset];
            }
            msg.newAlph += tail;
            return msg.newAlph;
        }
        public static string Encode(Message msg)
        {
            for(int i = 0; i < msg.message.Length; i ++)
            {
                char startingValue = msg.message[i];
                int index = msg.alphabet.IndexOf(startingValue.ToString());
                char newValue = msg.newAlph[index];
                msg.encodedMsg += newValue;
            }
            //Console.WriteLine("encoded: " + msg.encodedMsg);
            return msg.encodedMsg;
        }
        public static string Decode(Message msg, int key)
        {
            if (key == msg.offset)
            {
                for(int i = 0; i < msg.encodedMsg.Length; i++)
                {
                    char startingValue = msg.encodedMsg[i];
                    int index = msg.newAlph.IndexOf(startingValue.ToString());
                    char newValue = msg.alphabet[index];
                    msg.decodedMsg += newValue;
                }
                Console.WriteLine("Original: " + msg.message);
                Console.WriteLine("Encoded: " + msg.encodedMsg);
                Console.WriteLine("Decoded: " + msg.decodedMsg);
                return msg.decodedMsg;
            }
            else {
                Console.WriteLine("Incorrect offset of " + msg.offset);
                return msg.encodedMsg;
            }
        }
    }
}
