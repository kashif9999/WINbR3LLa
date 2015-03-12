
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;

namespace CoreFoundation
{
    public class CFDictionary : CFType
    {        
        public CFDictionary() { }

        public CFDictionary(IntPtr dictionary) : base(dictionary)
        {
        }

        unsafe public CFDictionary(string[] keys,IntPtr[] values)
        {
            IntPtr[] keyz = new IntPtr[keys.Length];  
            for (int i = 0; i < keys.Length; i++)
            {
                keyz[i] = new CFString(keys[i]);                
            }
            CFDictionaryKeyCallBacks kcall = new CFDictionaryKeyCallBacks();

            CFDictionaryValueCallBacks vcall = new CFDictionaryValueCallBacks();
            base.typeRef = CFLibrary.CFDictionaryCreate(IntPtr.Zero,keyz,values,keys.Length,ref kcall,ref vcall);            
        }
       
        /// <summary>
       /// Returns the value associated with a given key.
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
        public CFType GetValue(string value)
        {
            try
            {
                return new CFType(CFLibrary.CFDictionaryGetValue(base.typeRef, new CFString(value)));
            }
            catch (Exception ex)
            {
                return new CFType(IntPtr.Zero);
            }

        }
        /// <summary>
        /// Returns the number of key-value pairs in a dictionary
        /// </summary>
        /// <returns></returns>
        public int Length
        {
            get
            {
                return CFLibrary.CFDictionaryGetCount(base.typeRef);
            }
        }    


        public static implicit operator CFDictionary(IntPtr value)
        {
            return new CFDictionary(value);
        }

        public static implicit operator IntPtr(CFDictionary value)
        {
            return value.typeRef;
        }

        public static implicit operator string(CFDictionary value)
        {
            return value.ToString();
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct CFDictionaryKeyCallBacks
        {
            int version;
            CFDictionaryRetainCallBack retain;
            CFDictionaryReleaseCallBack release;
            CFDictionaryCopyDescriptionCallBack copyDescription;
            CFDictionaryEqualCallBack equal;
            CFDictionaryHashCallBack hash;

        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct CFDictionaryValueCallBacks
        {
            int version;
            CFDictionaryRetainCallBack retain;
            CFDictionaryReleaseCallBack release;
            CFDictionaryCopyDescriptionCallBack copyDescription;
            CFDictionaryEqualCallBack equal;
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr CFDictionaryRetainCallBack(IntPtr allocator, IntPtr value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CFDictionaryReleaseCallBack(IntPtr allocator, IntPtr value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr CFDictionaryCopyDescriptionCallBack(IntPtr value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr CFDictionaryEqualCallBack(IntPtr value1, IntPtr value2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr CFDictionaryHashCallBack(IntPtr value);
    }

 }
