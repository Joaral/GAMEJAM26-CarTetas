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
    public List<string> textsBonitos;
    public List<string> textsFeitos;
    public List<string> textsTrabajo;

    public void SetTextByCard(GameObject card)
    {
        if (card == null) return;

        // Buscar el TMP dentro de la carta (Canvas -> Text)
        TextMeshProUGUI tmp = card.GetComponentInChildren<TextMeshProUGUI>();

        if (tmp == null)
        {
            Debug.LogWarning("La carta no tiene TextMeshProUGUI");
            return;
        }

        List<string> lista = null;

        switch (card.tag)
        {
            case "Love":
                lista = textsBonitos;
                break;

            case "Dead":
                lista = textsFeitos;
                break;

            case "Job":
                lista = textsTrabajo;
                break;
        }

        if (lista == null || lista.Count == 0) return;

        tmp.text = lista[Random.Range(0, lista.Count)];
    }
}



