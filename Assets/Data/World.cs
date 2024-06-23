using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "World", order = 1)]
public class World : ScriptableObject {

    public string worldName;
    public List<string> levels = new List<string>();

}
