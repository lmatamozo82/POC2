using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Deneva.Core.Domain.Builders;

namespace Deneva.Core.Domain.ValueObjects
{
    public class XToken
    {
        private string tokenString;
        private DateTime day;
        private string pid;

        public XToken(XTokenBuilder builder)
        {
            
            this.day= builder.day; 
            this.pid= builder.pid;

            if (builder.tokenString==null)
            {
                SetStringToken();
            }
            else
            {
                this.tokenString= builder.tokenString;
            }
        }

        //public XToken(string tokenString)
        //{ 
        //    this.tokenString = tokenString;
        //}
        //public XToken(string pid,DateTime day)
        //{
        //    this.pid = pid;
        //    this.day = day;
        //    GetStringToken(pid, day);
        //}

        private void SetStringToken()
        {
            tokenString= BitConverter.ToString(new SHA256CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(this.pid + ";" + this.day.ToString("yyyyMMdd")))).Replace("-", "").ToLower();
        }

        public string GetTokenString() 
        {
            return tokenString;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is XToken))
            {
                return false;
            }

            return (this.tokenString == ((XToken)obj).tokenString);
        }
    }
}
