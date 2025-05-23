using UnityEngine;

public class BodyController : MonoBehaviour
{
    //reference main script
    [SerializeField] private  GameController GCS;
    [SerializeField] private GameObject snakeHeadPrefab, snakeBodyPrefab;
   
    public void InitialBodyConfiguration()
    {
        //spawn head and store it in lists
        GCS.snakeBodyPositions.Add(new Vector2(0,0));
        GCS.snakeBody.Add(Instantiate(snakeHeadPrefab, GCS.snakeBodyPositions[0], Quaternion.identity));

        //call spawnbodypart function twice
        SpawnBodyPart();
        SpawnBodyPart();
    }

    public void SpawnBodyPart()
    {
        //determine and store next tile position
        int lastIndex = GCS.snakeBodyPositions.Count -1; //gives index value of last item in snakeBodyPositions list, -1 because start at 0
        if(lastIndex <2)
        {
            GCS.snakeBodyPositions.Add(GCS.snakeBodyPositions[lastIndex] + Vector2.left); //spawn first two at left of head
        }
        else
        {
            Vector2 relativeBodyPosition = GCS.snakeBodyPositions[lastIndex] - GCS.snakeBodyPositions[lastIndex-1]; //determines direction from 2nd last to last of snake body to spawn next body in
            GCS.snakeBodyPositions.Add(GCS.snakeBodyPositions[lastIndex] + relativeBodyPosition);
        }
            GCS.snakeBody.Add(Instantiate(snakeBodyPrefab, GCS.snakeBodyPositions[lastIndex + 1], Quaternion.identity));
    }
}
