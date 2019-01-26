using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    public float backgroundSize;
    public float paralaxSpeed;
    public Transform camPosition;

    private Transform[] layers;
    private float viewZone = 10f;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    private float lastCameraY;

    private void Start()
    {
        lastCameraX = camPosition.position.x;
        lastCameraY = camPosition.position.y;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        float deltaX = camPosition.position.x - lastCameraX;
        float deltaY = camPosition.position.y - lastCameraY;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        transform.position += Vector3.up * (deltaY * paralaxSpeed);
        lastCameraX = camPosition.position.x;
        lastCameraY = camPosition.position.y;

        if (camPosition.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();

        if (camPosition.position.x > (layers[rightIndex].transform.position.x - viewZone))
            ScrollRight();
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);

        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex ==  layers.Length)
        {
            leftIndex = 0;
        }
    }
}
