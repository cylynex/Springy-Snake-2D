using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public World world;

    private void Awake() {
        print("Loading attributes for world: " + world.name);
    }

}
