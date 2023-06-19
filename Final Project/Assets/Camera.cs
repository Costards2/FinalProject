using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 deslocamento;
    void Start()
    {
        deslocamento = transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position + deslocamento;
    }
}
