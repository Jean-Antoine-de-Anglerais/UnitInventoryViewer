using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace UnitInventoryViewer_BepInEx
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "jean.worldbox.mods.UnitInventoryViewer_BepInEx";
        public const string pluginName = "Unit Inventory Viewer";
        public const string pluginVersion = "1.0.0.0";

        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        private bool _initialized = false;

        public void Update()
        {
            if (global::Config.gameLoaded && !_initialized)
            {
                harmony.Patch(AccessTools.Method(typeof(WindowCreatureInfo), nameof(WindowCreatureInfo.OnEnable)),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.OnEnable_Postfix))));

                _initialized = true;
            }
        }
    }
}
