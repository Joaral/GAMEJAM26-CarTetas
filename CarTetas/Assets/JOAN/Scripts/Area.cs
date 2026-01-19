using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Area : MonoBehaviour
{
    public Color color = Color.white;

    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Vector3 GizmoPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Gizmos.DrawWireCube(GizmoPos, transform.localScale);
    }
}
