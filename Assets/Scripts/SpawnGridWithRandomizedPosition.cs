using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Color = UnityEngine.Color;

public class SpawnGridWithRandomizedPosition : MonoBehaviour
{

    public GameObject[] itemsToPickFrom;
    public Material[] randomMaterials;
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public Vector3 positionRandomization;
    public Texture m_MainTexture;



    public void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
            }
        }
    }

    Vector3 RandomizedPosition(Vector3 position)
    {
        Vector3 randomizedPosition = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x), Random.Range(-positionRandomization.y, positionRandomization.y), Random.Range(-positionRandomization.z, positionRandomization.z)) + position;

        return randomizedPosition;

    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
        clone.GetComponent<Renderer>().material.SetTexture("_MainTex", m_MainTexture);
        Color newColor = Random.ColorHSV(0.0f, 1f, 0.2f, 1f, 0.6f, 1f);
        var newMaterial = randomMaterials[Random.Range(0, randomMaterials.Length)];
        clone.GetComponent<Renderer>().material = newMaterial;
        clone.GetComponent<Renderer>().material.color = newColor;
        string path = "Assets\\GameInfo.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Позиция объекта: " + positionToSpawn + " Используемый материал: " + newMaterial.name + " Используемый цвет материала: " + newColor);
        writer.Close();
    }
}
