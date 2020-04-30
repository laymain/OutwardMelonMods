using System.Reflection;
using Dummy;
using Dummy.Hooks;
using Dummy.Hooks.Utils;
using MelonLoader;

[assembly: AssemblyVersion(DummyMod.Version)]
[assembly: MelonModInfo(typeof(DummyMod), nameof(Dummy), DummyMod.Version, "Laymain")]
[assembly: MelonModGame("Nine Dots Studio", "Outward")]

namespace Dummy
{
    public class DummyMod : MelonMod
    {
        internal const string Version = "0.0.1";

        public override void OnApplicationStart()
        {
            MenuManagerHooks.OnToggleMap += ToggleMap;
        }

        private static void ToggleMap(MenuManagerHooks.ToggleMapLowLevelDelegate orig, MenuManager self, CharacterUI owner)
        {
            MelonModLogger.Log($"{SplitScreenManager.Instance.LocalPlayers.get_Item(self.MapOwnerPlayerID).AssignedCharacter.Name} toggled the map");
            orig(self.SafePointer(), owner.SafePointer());
        }
    }
}
