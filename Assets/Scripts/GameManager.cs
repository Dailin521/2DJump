using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mPlayer;
    private int appleCount = 0;
    public Action<int> OnValueChanged;
    public int AppleCount
    {
        get { return appleCount; }
        set
        {
            if (!value.Equals(appleCount))
            {
                appleCount = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    private void Start()
    {
        OnValueChanged += AppleCountChange;
    }

    private void AppleCountChange(int obj)
    {
        GameObject.Find("Canvas/Score/appleCount").GetComponent<TMP_Text>().text = obj.ToString();
    }
    private void OnDestroy()
    {
        OnValueChanged -= AppleCountChange;
    }
    // Update is called once per frame
    public void GameStart()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            var temp = Instantiate(mPlayer, new Vector3(-2.5f, 13f, 0), Quaternion.identity);
            GameObject.FindObjectOfType<CamFollow>().player = temp.transform;
        }
    }
}
