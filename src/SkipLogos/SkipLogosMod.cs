using System.Reflection;
using MelonLoader;
using SkipLogos;

[assembly: AssemblyVersion(SkipLogosMod.Version)]
[assembly: MelonModInfo(typeof(SkipLogosMod), nameof(SkipLogos), SkipLogosMod.Version, "Laymain")]
[assembly: MelonModGame("Nine Dots Studio", "Outward")]

namespace SkipLogos
{
    public class SkipLogosMod : MelonMod
    {
        internal const string Version = "1.0.0";

        public override void OnApplicationStart()
        {
            StartupVideo.HasPlayedOnce = true;
        }
    }
}
