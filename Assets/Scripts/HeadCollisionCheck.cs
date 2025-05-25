using UnityEngine;
using UnityEngine.Events;

public class HeadCollisionCheck : MonoBehaviour
{
    //reference GameController script
    private GameController GCS;
    private void Awake()
    {
        GCS = GameObject.Find("SnakeManager").GetComponent<GameController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("obstacle"))
        {
            GCS.OnGameOver.Invoke();

        }
        else if(other.CompareTag("collectible"))
        {
            //destroy fruit
            Destroy(other.gameObject);

            //Increase snake size, spawn next collectible and increase score
            GCS.OnCollectibleConsumed.Invoke();
        }
    }
}
