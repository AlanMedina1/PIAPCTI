using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteract : MonoBehaviour
{
    public Inventario inventario;
    public Text numero;

   
    //Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
  
    }


    void FixedUpdate()
    {
        numero.text = (inventario.Cantidad).ToString();
        PastoWin();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            inventario.Cantidad = inventario.Cantidad + 1;

            Destroy(gameObject);
        }
    }

    void PastoWin()
    {
        if (inventario.Cantidad == 12)
        {
            SceneManager.LoadScene("EscenaFinal");
        }
    }

}

