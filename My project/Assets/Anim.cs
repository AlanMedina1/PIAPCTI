using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anim : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalDown = Input.GetButton("Horizontal");
        var VerticalDown = Input.GetButton("Vertical");
        if (HorizontalDown || VerticalDown)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

}
