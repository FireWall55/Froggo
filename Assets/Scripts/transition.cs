using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    public void Transition() {
        for (int i = 0; i < 23; i++) {
            transform.position = new Vector3(transform.position.x+.5217f, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
        }
    }
}
