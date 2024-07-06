using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerAnchorsList : MonoBehaviour
{
    public Transform [] m_anchorRootToLeaf;
    public Transform GetFromRoot(int index)
    {
        if (index < 0 || index >= m_anchorRootToLeaf.Length)
            return null;
        return m_anchorRootToLeaf[index];
    }
    public Transform GetFromLeaf(int index)
    {
        index = m_anchorRootToLeaf.Length-1-index;
        if (index < 0 || index >= m_anchorRootToLeaf.Length)
            return null;
        return m_anchorRootToLeaf[index];
    }

    public int GetCount()
    {
        return m_anchorRootToLeaf.Length;
    }
}
