using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour
{
    public Transform[] WayPoints;
    public Color ColorEstado = Color.green;
    private Animator anim;
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private int siguienteWayPoint;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Fichó al monito?
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjetivoPollo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }

        if (controladorNavMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
        }
    }

    void OnEnable()
    {
        anim.SetBool("Walk Forward", true);
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            anim.SetBool("Walk Forward", false);
        }
    }
}
