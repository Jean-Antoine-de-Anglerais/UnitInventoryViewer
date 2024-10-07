using HarmonyLib;
using NCMS;
using System.Reflection;
using UnityEngine;

namespace UnitInventoryViewer_NCMS
{
    [ModEntry]
    class Main : MonoBehaviour
    {
        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);

        void Awake()
        {
            harmony.Patch(AccessTools.Method(typeof(WindowCreatureInfo), nameof(WindowCreatureInfo.OnEnable)),
            postfix: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.OnEnable_Postfix))));
        }
    }
}
