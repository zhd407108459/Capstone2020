using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmObject : MonoBehaviour
{
    public virtual void OnBeat(int beatIndex) { }

    public virtual void OnSemiBeat(int lastBeatIndex) { }
}
