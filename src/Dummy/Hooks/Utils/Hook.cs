using System;
using System.Reflection;
using MelonLoader;

namespace Dummy.Hooks.Utils
{
    public static class Hook
    {
        private static readonly MethodInfo InternalHook = typeof(Imports).GetMethod("Hook", BindingFlags.Static | BindingFlags.NonPublic);

        public static TDelegate Detour<TDelegate>(string targetClassName, string targetMethodName, TDelegate detourDelegate) where TDelegate : Delegate
        {
            IntPtr target = NET_SDK.SDK.GetClass(targetClassName).GetMethod(targetMethodName).Ptr;
            IntPtr detour = detourDelegate.Method.MethodHandle.GetFunctionPointer();
            InternalHook.Invoke(null, new object[] {target, detour});
            return target.ToDelegate<TDelegate>();
        }
    }
}
