using TMPro;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text _Text;
    public float mCurrentTimes = 0;
    void Start()
    {
        _Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mCurrentTimes += Time.deltaTime;
        if (Time.frameCount % 20 == 0)
        {
            _Text.text = ((int)mCurrentTimes).ToString();
        }
    }
}
