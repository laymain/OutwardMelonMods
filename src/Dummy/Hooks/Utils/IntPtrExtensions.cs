using System;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;

namespace Dummy.Hooks.Utils
{
    public static class IntPtrExtensions
    {
        public static IntPtr SafePointer(this Il2CppObjectBase instance)
        {
            return IL2CPP.Il2CppObjectBaseToPtr(instance);
        }

        public static unsafe T ToDelegate<T>(this IntPtr pointer)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(*(IntPtr*) (void*) pointer);
        }

        public static T ToGameObject<T>(this IntPtr pointer, Func<IntPtr, T> func) where T : class
        {
            return pointer != IntPtr.Zero ? func(pointer) : null;
        }
    }
}
