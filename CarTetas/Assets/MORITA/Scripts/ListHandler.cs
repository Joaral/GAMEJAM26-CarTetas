//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class ListHandler : MonoBehaviour
//{

//    public TextMeshProUGUI text;

//    public int randNumn;

//    InputSystem_Actions input;

//    List<List<string>> todasLasListas;


//    public List<string> textsBonitos = new List<string>()
//    {
//        "Pene", 
//        "Polla",
//        "Pito",
//        "Payaso"
//    }; 

//    public List<string> textsFeitos = new List<string>()
//    {
//        "Pene fea", 
//        "Polla fea",
//        "Pito fea",
//        "Payaso fea"
//    }; 

//    public List<string> textsTrabajo = new List<string>()
//    {
//        "Pene trabajo", 
//        "Polla trabajo",
//        "Pito trabajo",
//        "Payaso trabajo"
//    };

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        input = new InputSystem_Actions();
//        input.Enable();

//        todasLasListas = new List<List<string>>()
//    {
//        textsBonitos,
//        textsFeitos,
//        textsTrabajo
//    };
//    }


//    // Update is called once per frame
//    void Update()
//    {
//        if (input.Player.Love.WasPressedThisFrame())
//        {
//            CambiarTextoRandom();
//        }
//    }


//    void CambiarTextoRandom()
//    {
//        // Elegir lista random
//        List<string> lista = todasLasListas[Random.Range(0, todasLasListas.Count)];

//        // Elegir texto random de esa lista
//        string textoRandom = lista[Random.Range(0, lista.Count)];

//        // Cambiar el TMP
//        text.text = textoRandom;
//    }

//}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListHandler : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI text;

    [Header("Prefabs")]
    public GameObject cartaAmorPrefab;     // Tag: Love
    public GameObject cartaOdioPrefab;     // Tag: Dead
    public GameObject cartaTrabajoPrefab;  // Tag: Job

    [Header("Spawn")]
    public Transform spawnPoint;

    InputSystem_Actions input;

    public List<string> textsBonitos = new List<string>()
    {
        "Pene",
        "Polla",
        "Pito",
        "Payaso"
    };

    public List<string> textsFeitos = new List<string>()
    {
        "Pene fea",
        "Polla fea",
        "Pito fea",
        "Payaso fea"
    };

    public List<string> textsTrabajo = new List<string>()
    {
        "Pene trabajo",
        "Polla trabajo",
        "Pito trabajo",
        "Payaso trabajo"
    };

    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        if (input.Player.Love.WasPressedThisFrame())
        {
            InstanciarCartaYTexto();
        }
    }

    void InstanciarCartaYTexto()
    {
        // Elegimos un prefab random
        GameObject prefabElegido = ElegirPrefabRandom();

        // Instanciamos
        GameObject cartaInstanciada = Instantiate(
            prefabElegido,
            spawnPoint.position,
            prefabElegido.transform.rotation
        );

        // Elegimos texto según el tag
        string textoFinal = ObtenerTextoPorTag(cartaInstanciada.tag);

        // Cambiamos el TMP
        text.text = textoFinal;
    }

    GameObject ElegirPrefabRandom()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                return cartaAmorPrefab;
            case 1:
                return cartaOdioPrefab;
            default:
                return cartaTrabajoPrefab;
        }
    }

    string ObtenerTextoPorTag(string tag)
    {
        List<string> listaSeleccionada = null;

        switch (tag)
        {
            case "Love":
                listaSeleccionada = textsBonitos;
                break;

            case "Dead":
                listaSeleccionada = textsFeitos;
                break;

            case "Job":
                listaSeleccionada = textsTrabajo;
                break;
        }

        if (listaSeleccionada == null || listaSeleccionada.Count == 0)
            return "";

        return listaSeleccionada[Random.Range(0, listaSeleccionada.Count)];
    }
}

