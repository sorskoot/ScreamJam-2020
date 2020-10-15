using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

#if UNITY_EDITOR
public class GroupInto
{
    [MenuItem(@"Sorskoot/Tools/Group Into", false)]        
    [MenuItem(@"GameObject/Sorskoot/Group Into", false, 99)]        
    public static void Group()
    {
        IEnumerable<GameObject> selection = Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel | SelectionMode.ExcludePrefab).Cast<GameObject>();

        if (!selection.Any()){
            return;
        }
        GameObject parent = null;

        if (selection.First().transform.parent != null) {
            parent = selection.First().transform.parent.gameObject;
        }
        
        var obj = new GameObject();
        if (parent != null)
        {            
            obj.transform.parent = parent.transform;
        }
       
        foreach (GameObject item in selection)
        {
            item.transform.parent = obj.transform;
        }
    }
}
#endif
