using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public void Excute()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
