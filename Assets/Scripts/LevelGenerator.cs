using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public int MinPlatform;
    public int MaxPlatform;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlarform;
    public Transform CentreRoot;
    public float ExtraCentreScale = 1f;
    public GameObject FirstPlatformPrefab;


    private void Awake()
    {
    
        int platformsCount = Random.Range(MinPlatform, MaxPlatform);
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i>0)
            platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        FinishPlarform.localPosition = CalculatePlatformPosition(platformsCount);

        CentreRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + ExtraCentreScale , 1);
    }
    
    
        private  Vector3 CalculatePlatformPosition(int platformIndex)
        {
            return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
        }
    
}
    