using UnityEngine;

public class DestroyMe : MonoBehaviour
{


    public int lifeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
