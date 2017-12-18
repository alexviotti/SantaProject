using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SantaProject.Classes
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("screenname")]
        public string ScreenName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("password_clear_text")]
        public string PasswordClearText { get; set; }

        public static string Hash(string input)
        {
            byte[] HashValue, MessageBytes = Encoding.UTF8.GetBytes(input);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }
    }
}
