using Deneva.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneva.Core.Domain.Builders
{
    public class XTokenBuilder
    {
        public string tokenString;
        public DateTime day;
        public string pid;

        public XTokenBuilder() { }

        public XTokenBuilder WithPID(string pid) 
        {
            this.pid = pid;
            return this;
        }

        public XTokenBuilder WithDay(DateTime day)
        {
            this.day= day;
            return this;
        }

        public XTokenBuilder WitTokenString(string token)
        {
            this.tokenString= token;
            return this;
        }

        public XToken Build()
        { 
            return new XToken(this);
        }

    }
}
