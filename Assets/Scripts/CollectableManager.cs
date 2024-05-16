using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private GameObject[] melons;
    private bool[] collected;

    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

   

    public void LoadCollectables() {
        for (int i = 0; i < collected.Length; i++) {
            if (collected[i]) {
                Destroy(melons[i]);
            }
        }
    }


}
