using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform Starting_Level;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = (Starting_Level.Find("EndPosition").position);
        int startingSpawnLevelParts = 5;
        for(int i=0; i<startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform choseLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(choseLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
