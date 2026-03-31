using UnityEngine;

public class coins : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TickSystem.frequenttickTime.AddListener(coinsAnimation);

    }

    // Update is called once per frame
    void coinsAnimation(float time) 
    {
        //???? Why is it z x y
        gameObject.transform.Rotate(new Vector3(0, 0, 10));

    }
}
