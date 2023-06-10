using UnityEngine;
using UnityEngine.EventSystems;

public class CharController : MonoBehaviour
{
    [Header("Player move settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float normalSpeed = 10f;
    [SerializeField] private KeyCode Shift = KeyCode.LeftShift;
    [SerializeField] private KeyCode Space = KeyCode.Space;
    [SerializeField] private KeyCode Ctrl = KeyCode.LeftControl;
    [SerializeField] private KeyCode Exit = KeyCode.E;
    [SerializeField] private float runSpeed = 20f;
    [SerializeField] private float jumpSpeed = 0f;
    [SerializeField] private GameObject UI;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (Input.GetKey(Exit))
        {
            GameObject.Find("Exit").SetActive(false);
            UI.SetActive(true);
            this.enabled = false;
            GetComponent<MouseMove>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(Shift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        if (Input.GetKey(Space))
        {
            movement.y = jumpSpeed;
        }
        
        if (Input.GetKey(Ctrl))
        {
            movement.y -= jumpSpeed;
        }

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
    }
}
