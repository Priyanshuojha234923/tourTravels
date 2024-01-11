using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace tourTravels.Models
{
    public class encpassword
    {
        public string Encryption(string text)
        {
            byte[] b = ASCIIEncoding.ASCII.GetBytes(text);
            string enc = Convert.ToBase64String(b);
            return enc;
        }
        public string Decryption(string text)
        {
            byte[] b = Convert.FromBase64String(text);
            string dec = ASCIIEncoding.ASCII.GetString(b);
            return dec;
        }
    }
}