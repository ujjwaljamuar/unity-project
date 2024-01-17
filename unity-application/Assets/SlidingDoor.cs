using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform door; // Assign the door object in the inspector
    public float slideDistance = 2f; // Distance the door will slide
    public float slideSpeed = 1f; // Speed the door will slide

    private Vector3 _closedPosition;
    private Vector3 _openPosition;
    private bool _isOpen = false;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _closedPosition = door.position;
        _openPosition = new Vector3(door.position.x + slideDistance, door.position.y, door.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isOpen)
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
            _currentCoroutine = StartCoroutine(SlideDoor(_openPosition));
            _isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isOpen)
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
            _currentCoroutine = StartCoroutine(SlideDoor(_closedPosition));
            _isOpen = false;
        }
    }

    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        while ((door.position - targetPosition).sqrMagnitude > 0.01f)
        {
            door.position = Vector3.Lerp(door.position, targetPosition, Time.deltaTime * slideSpeed);
            yield return null;
        }

        door.position = targetPosition;
    }
}
