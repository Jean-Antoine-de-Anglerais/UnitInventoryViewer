using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace UnitInventoryViewer_NativeModloader
{
    internal class Main : MonoBehaviour
    {
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
