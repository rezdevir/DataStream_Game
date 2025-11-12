using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    public delegate void ClickHandler(PressData data);
    public ClickHandler OnClickHandler;
    public static InputHandler Instance;

    Camera cam;
    InputSystem_Actions input;

    [HideInInspector] public Vector2 mouse_position = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       
        if (Instance == this && Instance !=null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        input = new InputSystem_Actions();
        input.Handler.Click.performed += Press;
        input.Handler.Release.performed += Release;
        
        cam = Camera.main;
        input.Enable();
    }
    void Press(InputAction.CallbackContext e)
    {
        Vector2 val = input.Handler.point.ReadValue<Vector2>();
        PressData data = new PressData
        {
            Position = cam.ScreenToWorldPoint(new Vector3(val.x, val.y, cam.nearClipPlane - 5)),
            IsPressed = true
        };
        OnClickHandler?.Invoke(data);

    }
    void Release(InputAction.CallbackContext e)
    {
        Vector2 val = input.Handler.point.ReadValue<Vector2>();
        PressData data = new PressData
        {
            Position = cam.ScreenToWorldPoint(new Vector3(val.x, val.y, cam.nearClipPlane - 5)),
            IsPressed = false
        };
        OnClickHandler?.Invoke(data);
    }


    void OnDisable()
    {
        input.Handler.Click.performed -= Press;
        input.Handler.Release.performed -= Release;
    }

    // Update is called once per frame
    void Update()
    {
        mouse_position =
        cam.ScreenToWorldPoint(new Vector3(input.Handler.point.ReadValue<Vector2>().x, input.UI.Point.ReadValue<Vector2>().y, cam.nearClipPlane - 5));
    }
}
