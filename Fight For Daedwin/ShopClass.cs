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

        static public Item FirstItemSlot = new Item();
        static public Item SecondItemSlot = new Item();
        static public Item ThirdItemSlot = new Item();

        static public List<Card> UnitList;
        static public List<Item> ItemList;

        static public int Money = 30;

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
                newCard.AddUnitToXML(PathToXML);
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

        public static List<Item> XMLItemParser(string PathToXML)
        {
            List<Item> AllertList = new List<Item>();
            XmlDocument xDoc = new XmlDocument();

            if (!File.Exists(PathToXML))
            {
                var xmlWriter = new XmlTextWriter(PathToXML, null);
                xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
                xmlWriter.WriteStartElement("Data");             // <Data> 
                xmlWriter.WriteEndElement();                     // </Data>
                xmlWriter.Close();

                Item newCard = new Item("Монетка");
                newCard.AddItemToXML(PathToXML);
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
                    Item AllertObj = new Item();
                    XmlNode attr = xNode.Attributes.GetNamedItem("Name");
                    AllertObj.Name = attr.Value;

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xNode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "Type")
                        {
                            AllertObj.Type = childnode.InnerText;
                        }
                        if (childnode.Name == "HealthBuff")
                        {
                            AllertObj.HealthBuff = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "AttackBuff")
                        {
                            AllertObj.AttackBuff = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "VitalityBuff")
                        {
                            AllertObj.VitalityBuff = Int32.Parse(childnode.InnerText);
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

        public static void RandomUnitToShop()
        {
            if (UnitList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(UnitList.Count);

                FirstSlot.Name = UnitList[Seed].Name;
                FirstSlot.Race = UnitList[Seed].Race;
                FirstSlot.Type = UnitList[Seed].Type;
                FirstSlot.Health = UnitList[Seed].Health;
                FirstSlot.Attack = UnitList[Seed].Attack;
                FirstSlot.Vitality = UnitList[Seed].Vitality;
                FirstSlot.Cost = UnitList[Seed].Cost;

                Seed = Rnd.Next(UnitList.Count);

                SecondSlot.Name = UnitList[Seed].Name;
                SecondSlot.Race = UnitList[Seed].Race;
                SecondSlot.Type = UnitList[Seed].Type;
                SecondSlot.Health = UnitList[Seed].Health;
                SecondSlot.Attack = UnitList[Seed].Attack;
                SecondSlot.Vitality = UnitList[Seed].Vitality;
                SecondSlot.Cost = UnitList[Seed].Cost;

                Seed = Rnd.Next(UnitList.Count);

                ThirdSlot.Name = UnitList[Seed].Name;
                ThirdSlot.Race = UnitList[Seed].Race;
                ThirdSlot.Type = UnitList[Seed].Type;
                ThirdSlot.Health = UnitList[Seed].Health;
                ThirdSlot.Attack = UnitList[Seed].Attack;
                ThirdSlot.Vitality = UnitList[Seed].Vitality;
                ThirdSlot.Cost = UnitList[Seed].Cost;
            }
            else
            {
                Console.WriteLine("Список карт пуст!");
                return;
            }
        }

        public static void RandomItemToShop()
        {
            if (ItemList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(ItemList.Count);

                FirstItemSlot.Name = ItemList[Seed].Name;
                FirstItemSlot.Type = ItemList[Seed].Type;
                FirstItemSlot.HealthBuff = ItemList[Seed].HealthBuff;
                FirstItemSlot.AttackBuff = ItemList[Seed].AttackBuff;
                FirstItemSlot.VitalityBuff = ItemList[Seed].VitalityBuff;
                FirstItemSlot.Cost = ItemList[Seed].Cost;

                Seed = Rnd.Next(ItemList.Count);

                SecondItemSlot.Name = ItemList[Seed].Name;
                SecondItemSlot.Type = ItemList[Seed].Type;
                SecondItemSlot.HealthBuff = ItemList[Seed].HealthBuff;
                SecondItemSlot.AttackBuff = ItemList[Seed].AttackBuff;
                SecondItemSlot.VitalityBuff = ItemList[Seed].VitalityBuff;
                SecondItemSlot.Cost = ItemList[Seed].Cost;

                Seed = Rnd.Next(ItemList.Count);

                ThirdItemSlot.Name = ItemList[Seed].Name;
                ThirdItemSlot.Type = ItemList[Seed].Type;
                ThirdItemSlot.HealthBuff = ItemList[Seed].HealthBuff;
                ThirdItemSlot.AttackBuff = ItemList[Seed].AttackBuff;
                ThirdItemSlot.VitalityBuff = ItemList[Seed].VitalityBuff;
                ThirdItemSlot.Cost = ItemList[Seed].Cost;
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
                    CrewClass.Slot1.Health = CardFromShop.Health;
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

                    //GameState.CurentStage = GameState.Stage.ItemShopStage;
                    break;
                default:
                    break;
            }
        }

        static public void FromShopToInventory(Item CardFromShop)
        {
            switch (InventoryClass.InventorySize)
            {
                case 0:
                    InventoryClass.Slot1.Name = CardFromShop.Name;
                    InventoryClass.Slot1.Type = CardFromShop.Type;
                    InventoryClass.Slot1.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot1.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot1.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot1.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                case 1:
                    InventoryClass.Slot2.Name = CardFromShop.Name;
                    InventoryClass.Slot2.Type = CardFromShop.Type;
                    InventoryClass.Slot2.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot2.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot2.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot2.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                case 2:
                    InventoryClass.Slot3.Name = CardFromShop.Name;
                    InventoryClass.Slot3.Type = CardFromShop.Type;
                    InventoryClass.Slot3.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot3.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot3.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot3.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                case 3:
                    InventoryClass.Slot4.Name = CardFromShop.Name;
                    InventoryClass.Slot4.Type = CardFromShop.Type;
                    InventoryClass.Slot4.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot4.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot4.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot4.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                case 4:
                    InventoryClass.Slot5.Name = CardFromShop.Name;
                    InventoryClass.Slot5.Type = CardFromShop.Type;
                    InventoryClass.Slot5.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot5.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot5.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot5.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                case 5:
                    InventoryClass.Slot6.Name = CardFromShop.Name;
                    InventoryClass.Slot6.Type = CardFromShop.Type;
                    InventoryClass.Slot6.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot6.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot6.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot6.Cost = CardFromShop.Cost;
                    InventoryClass.InventorySize++;
                    break;
                default:
                    break;
            }
        }
    }
}
