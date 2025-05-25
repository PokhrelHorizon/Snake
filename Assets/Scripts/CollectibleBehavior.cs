using UnityEngine;

public class CollectibleBehavior : MonoBehaviour
{
    [SerializeField] private GameController GCS; //reference gamecontroller script
    [SerializeField] private GameObject fruitPrefab;

    public void SpawnCollectibleatStart()
    {
        //slight execution delay to allow realization of snake body at start
        Invoke(nameof(SpawnCollectible), 0.01f);
    }

    public void SpawnCollectible()
    {
        bool collectibleSpawned = false;
        while (!collectibleSpawned)
        {
            bool spaceOccupiedbySnake = false;
            //choose random position in play area-1 to spawn, random in int maxexclusive
            int xPos = Random.Range(-GCS.PlayAreaExtent + 1, GCS.PlayAreaExtent);
            int yPos = Random.Range(-GCS.PlayAreaExtent + 1, GCS.PlayAreaExtent);
            Vector3 positionToSpawn = new Vector2 (xPos, yPos);

            //check if that position occupied by any snake body
            for(int i = 0; i<GCS.snakeBody.Count; i++)
            {
                if(positionToSpawn == GCS.snakeBody[i].transform.position)
                {
                    spaceOccupiedbySnake = true;
                    break;
                }
            }
            if(!spaceOccupiedbySnake)
            {
                Instantiate(fruitPrefab, positionToSpawn, Quaternion.identity);
                collectibleSpawned = true;

            }
        } 
    }

}
