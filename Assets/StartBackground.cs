using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackground : MonoBehaviour
{
    Vector2 startPos;
    Vector3 startRot;
    float moveSpeed;
    float rotatingSpeed;
    public enum State { Left, None, Right };
    public State state;
    private void Awake()
    {
        
        startPos = transform.position;
        startRot = transform.eulerAngles;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            moveSpeed = Random.Range(2, 5);
            rotatingSpeed = Random.Range(8, 14);
            yield return new WaitForSeconds(30f);
            transform.position = startPos;
            transform.eulerAngles = startRot;
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = transform.position + transform.up * Time.fixedDeltaTime * moveSpeed;
        transform.position = dir;
        switch (state)
        {
            case State.Left:
                transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * rotatingSpeed));
                break;
            case State.Right:
                transform.Rotate(new Vector3(0, 0, -Time.fixedDeltaTime * rotatingSpeed));
                break;
            default:
                break;
        }
    }
}
