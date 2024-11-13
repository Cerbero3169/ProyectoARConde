using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
    
    public void OnDeath()
    {
        ProgressScript.UpdateProgress();
        Destroy(gameObject); // Destruye el objeto enemigo
    }

    void OnDestroy()
    {
        // Asegúrate de que la cuenta se actualice cuando el objeto sea destruido
        ProgressScript.UpdateProgress();
    }
}
