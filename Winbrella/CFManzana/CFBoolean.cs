
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace CoreFoundation
{
    public class CFBoolean : CFType
    {
        public CFBoolean() { }
        public CFBoolean(IntPtr Number)
            : base(Number)
        {
        }       
    }
}
