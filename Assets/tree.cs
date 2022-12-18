using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.SetFloat("Direction", 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Anim.SetFloat("Direction", 1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.SetFloat("Direction", 0f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Anim.SetFloat("Direction", -1f);
        }
    }
}
