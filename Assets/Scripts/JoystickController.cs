using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    public Joystick joystickLeft;
    public Joystick joystickRight;
    [SerializeField]
    public float speed = 10f;
    [SerializeField]
    public float turnspeed = 5f;
    private float lastRightHorizontalValue = 0;
    private float lastRightVerticalValue = 0;
    public bool joystickRightReleased;
    public bool isMouseLongDragged = false;
    public GameObject aimDirection;

    public float initialX;
    public float initialY;

    public CharacterController CharacterController { get; private set; }

    public Animator animator;

    public void DoubleSpeed() {
        speed = 13f;
    }

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        initialX = joystickRight.Horizontal;
        initialY = joystickRight.Vertical;
        //var joysticks = FindObjectsOfType<Joystick>();
        //int num = 0;

        //foreach (var joystick in joysticks)
        //{
        //    Debug.Log("Found joystick: " + joystick.name);
        //    if (num == 0) {
        //        joystickLeft = joystick;
        //        num++;
        //    }
        //    else
        //    {
        //        joystickRight = joystick;
        //    }

        //}
    }


    // Update is called once per frame
    void Update()
    {
        var horiontal = joystickLeft.Horizontal * 100f;
        var vertical = joystickLeft.Vertical * 100f;

        var movement = new Vector3(horiontal, 0, vertical);
        var rotation = new Vector3(joystickRight.Horizontal, 0, joystickRight.Vertical);


        bool isLastValueZero = (lastRightHorizontalValue == 0) && (lastRightVerticalValue == 0);

        if (Mathf.Abs(rotation.x - initialX) >= 0.7f || Mathf.Abs(rotation.z - initialY) >= 0.7f)
            isMouseLongDragged = true;

      

        if (rotation == Vector3.zero && !isLastValueZero && isMouseLongDragged)
        {
            animator.SetBool("shooting", true);
            joystickRightReleased = true;
            isMouseLongDragged = false;
        }
        else if (rotation != Vector3.zero) {
             aimDirection.SetActive(true);
        }
        else
        {
            animator.SetBool("shooting", false);
            joystickRightReleased = false;
            aimDirection.SetActive(false);
        }

        CharacterController.SimpleMove(movement * Time.deltaTime * speed);

        animator.SetFloat("speed", movement.magnitude);

        if (rotation.magnitude > 0)
        {
            Quaternion newdirection = Quaternion.LookRotation(rotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, newdirection, Time.deltaTime * turnspeed);
        }
        lastRightHorizontalValue = rotation.x;
        lastRightVerticalValue = rotation.z;
    }
}
