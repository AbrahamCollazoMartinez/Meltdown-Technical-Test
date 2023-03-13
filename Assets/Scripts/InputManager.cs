using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool GetButton(string buttonName)
    {
        return Input.GetButton(buttonName);
    }

    public bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }

    public bool GetButtonUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }

    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
}
