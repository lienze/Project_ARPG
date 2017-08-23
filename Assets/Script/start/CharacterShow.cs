using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShow : MonoBehaviour
{

    public void OnPress(bool isPress) {
        if(isPress == false)
            StartmenuController._instance.OnCharacterClick(transform.parent.gameObject);
    }
}

