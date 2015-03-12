using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFoundation
{
    public struct CFRange 
    { 
        public int Location, Length; 
        public CFRange(int l, int len) 
        { 
            Location = l; 
            Length = len; 
        } 
    }
}
