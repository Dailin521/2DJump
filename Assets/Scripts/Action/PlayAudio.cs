using UnityEngine;
using UnityEngine.Events;

public class PlayAudio : MonoBehaviour
{
    public UnityEvent OnFinish;
    public void Excute()
    {
        var au = GetComponent<AudioSource>();
        au.Play();
        var len = au.clip.length;
        Invoke(nameof(OnPlayFinished), len);

    }
    public void OnPlayFinished()
    {
        OnFinish?.Invoke();
    }
}
