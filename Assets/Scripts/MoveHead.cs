using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHead : MonoBehaviour
{
    [SerializeField] float offset = 0.1f;
    GameObject father;
    private void Start()
    {
        father = transform.parent.gameObject;
    }
    void Update()
    {
        this.transform.position = new Vector3(father.transform.position.x-offset, transform.position.y,transform.position.z);
    }

}