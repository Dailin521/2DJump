using UnityEngine;

public class SetAsParent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Excute()
    {
        transform.SetParent(null);
    }
}
