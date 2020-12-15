using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager current;
    public static GameManager Current { get { return current; } }

    public LinkBinaryTree<Card> Tree = new LinkBinaryTree<Card>();//金字塔牌堆
    public List<Card> CardsInfo = new List<Card>();//剩余牌


    public Sprite[] CardTypeImage;
    public Sprite[] CardNumImage;
    public Sprite[] MaxCardType;


    public GameObject CardPrefab;
    public GameObject CardTypeUIPrefab;


    public Transform PyramidRoot;
    public Transform CardsRoot;
    public Transform CardRoot;
    public Transform ResultCardsRoot;

    public int[][] map = new int[7][];

    public Text ScoreText;
    public Button StartBtn;

    public Card card = new Card();

    public int score = 0;
    public int result = 2;


    void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Tree.ccc(Tree.Head);
        }
        if (ScoreText != null)
        {
            ScoreText.text = " score：" + score;
        }

    }
    public void GameInit()
    {
        score = 0;
        result = 2;
        Licensing();
    }
    public void Licensing()
    {
        Tree.Clear();
        CardsInfo.Clear();
        List<int> vs = new List<int>();//有序牌组
        for (int i = 0; i < 52; i++)
        {
            vs.Add(i + 1);
        }
        TreeInit1(vs);//抽出金字塔牌组后  顺序牌组
        List<int> cc = ListRandom(vs);//乱序牌组
        for (int i = 0; i < cc.Count; i++)
        {
            CardsInfo.Add(new Card(cc[i] % 13, (CardType)((cc[i] - 1) / 13)));
            InitializedCardsUI(CardsInfo[CardsInfo.Count - 1]);
        }



    }
   public bool IsOK(int[][] vs)
    {
        HashSet<int> vv = new HashSet<int>();
        for (int i = 0; i < vs.GetLength(0); i++)
        {
            for (int l = 0; l < vs[i].Length; l++)
            {
                if (vv.Contains(vs[i][l]))
                {
                    return false;
                }
            }
        }
        return true;
    }

   

    public void TreeInit1(List<int> Deck)
    {
       
      
        for (int i = 0; i < map.GetLength(0); i++)
        {
            map[i] = new int[i + 1];
            for (int l = 0; l < i + 1; l++)
            {
                int index = Random.Range(0, Deck.Count - 1);
            
                map[i][l] = Deck[index];
                Deck.RemoveAt(index);
            }
        }
        if (!IsOK(map))
        {
            print("有重复");
            return;
        }
        for (int i = 0; i < map.GetLength(0); i++)
        {
            if (i==0)
            {
                Tree.Head = new TreeNode<Card>(new Card(map[i][0] % 13, (CardType)((map[i][0] - 1) / 13)));
                InitializedCardUI(Tree.Head.Data, i, 0);
                continue;
            }
            else
            {
                List<TreeNode<Card>> nodes = Tree.GetLeafs(Tree.Head);
                for (int l = 0; l < nodes.Count; l++)
                {
                    if (l == 0)
                    {
                        nodes[l].LChild = new TreeNode<Card>(new Card(map[i][l] % 13, (CardType)((map[i][l] - 1) / 13)));
                        nodes[l].RChild = new TreeNode<Card>(new Card(map[i][l+1] % 13, (CardType)((map[i][l+1] - 1) / 13)));
                        InitializedCardUI(nodes[l].LChild.Data, i, l);
                        InitializedCardUI(nodes[l].RChild.Data, i, l + 1);

                    }
                    else
                    {
                        nodes[l].LChild = nodes[l - 1].RChild;
                        nodes[l].RChild = new TreeNode<Card>(new Card(map[i][l + 1] % 13, (CardType)((map[i][l + 1]-1) / 13)));
                        InitializedCardUI(nodes[l].RChild.Data, i, l + 1);
                    }
                }
            }
        }

    }

    public void TreeInit(List<int> Deck)
    {

        //七层金字塔  每层 初始化
        for (int i = 0; i < 7; i++)
        {
            if (i == 0)
            {
                int index = Random.Range(0, Deck.Count);
                map[i] = new int[1];
                map[i][0] = index;
                Tree.Head = new TreeNode<Card>(new Card(Deck[index] % 13, (CardType)((Deck[index] - 1) / 13)));
                InitializedCardUI(Tree.Head.Data, i, 0);
                Deck.RemoveAt(index);
            }
            else
            {
                List<TreeNode<Card>> nodes = Tree.GetLeafs(Tree.Head);
                int[] vs = new int[nodes.Count + 1];
                map[i] = new int[nodes.Count + 1];

                for (int l = 0; l < vs.Length; l++)
                {

                    int index = Random.Range(0, Deck.Count);
                    map[i][l] = index;
                    vs[l] = Deck[index];
                    Deck.RemoveAt(index);
                }
                for (int l = 0; l < nodes.Count; l++)
                {
                    if (l == 0)
                    {
                        nodes[l].LChild = new TreeNode<Card>(new Card(vs[l] % 13, (CardType)((vs[l] - 1) / 13)));
                        nodes[l].RChild = new TreeNode<Card>(new Card(vs[l + 1] % 13, (CardType)((vs[l + 1] - 1) / 13)));
                        InitializedCardUI(nodes[l].LChild.Data, i, l);
                        InitializedCardUI(nodes[l].RChild.Data, i, l + 1);

                    }
                    else
                    {
                        nodes[l].LChild = nodes[l - 1].RChild;
                        nodes[l].RChild = new TreeNode<Card>(new Card(vs[l + 1] % 13, (CardType)((vs[l + 1] - 1) / 13)));
                        InitializedCardUI(nodes[l].RChild.Data, i, l + 1);
                    }



                }


            }

        }


    }
    private List<int> ListRandom(List<int> myList)
    {

        List<int> newList = new List<int>();
        int index = 0;
        int temp = 0;
        for (int i = 0; i < myList.Count; i++)
        {

            index = Random.Range(0, myList.Count);
            if (index != i)
            {
                temp = myList[i];
                myList[i] = myList[index];
                myList[index] = temp;
            }
        }
        return myList;
    }

    public void SetCardUI(CardUICom CardUI, Card cardInfo)
    {
        if (CardUI == null) return;
        print("cardInfo.cardType:" + (int)cardInfo.cardType + "-----cardInfo.Num:" + cardInfo.Num.ToString());
        CardUI.SetCardNum(CardNumImage[cardInfo.Num == 0 ? 12 : cardInfo.Num - 1], cardInfo.cardType == CardType.C || cardInfo.cardType == CardType.S ? Color.black : Color.red);
        CardUI.SetCardSuit(CardTypeImage[(int)cardInfo.cardType]);
        CardUI.SetCardTypeImages();
    }

    public void InitializedCardUI(Card cardInfo, int layer, int index)
    {
        GameObject NewCard = Instantiate(CardPrefab);
        NewCard.transform.SetParent(PyramidRoot, false);

        float xPos = layer * -85f;

        NewCard.GetComponent<RectTransform>().localPosition = new Vector3(xPos + index * 170f, layer * -75f, 0);

        NewCard.name = cardInfo.Num.ToString() + "_" + cardInfo.cardType.ToString() + "_" + layer.ToString() + "_" + index.ToString();



        SetCardUI(NewCard.GetComponent<CardUICom>(), cardInfo);
    }
    public void InitializedCardsUI(Card cardInfo)
    {
        GameObject NewCard = Instantiate(CardPrefab);
        NewCard.transform.SetParent(CardsRoot, false);
        NewCard.name = cardInfo.Num.ToString() + "_" + cardInfo.cardType.ToString();
        SetCardUI(NewCard.GetComponent<CardUICom>(), cardInfo);
    }

    public Transform GetCardTrans(string Name, int Type)//Type=0 在金字塔 找  Type =1 在选中卡牌找
    {
        if (Type == 0)
        {
            foreach (Transform item in PyramidRoot)
            {
                if (item.name.Contains(Name))
                {
                    return item;
                }
            }
        }
        else if (Type == 1)
        {
            foreach (Transform item in CardRoot)
            {
                if (item.name.Contains(Name))
                {
                    return item;
                }
            }


        }
        return null;
    }
    public void ResetCards()
    {
        Queue<Transform> CardsQueue = new Queue<Transform>();
        foreach (Transform item in CardRoot)
        {
            CardsQueue.Enqueue(item);
        }

        while (CardsQueue.Count != 0)
        {
            Transform item = CardsQueue.Dequeue();
            item.SetParent(CardsRoot, false);
        }
        card.Num = 999;
        result--;
        if (result == -1)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        DestroyCard(PyramidRoot);
        DestroyCard(ResultCardsRoot);
        DestroyCard(CardsRoot);
        DestroyCard(CardRoot);
        Tree.Head = null;
        CardsInfo.Clear();

        StartBtn.gameObject.SetActive(true);
    }

    public void DestroyCard(Transform cc)
    {
        for (int i = 0; i < cc.childCount; i++)
        {
            Destroy(cc.GetChild(i).gameObject);
        }
    }

    public Sprite GetMaxImage(string ImageName)
    {
        for (int i = 0; i < MaxCardType.Length; i++)
        {
            if (MaxCardType[i].name.Contains(ImageName))
            {
                return MaxCardType[i];
            }
        }
        return null;
    }

}

public struct Card
{
    public Card(int Num, CardType cardType)
    {
        this.Num = Num;
        this.cardType = cardType;
    }

    public static bool operator ==(Card c1, Card c2)
    {
        if (c1.Num == c2.Num && c1.cardType == c2.cardType) return true;
        else return false;
    }
    public static bool operator !=(Card c1, Card c2)
    {
        if (c1.Num == c2.Num && c1.cardType == c2.cardType) return false;
        else return true;
    }
    public int Num;
    public CardType cardType;
}
public enum CardType
{
    C = 0,
    D,
    H,
    S
}