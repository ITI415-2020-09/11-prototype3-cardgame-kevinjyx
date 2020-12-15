using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUICom : MonoBehaviour, IPointerClickHandler
{
    public Image CardNum, Cardsuit, CardNum1, Cardsuit1;
    public Transform CardTpyeRoot;
    public List<Image> CardTypesImage = new List<Image>();

    private void Awake()
    {
        CardTpyeRoot = transform.Find("CardTypes");
        CardNum = transform.Find("CardNum").GetComponent<Image>();
        CardNum1 = transform.Find("CardNum1").GetComponent<Image>();
        Cardsuit = transform.Find("Cardsuit").GetComponent<Image>();
        Cardsuit1 = transform.Find("Cardsuit1").GetComponent<Image>();
        for (int i = 0; i < CardTpyeRoot.childCount; i++)
        {
            CardTypesImage.Add(CardTpyeRoot.GetChild(i).GetComponent<Image>());
            CardTypesImage[CardTypesImage.Count - 1].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCardNum(Sprite image, Color color)
    {
        CardNum.sprite = image;
        CardNum1.sprite = image;
        CardNum.color = color;
        CardNum1.color = color;
    }
    public void SetCardSuit(Sprite image)
    {
        Cardsuit.sprite = image;
        Cardsuit1.sprite = image;
    }

    public void SetCardTypeImages()
    {
        int x = int.Parse(name.Split('_')[0]);
        if (x < 11&&x!=0)
        {
            for (int i = 0; i < x; i++)
            {
                CardTypesImage[i].sprite = Cardsuit.sprite;
                CardTypesImage[i].gameObject.SetActive(true);
                CardTypesImage[i].rectTransform.localScale = Vector3.one;
            }
            switch (x)
            {
                case 1:
                    CardTypesImage[0].rectTransform.localScale = Vector3.one * 1.5f;
                    break;
                case 2:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(0, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(0, -40, 0);
                    CardTypesImage[0].rectTransform.localScale = Vector3.one * 1.5f;
                    CardTypesImage[1].rectTransform.localScale = Vector3.one * 1.5f;

                    break;
                case 3:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(0, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(0, 0, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(0, -40, 0);





                    break;
                case 4:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(-20, 40, 0);

                    break;
                case 5:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(-20, 40, 0);

                    break;
                case 6:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(20, 0, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(-20, 0, 0);
                    CardTypesImage[4].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[5].rectTransform.localPosition = new Vector3(-20, 40, 0);



                    break;
                case 7:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(20, 0, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(-20, 0, 0);
                    CardTypesImage[4].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[5].rectTransform.localPosition = new Vector3(-20, 40, 0);
                    CardTypesImage[6].rectTransform.localPosition = new Vector3(0, -20, 0);
                    CardTypesImage[6].rectTransform.eulerAngles = new Vector3(0,0,180);
                    break;
                case 8:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 40, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(20, 0, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(-20, 0, 0);
                    CardTypesImage[4].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[5].rectTransform.localPosition = new Vector3(-20, 40, 0);
                    CardTypesImage[6].rectTransform.localPosition = new Vector3(0, -20, 0);
                    CardTypesImage[6].rectTransform.eulerAngles = new Vector3(0, 0, 180);
                    CardTypesImage[7].rectTransform.localPosition = new Vector3(0, 20, 0);
                    break;
                case 9:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 50, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, 20, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(20, -10, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[4].rectTransform.localPosition = new Vector3(-20, 50, 0);
                    CardTypesImage[5].rectTransform.localPosition = new Vector3(-20, 20, 0);
                    CardTypesImage[6].rectTransform.localPosition = new Vector3(-20, -10, 0);
                    CardTypesImage[7].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[8].rectTransform.localPosition = new Vector3(0, -30, 0);
                    CardTypesImage[8].rectTransform.eulerAngles = new Vector3(0, 0, 180);

                    break;
                case 10:
                    CardTypesImage[0].rectTransform.localPosition = new Vector3(20, 50, 0);
                    CardTypesImage[1].rectTransform.localPosition = new Vector3(20, 20, 0);
                    CardTypesImage[2].rectTransform.localPosition = new Vector3(20, -10, 0);
                    CardTypesImage[3].rectTransform.localPosition = new Vector3(20, -40, 0);
                    CardTypesImage[4].rectTransform.localPosition = new Vector3(-20, 50, 0);
                    CardTypesImage[5].rectTransform.localPosition = new Vector3(-20, 20, 0);
                    CardTypesImage[6].rectTransform.localPosition = new Vector3(-20, -10, 0);
                    CardTypesImage[7].rectTransform.localPosition = new Vector3(-20, -40, 0);
                    CardTypesImage[8].rectTransform.localPosition = new Vector3(0, -30, 0);
                    CardTypesImage[8].rectTransform.eulerAngles = new Vector3(0, 0, 180);
                    CardTypesImage[9].rectTransform.localPosition = new Vector3(0, 30, 0);
                    break;
                default:
                    break;
            }
        }
        else if (x == 0)
        {
            Image type = CardTpyeRoot.GetComponent<Image>();

            type.sprite = GameManager.Current.GetMaxImage(13 + name.Split('_')[1]);
        }
        else
        {
            Image type=CardTpyeRoot.GetComponent<Image>();

            type.sprite = GameManager.Current.GetMaxImage(name.Split('_')[0]+name.Split('_')[1]);

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string[] CardNames = gameObject.name.Split('_');
        //剩余牌中  的 选中牌
        if (CardNames.Length == 2)
        {
            if (GameManager.Current.card.Num.ToString() != CardNames[0] || GameManager.Current.card.cardType.ToString() != CardNames[1])
            {
                GameManager.Current.card.Num = int.Parse(CardNames[0]);
                switch (CardNames[1])
                {
                    case "C":
                        GameManager.Current.card.cardType = global::CardType.C;
                        break;
                    case "D":
                        GameManager.Current.card.cardType = global::CardType.D;

                        break;
                    case "H":
                        GameManager.Current.card.cardType = global::CardType.H;

                        break;
                    case "S":
                        GameManager.Current.card.cardType = global::CardType.S;
                        break;
                    default:
                        break;
                }

                transform.SetParent(GameManager.Current.CardRoot, false);

            }
            else
            {
                if (GameManager.Current.card.Num == 0)
                {
                    transform.SetParent(GameManager.Current.ResultCardsRoot, false);
                    transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    GameManager.Current.score += 20;
                    return;
                }

            }
            return;
        }
        List<TreeNode<Card>> Leafs = GameManager.Current.Tree.GetLeafs(GameManager.Current.Tree.Head);
        for (int i = 0; i < Leafs.Count; i++)
        {
            if (Leafs[i].Data.Num.ToString() == CardNames[0] && Leafs[i].Data.cardType.ToString() == CardNames[1])
            {
                print(gameObject.name);
                ResultVerification(Leafs[i]);
                return;
            }
        }



    }


    public void ResultVerification(TreeNode<Card> node)
    {

        if (node.Data.Num == 0)
        {
            transform.SetParent(GameManager.Current.ResultCardsRoot, false);
            transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
            GameManager.Current.Tree.DeleteValue(GameManager.Current.Tree.Head, node.Data);
            GameManager.Current.score += 20;
            return;
        }

        List<TreeNode<Card>> Leafs = GameManager.Current.Tree.GetLeafs(GameManager.Current.Tree.Head);

        for (int i = 0; i < Leafs.Count; i++)
        {
            if (Leafs[i] == node) continue;

            if (Leafs[i].Data.Num + node.Data.Num == 13)
            {
                Transform MatchingCard = GameManager.Current.GetCardTrans(Leafs[i].Data.Num.ToString() + "_" + Leafs[i].Data.cardType.ToString(), 0);
                if (MatchingCard == null) return;

                MatchingCard.SetParent(GameManager.Current.ResultCardsRoot, false);
                MatchingCard.GetComponent<RectTransform>().localPosition = Vector3.zero;
                GameManager.Current.Tree.DeleteValue(GameManager.Current.Tree.Head, Leafs[i].Data);

                transform.SetParent(GameManager.Current.ResultCardsRoot, false);
                transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
                GameManager.Current.Tree.DeleteValue(GameManager.Current.Tree.Head, node.Data);
                GameManager.Current.score += 20;

                return;
            }
        }

        if (node.Data.Num + GameManager.Current.card.Num == 13)
        {
            Transform MatchingCard = GameManager.Current.GetCardTrans(GameManager.Current.card.Num.ToString() + "_" + GameManager.Current.card.cardType.ToString(), 1);
            if (MatchingCard == null) return;

            MatchingCard.SetParent(GameManager.Current.ResultCardsRoot, false);
            MatchingCard.GetComponent<RectTransform>().localPosition = Vector3.zero;
            //GameManager.Current.Tree.DeleteValue(GameManager.Current.Tree.Head, Leafs[i].Data);

            transform.SetParent(GameManager.Current.ResultCardsRoot, false);
            transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
            GameManager.Current.Tree.DeleteValue(GameManager.Current.Tree.Head, node.Data);
            GameManager.Current.score += 20;
            return;
        }


    }


}
