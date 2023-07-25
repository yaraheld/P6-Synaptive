using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonRESETSkript : MonoBehaviour

{
    public void ResetToFirstScene()
    {
        // Laden der ersten Szene. Stellen Sie sicher, dass der Name der Szene korrekt ist.
        SceneManager.LoadScene(0);
    }
}