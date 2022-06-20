using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject cube;

    static int width = 200;
    static int length = 200;

    float extraHeight;
    static float normHeight = 4f;

    int rand;

    private void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x <= width; x++)
        {
            for (int z = 0; z <= length; z++)
            {
                double y = Mathf.Round(Mathf.PerlinNoise((float)(x * .05), (float)(z * .05)));

                Instantiate(cube, new Vector3(x, (float)y, z), Quaternion.identity);

                rand = Random.Range(0, 5);

                bool isNormHeight()
                {
                    return rand == 0;
                }

                if (y >= 1f)
                {
                    if (!isNormHeight())
                    {
                        extraHeight = Random.Range(2, 5);

                        for (int i = 2; i <= extraHeight; i++)
                        {
                            Instantiate(cube, new Vector3(x, i, z), Quaternion.identity);
                        }
                    }

                    else if (isNormHeight())
                    {
                        for (int b = 2; b < normHeight; b++)
                        {
                            Instantiate(cube, new Vector3(x, b, z), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
