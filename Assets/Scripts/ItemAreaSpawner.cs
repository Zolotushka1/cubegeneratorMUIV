using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;
using System.IO;
using System.Text;
using System;

public class ItemAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Material[] randomMaterials;
    private string numItemsToSpawn;
    private int numItems;
    private string itemXSpread;
    private int XSpread;
    private string itemYSpread;
    private int YSpread;
    private string itemZSpread;
    private int ZSpread;

    public void SpawnCount(string s) // переводим стринг в инт и в дебаг выводим количество в инт
    {
        numItemsToSpawn = s;
        int.TryParse(numItemsToSpawn, out numItems);
    }

    public void XSpreadCount(string x)
    {
        itemXSpread = x;
        int.TryParse(itemXSpread, out XSpread);
    }

    public void YSpreadCount(string y)
    {
        itemYSpread = y;
        int.TryParse(itemYSpread, out YSpread);
    }

    public void ZSpreadCount(string z)
    {
        itemZSpread = z;
        int.TryParse(itemZSpread, out ZSpread);
    }

    public void SpawnItem()
    {
        for (int x = 0; x < numItems; x++)
        {
            Vector3 randPosition = new Vector3(Random.Range(-XSpread, XSpread), Random.Range(-YSpread, YSpread), Random.Range(-ZSpread, ZSpread)) + transform.position;
            GameObject clone = Instantiate(itemToSpawn, randPosition, itemToSpawn.transform.rotation);
            var newMaterial = randomMaterials[Random.Range(0, randomMaterials.Length)];
            clone.GetComponent<Renderer>().material = newMaterial;
            Color newColor = Random.ColorHSV(0.0f, 1f, 0.2f, 1f, 0.6f, 1f);
            clone.GetComponent<Renderer>().material.color = newColor;
            string path = "Assets\\GameInfo.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Позиция объекта: " + randPosition + " Используемый материал: " + newMaterial.name + " Используемый цвет материала: " + newColor);
            writer.Close();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FindInfo()
    {
        
    }
}
