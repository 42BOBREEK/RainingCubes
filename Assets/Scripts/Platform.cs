using UnityEngine;

public class Platform : MonoBehaviour
{   
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<Cube>(out Cube cube)==true)
        {
             cube.ChangeColor();
        }
    }
}
