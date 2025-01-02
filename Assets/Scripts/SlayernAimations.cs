using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayernAimations : MonoBehaviour
{
    public Animator SlayerAnimator;


    public void blastAnimationDown()
    {
       SlayerAnimator.Play("POWER BLAST");
    }
    public void blastAnimationUp()
    {
       SlayerAnimator.Play("CharacterSprite_Idle 0");
    }


}
