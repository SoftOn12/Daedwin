﻿using System;
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

        static public Spell FirstSpellSlot = new Spell();
        static public Spell SecondSpellSlot = new Spell();
        static public Spell ThirdSpellSlot = new Spell();

        static public List<Card> UnitList;
        static public List<Card> UnitListLevel2;
        static public List<Card> UnitListLevel3;
        static public List<Item> ItemList;
        static public List<Spell> SpellList;

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

                Card newCard = new Card();
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
                        if (childnode.Name == "ID")
                        {
                            AllertObj.ID = Int32.Parse(childnode.InnerText);
                        }
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
                        if (childnode.Name == "Image")
                        {
                            AllertObj.Image = childnode.InnerText;
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
                        if (childnode.Name == "Image")
                        {
                            AllertObj.Image = childnode.InnerText;
                        }
                    }
                    AllertList.Add(AllertObj);
                }
            }
            return AllertList;
        }

        public static List<Spell> XMLSpellParser(string PathToXML)
        {
            List<Spell> AllertList = new List<Spell>();
            XmlDocument xDoc = new XmlDocument();

            if (!File.Exists(PathToXML))
            {
                var xmlWriter = new XmlTextWriter(PathToXML, null);
                xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
                xmlWriter.WriteStartElement("Data");             // <Data> 
                xmlWriter.WriteEndElement();                     // </Data>
                xmlWriter.Close();

                Spell newCard = new Spell();
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
                    Spell AllertObj = new Spell();
                    XmlNode attr = xNode.Attributes.GetNamedItem("Name");
                    AllertObj.Name = attr.Value;

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xNode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "RaceCondition")
                        {
                            AllertObj.RaceCondition = childnode.InnerText;
                        }
                        if (childnode.Name == "TypeCondition")
                        {
                            AllertObj.TypeCondition = childnode.InnerText;
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
                        if (childnode.Name == "Description")
                        {
                            AllertObj.Description = childnode.InnerText;
                        }
                        if (childnode.Name == "Image")
                        {
                            AllertObj.Image = childnode.InnerText;
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

                FirstSlot.ID = UnitList[Seed].ID;
                FirstSlot.Name = UnitList[Seed].Name;
                FirstSlot.Race = UnitList[Seed].Race;
                FirstSlot.Type = UnitList[Seed].Type;
                FirstSlot.Health = UnitList[Seed].Health;
                FirstSlot.Attack = UnitList[Seed].Attack;
                FirstSlot.Vitality = UnitList[Seed].Vitality;
                FirstSlot.Cost = UnitList[Seed].Cost;
                FirstSlot.Exp = UnitList[Seed].Exp;
                FirstSlot.Level = UnitList[Seed].Level;
                FirstSlot.Image = UnitList[Seed].Image;

                Seed = Rnd.Next(UnitList.Count);

                SecondSlot.ID = UnitList[Seed].ID;
                SecondSlot.Name = UnitList[Seed].Name;
                SecondSlot.Race = UnitList[Seed].Race;
                SecondSlot.Type = UnitList[Seed].Type;
                SecondSlot.Health = UnitList[Seed].Health;
                SecondSlot.Attack = UnitList[Seed].Attack;
                SecondSlot.Vitality = UnitList[Seed].Vitality;
                SecondSlot.Cost = UnitList[Seed].Cost;
                SecondSlot.Exp = UnitList[Seed].Exp;
                SecondSlot.Level = UnitList[Seed].Level;
                SecondSlot.Image = UnitList[Seed].Image;

                Seed = Rnd.Next(UnitList.Count);

                ThirdSlot.ID = UnitList[Seed].ID;
                ThirdSlot.Name = UnitList[Seed].Name;
                ThirdSlot.Race = UnitList[Seed].Race;
                ThirdSlot.Type = UnitList[Seed].Type;
                ThirdSlot.Health = UnitList[Seed].Health;
                ThirdSlot.Attack = UnitList[Seed].Attack;
                ThirdSlot.Vitality = UnitList[Seed].Vitality;
                ThirdSlot.Cost = UnitList[Seed].Cost;
                ThirdSlot.Exp = UnitList[Seed].Exp;
                ThirdSlot.Level = UnitList[Seed].Level;
                ThirdSlot.Image = UnitList[Seed].Image;
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
                FirstItemSlot.Image = ItemList[Seed].Image;

                Seed = Rnd.Next(ItemList.Count);

                SecondItemSlot.Name = ItemList[Seed].Name;
                SecondItemSlot.Type = ItemList[Seed].Type;
                SecondItemSlot.HealthBuff = ItemList[Seed].HealthBuff;
                SecondItemSlot.AttackBuff = ItemList[Seed].AttackBuff;
                SecondItemSlot.VitalityBuff = ItemList[Seed].VitalityBuff;
                SecondItemSlot.Cost = ItemList[Seed].Cost;
                SecondItemSlot.Image = ItemList[Seed].Image;

                Seed = Rnd.Next(ItemList.Count);

                ThirdItemSlot.Name = ItemList[Seed].Name;
                ThirdItemSlot.Type = ItemList[Seed].Type;
                ThirdItemSlot.HealthBuff = ItemList[Seed].HealthBuff;
                ThirdItemSlot.AttackBuff = ItemList[Seed].AttackBuff;
                ThirdItemSlot.VitalityBuff = ItemList[Seed].VitalityBuff;
                ThirdItemSlot.Cost = ItemList[Seed].Cost;
                ThirdItemSlot.Image = ItemList[Seed].Image;
            }
            else
            {
                Console.WriteLine("Список карт пуст!");
                return;
            }
        }

        public static void RandomSpellToShop()
        {
            if (SpellList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(SpellList.Count);

                FirstSpellSlot.Name = SpellList[Seed].Name;
                FirstSpellSlot.RaceCondition = SpellList[Seed].RaceCondition;
                FirstSpellSlot.TypeCondition = SpellList[Seed].TypeCondition;
                FirstSpellSlot.HealthBuff = SpellList[Seed].HealthBuff;
                FirstSpellSlot.AttackBuff = SpellList[Seed].AttackBuff;
                FirstSpellSlot.VitalityBuff = SpellList[Seed].VitalityBuff;
                FirstSpellSlot.Cost = SpellList[Seed].Cost;
                FirstSpellSlot.Description = SpellList[Seed].Description;
                FirstSpellSlot.Image = SpellList[Seed].Image;

                Seed = Rnd.Next(SpellList.Count);

                SecondSpellSlot.Name = SpellList[Seed].Name;
                SecondSpellSlot.RaceCondition = SpellList[Seed].RaceCondition;
                SecondSpellSlot.TypeCondition = SpellList[Seed].TypeCondition;
                SecondSpellSlot.HealthBuff = SpellList[Seed].HealthBuff;
                SecondSpellSlot.AttackBuff = SpellList[Seed].AttackBuff;
                SecondSpellSlot.VitalityBuff = SpellList[Seed].VitalityBuff;
                SecondSpellSlot.Cost = SpellList[Seed].Cost;
                SecondSpellSlot.Description = SpellList[Seed].Description;
                SecondSpellSlot.Image = SpellList[Seed].Image;

                Seed = Rnd.Next(SpellList.Count);

                ThirdSpellSlot.Name = SpellList[Seed].Name;
                ThirdSpellSlot.RaceCondition = SpellList[Seed].RaceCondition;
                ThirdSpellSlot.TypeCondition = SpellList[Seed].TypeCondition;
                ThirdSpellSlot.HealthBuff = SpellList[Seed].HealthBuff;
                ThirdSpellSlot.AttackBuff = SpellList[Seed].AttackBuff;
                ThirdSpellSlot.VitalityBuff = SpellList[Seed].VitalityBuff;
                ThirdSpellSlot.Cost = SpellList[Seed].Cost;
                ThirdSpellSlot.Description = SpellList[Seed].Description; 
                ThirdSpellSlot.Image = SpellList[Seed].Image;
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
                    CrewClass.Slot1.ID = CardFromShop.ID;
                    CrewClass.Slot1.Name = CardFromShop.Name;
                    CrewClass.Slot1.Race = CardFromShop.Race;
                    CrewClass.Slot1.Type = CardFromShop.Type;
                    CrewClass.Slot1.Health = CardFromShop.Health;
                    CrewClass.Slot1.Attack = CardFromShop.Attack;
                    CrewClass.Slot1.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot1.Cost = CardFromShop.Cost;
                    CrewClass.Slot1.Exp = CardFromShop.Exp;
                    CrewClass.Slot1.Level = CardFromShop.Level;
                    CrewClass.Slot1.Image = CardFromShop.Image;
                    CrewClass.CrewSize++;
                    break;
                case 1:
                    CrewClass.Slot2.ID = CardFromShop.ID;
                    CrewClass.Slot2.Name = CardFromShop.Name;
                    CrewClass.Slot2.Race = CardFromShop.Race;
                    CrewClass.Slot2.Type = CardFromShop.Type;
                    CrewClass.Slot2.Health = CardFromShop.Health;
                    CrewClass.Slot2.Attack = CardFromShop.Attack;
                    CrewClass.Slot2.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot2.Cost = CardFromShop.Cost;
                    CrewClass.Slot2.Exp = CardFromShop.Exp;
                    CrewClass.Slot2.Level = CardFromShop.Level;
                    CrewClass.Slot2.Image = CardFromShop.Image;
                    CrewClass.CrewSize++;
                    break;
                case 2:
                    CrewClass.Slot3.ID = CardFromShop.ID;
                    CrewClass.Slot3.Name = CardFromShop.Name;
                    CrewClass.Slot3.Race = CardFromShop.Race;
                    CrewClass.Slot3.Type = CardFromShop.Type;
                    CrewClass.Slot3.Health = CardFromShop.Health;
                    CrewClass.Slot3.Attack = CardFromShop.Attack;
                    CrewClass.Slot3.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot3.Cost = CardFromShop.Cost;
                    CrewClass.Slot3.Exp = CardFromShop.Exp;
                    CrewClass.Slot3.Level = CardFromShop.Level;
                    CrewClass.Slot3.Image = CardFromShop.Image;
                    CrewClass.CrewSize++;
                    break;
                case 3:
                    CrewClass.Slot4.ID = CardFromShop.ID;
                    CrewClass.Slot4.Name = CardFromShop.Name;
                    CrewClass.Slot4.Race = CardFromShop.Race;
                    CrewClass.Slot4.Type = CardFromShop.Type;
                    CrewClass.Slot4.Health = CardFromShop.Health;
                    CrewClass.Slot4.Attack = CardFromShop.Attack;
                    CrewClass.Slot4.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot4.Cost = CardFromShop.Cost;
                    CrewClass.Slot4.Exp = CardFromShop.Exp;
                    CrewClass.Slot4.Level = CardFromShop.Level;
                    CrewClass.Slot4.Image = CardFromShop.Image;
                    CrewClass.CrewSize++;
                    break;
                case 4:
                    CrewClass.Slot5.ID = CardFromShop.ID;
                    CrewClass.Slot5.Name = CardFromShop.Name;
                    CrewClass.Slot5.Race = CardFromShop.Race;
                    CrewClass.Slot5.Type = CardFromShop.Type;
                    CrewClass.Slot5.Health = CardFromShop.Health;
                    CrewClass.Slot5.Attack = CardFromShop.Attack;
                    CrewClass.Slot5.Vitality = CardFromShop.Vitality;
                    CrewClass.Slot5.Cost = CardFromShop.Cost;
                    CrewClass.Slot5.Exp = CardFromShop.Exp;
                    CrewClass.Slot5.Level = CardFromShop.Level;
                    CrewClass.Slot5.Image = CardFromShop.Image;
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
                    InventoryClass.Slot1.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 1:
                    InventoryClass.Slot2.Name = CardFromShop.Name;
                    InventoryClass.Slot2.Type = CardFromShop.Type;
                    InventoryClass.Slot2.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot2.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot2.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot2.Cost = CardFromShop.Cost;
                    InventoryClass.Slot2.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 2:
                    InventoryClass.Slot3.Name = CardFromShop.Name;
                    InventoryClass.Slot3.Type = CardFromShop.Type;
                    InventoryClass.Slot3.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot3.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot3.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot3.Cost = CardFromShop.Cost;
                    InventoryClass.Slot3.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 3:
                    InventoryClass.Slot4.Name = CardFromShop.Name;
                    InventoryClass.Slot4.Type = CardFromShop.Type;
                    InventoryClass.Slot4.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot4.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot4.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot4.Cost = CardFromShop.Cost;
                    InventoryClass.Slot4.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 4:
                    InventoryClass.Slot5.Name = CardFromShop.Name;
                    InventoryClass.Slot5.Type = CardFromShop.Type;
                    InventoryClass.Slot5.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot5.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot5.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot5.Cost = CardFromShop.Cost;
                    InventoryClass.Slot5.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 5:
                    InventoryClass.Slot6.Name = CardFromShop.Name;
                    InventoryClass.Slot6.Type = CardFromShop.Type;
                    InventoryClass.Slot6.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot6.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot6.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot6.Cost = CardFromShop.Cost;
                    InventoryClass.Slot6.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                default:
                    break;
            }
        }

        static public void FromShopToSpellBook(Spell CardFromShop)
        {          
            SpellBookClass.PlayerSpell.Name = CardFromShop.Name;
            SpellBookClass.PlayerSpell.RaceCondition = CardFromShop.RaceCondition;
            SpellBookClass.PlayerSpell.TypeCondition = CardFromShop.TypeCondition;
            SpellBookClass.PlayerSpell.HealthBuff = CardFromShop.HealthBuff;
            SpellBookClass.PlayerSpell.AttackBuff = CardFromShop.AttackBuff;
            SpellBookClass.PlayerSpell.VitalityBuff = CardFromShop.VitalityBuff;
            SpellBookClass.PlayerSpell.Cost = CardFromShop.Cost;
            SpellBookClass.PlayerSpell.Description = CardFromShop.Description;
            SpellBookClass.PlayerSpell.Image = CardFromShop.Image;
            SpellBookClass.SpellBookSize++;

            CardFromShop.SpellUse();
        }
    }
}
