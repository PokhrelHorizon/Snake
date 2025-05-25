using UnityEngine;

public class BodySpawnController : MonoBehaviour
{
    [SerializeField] private GameController GCS; //reference gamecontroller script
    [SerializeField] private GameObject snakeHeadPrefab, snakeBodyPrefab;
    [SerializeField] private int bodyPartsAtStart;


    public void InitialBodyConfiguration()
    {
        Vector2 initialHeadPosition = Vector2.zero;
        //spawn head at initialheadposition and store it in lists
        GCS.snakeBody.Add(Instantiate(snakeHeadPrefab, initialHeadPosition, Quaternion.identity));


        //call spawnbodypart function in loop according to how many desired at start
        for(int i = 0; i < bodyPartsAtStart; i++)
        {
            SpawnBodyPart();
        }
    }


    public void SpawnBodyPart()
    {
        int lastIndex = GCS.snakeBody.Count - 1; //determine index position of last object in list
        if(lastIndex <bodyPartsAtStart)
        {
            //for parts spawned at start
            GCS.snakeBody.Add(Instantiate(snakeBodyPrefab, GCS.snakeBody[lastIndex].transform.position + Vector3.left, Quaternion.identity));
        }
        else
        {
            //for parts after collecting fruit, simply determine where to spawn by determining direction from last 2 objects
            Vector2 spawnPosition = 2 * GCS.snakeBody[lastIndex].transform.position - GCS.snakeBody[lastIndex - 1].transform.position;

            GCS.snakeBody.Add(Instantiate(snakeBodyPrefab, spawnPosition, Quaternion.identity));
        }
       

    }
}
