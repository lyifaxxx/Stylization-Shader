using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{

    public Material[] materials;
    private MeshRenderer meshRenderer;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (materials.Length > 0)
        {
            meshRenderer.material = materials[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index = (index + 1) % materials.Length;
            SwapToNextMaterial(index);
        }
    }

    void SwapToNextMaterial(int index)
    {
        if (materials.Length > 0)
        {
            meshRenderer.material = materials[index];
        }
    }
}
