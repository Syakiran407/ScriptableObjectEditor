using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    public InputEvent inputEvent;
    public float speed = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var horizontal = UnityEngine.Input.GetAxisRaw(inputEvent.horizontalInput);
        var vertical = UnityEngine.Input.GetAxisRaw(inputEvent.verticalInput);

        if (speed > 0)
        {
            animator.SetFloat("Speed", horizontal);
            animator.SetFloat("Speed", vertical);
            animator.SetFloat("Speed", horizontal * horizontal + vertical * vertical);

            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        var move = new Vector3(horizontal, vertical, 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
