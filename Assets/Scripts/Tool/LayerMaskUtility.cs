using UnityEngine;

public static class LayerMaskUtility
{

    public static bool Contains(LayerMask layerMask, int layer)
    {
        return ((int)layerMask & 1 << layer) > 0;
        //&：不管前面的条件是否正确，后面都执行。&&：前面条件正确时，才执行后面，不正确时，就不执行，就效率而言，这个更好。
    }
}



