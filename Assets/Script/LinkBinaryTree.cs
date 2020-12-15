using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBinaryTree<T>
{
    private TreeNode<T> head;       //头引用

    public TreeNode<T> Head
    {
        get { return head; }
        set
        { head = value; }
    }

    public LinkBinaryTree()
    {
        head = null;
    }

    public LinkBinaryTree(T val)
    {
        TreeNode<T> p = new TreeNode<T>(val);
        head = p;
    }

    public LinkBinaryTree(T val, TreeNode<T> lp, TreeNode<T> rp)
    {
        TreeNode<T> p = new TreeNode<T>(val, lp, rp);
        head = p;
    }
    public TreeNode<T> GetLChild(TreeNode<T> p)
    {
        return p.LChild;
    }

    public TreeNode<T> GetRChild(TreeNode<T> p)
    {
        return p.RChild;
    }



    public bool IsLeaf(TreeNode<T> p)
    {
        if ((p != null) && (p.RChild == null) && (p.LChild == null))
            return true;
        else
            return false;
    }
    public void ccc(TreeNode<Card> root)
    {
        if (root == null)
        {
            return;
        }
        Queue<TreeNode<Card>> sq = new Queue<TreeNode<Card>>(50);
        HashSet<TreeNode<Card>> nodes = new HashSet<TreeNode<Card>>();

        sq.Enqueue(root);
        while (sq.Count != 0)
        {
            //结点出队
            TreeNode<Card> tmp = sq.Dequeue();

            nodes.Add(tmp);

            if (tmp.LChild != null)
            {
                sq.Enqueue(tmp.LChild);
            }
            if (tmp.RChild != null)
            {
                sq.Enqueue(tmp.RChild);
            }
        }

        foreach (var item in nodes)
        {
            Debug.Log(item.Data.Num+"_"+ item.Data.cardType);
        }

    }
    public List<TreeNode<T>> GetLeafs(TreeNode<T> root)
    {
        if (root == null)
        {
            return null;
        }
        List<TreeNode<T>> Leafs = new List<TreeNode<T>>();

        Queue<TreeNode<T>> sq = new Queue<TreeNode<T>>(50);
        sq.Enqueue(root);
        while (sq.Count != 0)
        {
            //结点出队
            TreeNode<T> tmp = sq.Dequeue();

            if (IsLeaf(tmp))
            {
                if (!Leafs.Contains(tmp))
                {
                    Leafs.Add(tmp);
                }
            }

            if (tmp.LChild != null)
            {
                sq.Enqueue(tmp.LChild);
            }
            if (tmp.RChild != null)
            {
                sq.Enqueue(tmp.RChild);
            }
        }
        return Leafs;
    }

    public void DeleteValue(TreeNode<Card> ptr,Card card)
    {
        if (head==null)
        {
            return;
        }
        if (ptr!=null)
        {
            if (ptr.LChild!=null)
            {
                if (ptr.LChild.Data==card)
                {
                    ptr.LChild = null;
                    Debug.Log("删除左孩子");

                    return;
                }
            }
            if (ptr.RChild != null)
            {
                if (ptr.RChild.Data == card)
                {
                    ptr.RChild = null;
                    Debug.Log("删除右孩子");
                    return;
                }
            }
        }



        if (ptr != null)
        {
            DeleteValue(ptr.LChild, card);
            DeleteValue(ptr.RChild, card);
        }
    }

    public void Clear()
    {
        head = null;
    }

}
