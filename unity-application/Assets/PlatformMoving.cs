using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canMove;

    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;

    int i;
    bool reverse;

    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;

            if (i == points.Length - 1)
            {
                reverse = true;
            }
            else if (i == 0)
            {
                reverse = false;
            }

            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }

            canMove = true;
        }

        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}
