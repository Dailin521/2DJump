using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public bool isTest = false;
    private void Start()
    {
        if (isTest)
        {
            player = GameObject.Find("Player").transform;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            transform.position = new Vector3(player.position.x, Mathf.Clamp((player.position.y + 2), -1, 20), -10);
        }
    }
}
