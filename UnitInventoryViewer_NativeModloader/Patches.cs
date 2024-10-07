using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace UnitInventoryViewer_NativeModloader
{
    public static class Patches
    {
        public static void OnEnable_Postfix(WindowCreatureInfo __instance)
        {
            if (__instance.actor.inventory != null && __instance.actor.inventory.getResources().Count > 0)
            {
                __instance.showCustomStat("resources", __instance.actor.inventory.getResources());
            }
        }

        public static void showCustomStat(this WindowCreatureInfo instance, string pID, Dictionary<string, ResourceContainer> dict)
        {
            Text text = instance.text_description;
            text.text = text.text + LocalizedTextManager.getText(pID);
            for (int i = 0; i < dict.Count; i++)
            {
                text.text += "\n";
            }
            Text text2 = instance.text_values;
            text2.text = text2.text + ((dict != null) ? string.Join("\n", dict.Select(r => $"{LocalizedTextManager.getText(r.Value.id)}: {r.Value.amount}")) : null) + "\n";
        }
    }
}
