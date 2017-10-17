using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class: KeyChanger
 * Author: Brendan Kelly
 * Date: 17/10/2017
 * Description: Static class to manage converting the format of LoRa keys and node dev addresses
 */

namespace KeyFormatterForMdot
{
    public static class KeyChanger
    {
        public const string INVALID_KEY = "Invalid key";
        private const int REQUIRED_KEY_LENGTH = 32;
        private const int REQUIRED_DEVADDR_LENGTH = 8;
        //converts a given server key to an mDot formatted key
        public static string FormatKey(string startKey)
        {
            //force lower case
            startKey = startKey.ToLower();

            //check key valid
            if (isValidKey(startKey))
            {
                //if key is valid build it
                List<string> keyParts = buildKeyPartList(startKey);
                return buildNewKey(keyParts);
            }

            else return INVALID_KEY;
        }

        //divides the key into a collection of two character key parts
        private static List<string> buildKeyPartList(string startKey)
        {
            //divide the key into 2 character key parts
            List<string> keyParts = new List<string>();
            int keyLen = startKey.Length;

            //take each character and the following character
            for (int i = 0; i < keyLen - 1; i += 2)
            {
                string currentSection = startKey[i].ToString();
                currentSection += startKey[i + 1].ToString();
                keyParts.Add(currentSection);
            }

            return keyParts;
        }

        //builds a new key from the a divided list of key parts
        private static string buildNewKey(List<string> keyParts)
        {
            string result = "";

            int nKeyParts = keyParts.Count();
            //add the required characters to each string
            for (int i = 0; i < nKeyParts; i++)
            {
                string currentPart = keyParts[i];
                result += "0x" + currentPart + ", ";
            }

            //remove the last comma-space
            result = result.Remove(result.Length - 2, 2);

            return result;
        }

        //makes sure a key is a somewhat valid key
        //returns true for valid key or false for invalid
        private static bool isValidKey(string startKey)
        {
            //if key isn't right length
            int keyLen = startKey.Length;
            if (keyLen != REQUIRED_KEY_LENGTH && keyLen != REQUIRED_DEVADDR_LENGTH)
                return false;

            //check every character
            foreach (char c in startKey)
            {
                //if character is not alphanumeric
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }
   
}
