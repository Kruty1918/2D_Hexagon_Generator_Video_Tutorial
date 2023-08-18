using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGenerator : MonoBehaviour
{
    [SerializeField] private Hex hexPrefab;
    [SerializeField] private int hexCount;

    private void Start()
    {
        SpawnHex(new Vector3(Random.Range(-5, 5), Random.Range(-3, 3)));
    }

    private void SpawnHex(Vector3 startPoint)
    {
        Vector3 hexSpawnOffset = startPoint;
        List<Hex> spawnHex = new List<Hex>();

        for (int i = 0; i < hexCount; i++)
        {
            spawnHex.Add(Instantiate(hexPrefab, hexSpawnOffset, Quaternion.identity));
            hexSpawnOffset += GetRandomOffset(hexSpawnOffset, spawnHex);
        }
    }

    private Vector3 GetRandomOffset(Vector3 oldPosition, List<Hex> hexes)
    {
        List<Vector3> positions = new List<Vector3>
    {
        new Vector3(0.759f, 0.426f), new Vector3(0.759f, -0.43f), new Vector3(-0.756f, 0.426f), new Vector3(-0.756f, -0.43f), new Vector3(0, 0.853f), new Vector3(0, -0.861f)
    };

        // Перемішайте список можливих зміщень
        ShuffleList(positions);

        foreach (Vector3 randomOffset in positions)
        {
            Vector3 newPosition = oldPosition + randomOffset;

            // Перевірка, чи є гекс в приблизних координатах
            if (!HexIsNearPosition(newPosition, hexes))
            {
                return randomOffset;
            }
        }

        // Якщо не знайдено вільний вектор, поверніть перший
        return positions[0];
    }
           
    private bool HexIsNearPosition(Vector3 position, List<Hex> hexes)
    {
        float threshold = 0.1f; // Допустимий діапазон для перевірки приблизних координат

        foreach (Hex hex in hexes)
        {
            if (Vector3.Distance(hex.transform.position, position) < threshold)
            {
                return true;
            }
        }

        return false;
    }

    private void ShuffleList<T>(List<T> list)            
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}