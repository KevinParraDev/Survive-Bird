using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public BirdsAnimations birdsAnimations;
    public void ChangeSkinSinceMenu(int direction)
    {
        birdsAnimations.MoveSkin(direction);
    }
}
