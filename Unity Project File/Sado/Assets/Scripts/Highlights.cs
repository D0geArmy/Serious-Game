using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlights : MonoBehaviour {

    IEnumerator setActive(bool set)
    {
        gameObject.SetActive(set);
        yield return null;
    }
}
