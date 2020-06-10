using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Attributes
{
    public class TrangThaiAttribute : Attribute
    {
        internal TrangThaiAttribute(int code, string text)
        {
            Code = code;
            Text = text;
        }

        public  int Code { get; set; }

        public  string Text { get; set; }
    }
}
