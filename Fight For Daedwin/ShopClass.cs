using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Fight_For_Daedwin
{
    static class ShopClass
    {

        static public Card FirstSlot = new Card();
        static public Card SecondSlot = new Card();
        static public Card ThirdSlot = new Card();

        static public List<Card> CardList;

        static public int Money = 20;

        public static List<Card> XMLParser(string PathToXML)
        {
            List<Card> AllertList = new List<Card>();
            XmlDocument xDoc = new XmlDocument();

            if (!File.Exists(PathToXML))
            {
                var xmlWriter = new XmlTextWriter(PathToXML, null);
                xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
                xmlWriter.WriteStartElement("Data");             // <Data> 
                xmlWriter.WriteEndElement();                     // </Data>
                xmlWriter.Close();

                Card newCard = new Card("Биба");
                newCard.AddToXML(PathToXML);
            }

            xDoc.Load(PathToXML);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xNode in xRoot)
                {
                    // получаем атрибут name
                    Card AllertObj = new Card();
                    XmlNode attr = xNode.Attributes.GetNamedItem("Name");
                    AllertObj.Name = attr.Value;

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xNode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "Race")
                        {
                            AllertObj.Race = childnode.InnerText;
                        }
                        if (childnode.Name == "Type")
                        {
                            AllertObj.Type = childnode.InnerText;
                        }
                        if (childnode.Name == "Health")
                        {
                            AllertObj.Health = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "Attack")
                        {
                            AllertObj.Attack = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "Vitality")
                        {
                            AllertObj.Vitality = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "Cost")
                        {
                            AllertObj.Cost = Int32.Parse(childnode.InnerText);
                        }
                    }
                    AllertList.Add(AllertObj);
                }
            }
            return AllertList;
        }

        public static void RandomCardToShop()
        {
            if (CardList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(CardList.Count);

                FirstSlot.Name = CardList[Seed].Name;
                FirstSlot.Race = CardList[Seed].Race;
                FirstSlot.Type = CardList[Seed].Type;
                FirstSlot.Health = CardList[Seed].Health;
                FirstSlot.Attack = CardList[Seed].Attack;
                FirstSlot.Vitality = CardList[Seed].Vitality;
                FirstSlot.Cost = CardList[Seed].Cost;

                Seed = Rnd.Next(CardList.Count);

                SecondSlot.Name = CardList[Seed].Name;
                SecondSlot.Race = CardList[Seed].Race;
                SecondSlot.Type = CardList[Seed].Type;
                SecondSlot.Health = CardList[Seed].Health;
                SecondSlot.Attack = CardList[Seed].Attack;
                SecondSlot.Vitality = CardList[Seed].Vitality;
                SecondSlot.Cost = CardList[Seed].Cost;

                Seed = Rnd.Next(CardList.Count);

                ThirdSlot.Name = CardList[Seed].Name;
                ThirdSlot.Race = CardList[Seed].Race;
                ThirdSlot.Type = CardList[Seed].Type;
                ThirdSlot.Health = CardList[Seed].Health;
                ThirdSlot.Attack = CardList[Seed].Attack;
                ThirdSlot.Vitality = CardList[Seed].Vitality;
                ThirdSlot.Cost = CardList[Seed].Cost;
            }
            else
            {
                Console.WriteLine("Список карт пуст!");
                return;
            }
        }

        static public void FromShopToCrew(Card CardFromShop)
        {
            switch (CrewClass.CrewSize)
            { 
                case 0:
                    CrewClass.Slot1.Name = CardFromShop.Name;
                    CrewClass.Slot1.Race = CardFromShop.Race;
                    CrewClass.Slot1.Type = CardFromShop.Type;
                    CrewClass.Slot1.Health= CardFromShop.Health;
                    CrewClass.Slot1.Attack = CardFromShop.Attack;
                    CrewClass.Slot1.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot1.Cost = CardFromShop.Cost;
                    CrewClass.CrewSize++;
                    break;
                case 1:
                    CrewClass.Slot2.Name = CardFromShop.Name;
                    CrewClass.Slot2.Race = CardFromShop.Race;
                    CrewClass.Slot2.Type = CardFromShop.Type;
                    CrewClass.Slot2.Health = CardFromShop.Health;
                    CrewClass.Slot2.Attack = CardFromShop.Attack;
                    CrewClass.Slot2.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot2.Cost = CardFromShop.Cost;
                    CrewClass.CrewSize++;
                    break;
                case 2:
                    CrewClass.Slot3.Name = CardFromShop.Name;
                    CrewClass.Slot3.Race = CardFromShop.Race;
                    CrewClass.Slot3.Type = CardFromShop.Type;
                    CrewClass.Slot3.Health = CardFromShop.Health;
                    CrewClass.Slot3.Attack = CardFromShop.Attack;
                    CrewClass.Slot3.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot3.Cost = CardFromShop.Cost;
                    CrewClass.CrewSize++;
                    break;
                case 3:
                    CrewClass.Slot4.Name = CardFromShop.Name;
                    CrewClass.Slot4.Race = CardFromShop.Race;
                    CrewClass.Slot4.Type = CardFromShop.Type;
                    CrewClass.Slot4.Health = CardFromShop.Health;
                    CrewClass.Slot4.Attack = CardFromShop.Attack;
                    CrewClass.Slot4.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot4.Cost = CardFromShop.Cost;
                    CrewClass.CrewSize++;
                    break;
                case 4:
                    CrewClass.Slot5.Name = CardFromShop.Name;
                    CrewClass.Slot5.Race = CardFromShop.Race;
                    CrewClass.Slot5.Type = CardFromShop.Type;
                    CrewClass.Slot5.Health = CardFromShop.Health;
                    CrewClass.Slot5.Attack = CardFromShop.Attack;
                    CrewClass.Slot5.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot5.Cost = CardFromShop.Cost;
                    CrewClass.CrewSize++;
                    break;
                default:
                    break;
            }
        }
    }
}
