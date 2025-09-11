using UnityEngine;

public class ClickPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Vector3 targetPosition;

    private bool isMoving = false;

    public float idleTimer = 0.0f;

    public bool startIdleTimer;

    public ObjectActionManager playerObjectActionManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObjectActionManager = GetComponent<ObjectActionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerObjectActionManager.isCurrentlyBeingInteractedWith)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            targetPosition = mousePos;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
        
        /*// Need a timer to start randomly wandering
        if (idleTimer <= 0.0f)
        {
            startIdleTimer = true;
        }

        if (startIdleTimer)
        {
            idleTimer += Time.deltaTime;
        }*/
    }
}
