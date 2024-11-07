using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwapPostProcess : MonoBehaviour
{

    public Material[] materialsPP;
    private MeshRenderer meshRendererPP;
    int indexPP;

    // Start is called before the first frame update
    void Start()
    {
        meshRendererPP = GetComponent<MeshRenderer>();

        if (materialsPP.Length > 0)
        {
            meshRendererPP.material = materialsPP[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            indexPP = (indexPP + 1) % materialsPP.Length;
            SwapToNextMaterialPP(indexPP);
        }
    }

    void SwapToNextMaterialPP(int index)
    {
        if (materialsPP.Length > 0)
        {
            meshRendererPP.material = materialsPP[index];
        }
    }
}
