using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_InputField _inputField;
    [SerializeField] private GameObject _meshGenerator;
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onEndEdit.AddListener(delegate { UpdateMesh(); });
    }

    private void UpdateMesh()
    {
        int subValue;
        print("parsing");
        if(int.TryParse(_inputField.text, out subValue))
        {
            print("parsed");
            //_meshGenerator.GetComponent<MeshGenerator>().RecalculateMesh(subValue);
        }
    }
}
