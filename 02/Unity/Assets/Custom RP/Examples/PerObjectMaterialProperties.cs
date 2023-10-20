using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties:MonoBehaviour
{
    static MaterialPropertyBlock block;
    static int baseColorId = Shader.PropertyToID("_BaseColor");
    static int curoffId = Shader.PropertyToID("_Cutoff");
    [SerializeField]
    Color baseColor = Color.white;
    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f;
    void Awake()
    {
        OnValidate();    
    }
    void OnValidate()
    {
        if(block == null)
        {
            block = new MaterialPropertyBlock();
        }
        block.SetColor(baseColorId, baseColor);
        block.SetFloat(curoffId, cutoff);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}