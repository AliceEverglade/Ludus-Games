using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicStateSO", menuName = "ScriptableObjects/MusicState")]
public class MusicStateSO : ScriptableObject
{
    public bool inBattle;
    public bool ending;
    public bool bgmus;
    public bool titlemus;

}
