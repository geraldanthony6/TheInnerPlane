using UnityEngine;

public class AIBoatMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] LocationPoints;

    [SerializeField] private GameObject CurrentLocationPoint;

    [SerializeField] private int LocationPointIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentLocationPoint = LocationPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Vector3.Distance(transform.position, CurrentLocationPoint.transform.position) > 0.4f)
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentLocationPoint.transform.position, 5.0f * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, CurrentLocationPoint.transform.position) < 0.5f)
        {
            LocationPointIndex++;
            if (LocationPointIndex >= LocationPoints.Length)
            {
                LocationPointIndex = 0;
            }
            CurrentLocationPoint = LocationPoints[LocationPointIndex];
        }
    }
}
