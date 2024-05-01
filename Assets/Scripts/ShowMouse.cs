using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    void Update()
    {
        if (isActiveAndEnabled) {
            Cursor.lockState = CursorLockMode.None; 
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
