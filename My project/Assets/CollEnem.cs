using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollEnem : MonoBehaviour
{
    //nuevocod
    public Text numerovidas;
    public int vida = 5;
    public float AttackAnimDuration = 3f;
    private bool paused;

    IEnumerator delay()
    {
        paused = true;
        yield return new WaitForSeconds(AttackAnimDuration);
        paused = false;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        numerovidas.text = (vida).ToString();
        PolloOver();

        
    }
    void Update()
    {
        //nuevocod
        if (paused)
        {
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            vida = vida - 1;
            StartCoroutine(delay());
        }

      


    }

    void PolloOver()
    {
        //nuevocod
        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
