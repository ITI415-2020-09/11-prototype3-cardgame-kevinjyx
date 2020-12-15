using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T>
{
    private T data;
    private TreeNode<T> lChild;
    private TreeNode<T> rChild;

    public TreeNode(T val, TreeNode<T> lp, TreeNode<T> rp)
    {
        data = val;
        lChild = lp;
        rChild = rp;
    }

    public TreeNode(TreeNode<T> lp, TreeNode<T> rp)
    {
        data = default(T);
        lChild = lp;
        rChild = rp;
    }

    public TreeNode(T val)
    {
        data = val;
        lChild = null;
        rChild = null;
    }

    public TreeNode()
    {
        data = default(T);
        lChild = null;
        rChild = null;
    }

    public T Data
    {
        get { return data; }
        set
        { data = value; }
    }

    public TreeNode<T> LChild
    {
        get { return lChild; }
        set
        { lChild = value; }
    }

    public TreeNode<T> RChild
    {
        get { return rChild; }
        set { rChild = value; }
    }

}
