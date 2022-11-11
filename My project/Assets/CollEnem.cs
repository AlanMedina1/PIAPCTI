using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollEnem : MonoBehaviour
{
    //nuevocod
    public Text numerovidas;
    public int vida = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        numerovidas.text = (vida).ToString();
        PolloOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            vida = vida - 1;
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
