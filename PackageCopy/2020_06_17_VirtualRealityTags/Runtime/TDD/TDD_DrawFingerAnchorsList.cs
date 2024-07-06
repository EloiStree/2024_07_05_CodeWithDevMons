using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_DrawFingerAnchorsList : MonoBehaviour
{
    
     void Update()
    {
        DrawaAllFingers(SideType.Left, Time.deltaTime);
        DrawaAllFingers(SideType.Right, Time.deltaTime);
        DrawaWrist(SideType.Left, Time.deltaTime);
        DrawaWrist(SideType.Right, Time.deltaTime);
    }
    public void DrawaWrist(SideType side, float timeDraw = 0.1f)
    {
        Transform wrist, rootPinky, rootThumb;
        bool found;
        VirtualRealityTags.GetFingerBoneAnchorFromRoot(side, FingerTags.Pinky, 0, out found, out rootPinky);
        VirtualRealityTags.GetFingerBoneAnchorFromRoot(side, FingerTags.Thumb, 0, out found, out rootThumb);
        VirtualRealityTags.GetHandWrist(side, out found, out wrist);

        if (wrist != null && rootPinky != null)
            Debug.DrawLine(wrist.position, rootPinky.position, Color.cyan, timeDraw);
        if (rootThumb != null && rootPinky != null)
            Debug.DrawLine(rootThumb.position, rootPinky.position, Color.cyan, timeDraw);
        if (rootThumb != null && wrist != null)
            Debug.DrawLine(rootThumb.position, wrist.position, Color.cyan, timeDraw);


    }
    public void DrawaAllFingers( SideType side, float timeDraw = 0.1f)
    {
        FingerTags[] fingers = new FingerTags[] { FingerTags.Pinky, FingerTags.Ring, FingerTags.Middle, FingerTags.Index, FingerTags.Thumb };
        Transform from=null, to = null;
        for (int j = 0; j < fingers.Length; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                bool found;
                Transform anchor;
                VirtualRealityTags.GetFingerBoneAnchorFromRoot(side, fingers[j], i, out found, out anchor);

                if (!found)
                {
                    continue;
                }
                else
                {
                    from = to;
                    to = anchor;
                    if (from != null && to != null)
                    {
                        Debug.DrawLine(from.position, to.position, Color.green, timeDraw);
                    }
                }
            }
            from = null; to = null;
        }
        
    }
}
