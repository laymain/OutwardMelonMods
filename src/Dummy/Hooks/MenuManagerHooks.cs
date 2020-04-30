using System;
using Dummy.Hooks.Utils;
using MelonLoader;

namespace Dummy.Hooks
{
    public static class MenuManagerHooks
    {
        public delegate void ToggleMapLowLevelDelegate(IntPtr selfPtr, IntPtr ownerPtr);

        public delegate void ToggleMapDelegate(ToggleMapLowLevelDelegate orig, MenuManager self, CharacterUI owner);

        public static event ToggleMapDelegate OnToggleMap;

        private static readonly ToggleMapLowLevelDelegate OrigToggleMap = Hook.Detour<ToggleMapLowLevelDelegate>("MenuManager", "ToggleMap", ToggleMap);

        private static void ToggleMap(IntPtr selfPtr, IntPtr ownerPtr)
        {
            if (OnToggleMap == null)
            {
                OrigToggleMap?.Invoke(selfPtr, ownerPtr);
                return;
            }
            try
            {
                OnToggleMap(OrigToggleMap, selfPtr.ToGameObject(ptr => new MenuManager(ptr)), ownerPtr.ToGameObject(ptr => new CharacterUI(ptr)));
            }
            catch (Exception e)
            {
                MelonModLogger.LogError($"An error occurred while executing MenuManagerHooks.OnToggleMap hooks: {e}");
            }
        }
    }
}
