using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows;
using System.Threading;

namespace Fight_For_Daedwin
{
    static class MonsterFightClass
    {
        static public int Stage = 1;
        static public bool DeadMonsterCrew = false;

        static public List<Monster> MonsterList; //Список ВСЕХ монстров (Для рандома)

        public static List<Monster> XMLParser(string PathToXML)
        {
            List<Monster> AllertList = new List<Monster>();
            XmlDocument xDoc = new XmlDocument();

            if (!File.Exists(PathToXML))
            {
                var xmlWriter = new XmlTextWriter(PathToXML, null);
                xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
                xmlWriter.WriteStartElement("Data");             // <Data> 
                xmlWriter.WriteEndElement();                     // </Data>
                xmlWriter.Close();

                Monster newCard = new Monster();
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
                    Monster AllertObj = new Monster();
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
                        if (childnode.Name == "Health")
                        {
                            AllertObj.Health = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "Attack")
                        {
                            AllertObj.Attack = Int32.Parse(childnode.InnerText);
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

        public static void RandomMonsterToFight()
        {//Можно сделать логику появления монстров интереснее, пока идей нет
            if (MonsterList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(MonsterList.Count);

                EnemyCrewClass.Slot1.Name = MonsterList[Seed].Name;
                EnemyCrewClass.Slot1.Race = MonsterList[Seed].Race;
                EnemyCrewClass.Slot1.Health = MonsterList[Seed].Health;
                EnemyCrewClass.Slot1.Attack = MonsterList[Seed].Attack;
                EnemyCrewClass.Slot1.Image = MonsterList[Seed].Image;

                Seed = Rnd.Next(MonsterList.Count);

                EnemyCrewClass.Slot2.Name = MonsterList[Seed].Name;
                EnemyCrewClass.Slot2.Race = MonsterList[Seed].Race;
                EnemyCrewClass.Slot2.Health = MonsterList[Seed].Health;
                EnemyCrewClass.Slot2.Attack = MonsterList[Seed].Attack;
                EnemyCrewClass.Slot2.Image = MonsterList[Seed].Image;

                Seed = Rnd.Next(MonsterList.Count);

                EnemyCrewClass.Slot3.Name = MonsterList[Seed].Name;
                EnemyCrewClass.Slot3.Race = MonsterList[Seed].Race;
                EnemyCrewClass.Slot3.Health = MonsterList[Seed].Health;
                EnemyCrewClass.Slot3.Attack = MonsterList[Seed].Attack;
                EnemyCrewClass.Slot3.Image = MonsterList[Seed].Image;
            }
            else
            {
                Console.WriteLine("Список монстров пуст!");
                return;
            }
        }

        public static void FightAction()
        {
            while (EnemyCrewClass.Slot1.Health > 0)
            {
                int SumAttackCrew = 0;
                Random Rnd = new Random();
                int RandomCardNumber = Rnd.Next(CrewClass.CardInActionList.Count);

                foreach (Card card in CrewClass.CardInActionList)
                    SumAttackCrew += card.Attack;
                EnemyCrewClass.Slot1.Health -= SumAttackCrew;
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, $"Ваши бойцы нанесли {SumAttackCrew} урона по {EnemyCrewClass.Slot1.Name}");

                UIClass.UIRefreshCrew(((MainWindow)Application.Current.MainWindow).PlayerCrew1, ((MainWindow)Application.Current.MainWindow).ImageCrew1,
                                      ((MainWindow)Application.Current.MainWindow).PlayerCrew2, ((MainWindow)Application.Current.MainWindow).ImageCrew2,
                                      ((MainWindow)Application.Current.MainWindow).PlayerCrew3, ((MainWindow)Application.Current.MainWindow).ImageCrew3,
                                      ((MainWindow)Application.Current.MainWindow).PlayerCrew4, ((MainWindow)Application.Current.MainWindow).ImageCrew4,
                                      ((MainWindow)Application.Current.MainWindow).PlayerCrew5, ((MainWindow)Application.Current.MainWindow).ImageCrew5);

                if (EnemyCrewClass.Slot1.Health <= 0)
                    break;

                CrewClass.CardInActionList[RandomCardNumber].Health -= EnemyCrewClass.Slot1.Attack;
                if (CrewClass.CardInActionList[RandomCardNumber].Health <= 0)
                {
                    CrewClass.CardInActionList.RemoveAt(RandomCardNumber);
                    UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, $"Ваш {CrewClass.CardInActionList[RandomCardNumber].Name} погиб");
                }
                UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, $"Вражеский {EnemyCrewClass.Slot1.Name} нанес {EnemyCrewClass.Slot1.Attack} урона по {CrewClass.CardInActionList[RandomCardNumber].Name}");
            }
        }
    }
}
