using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Windows.Controls;
using System.Windows;

namespace Fight_For_Daedwin
{
    class Card : IEquatable<Card>
    {
        public int ID;

        public string Name;
        public string Race;
        public string Type;

        public int Health;
        public int Attack;
        public int Vitality;

        public int Cost;

        public string Image;

        public int Exp = 0;
        public int Level = 1;

        public bool Equals(Card other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                   this.Race == other.Race &&
                   this.Type == other.Type &&
                   this.Health == other.Health &&
                   this.Attack == other.Attack &&
                   this.Vitality == other.Vitality &&
                   this.Cost == other.Cost &&
                   this.Image == other.Image;
        }

        public override bool Equals(object obj) => Equals(obj as Card);
        public override int GetHashCode() => (Name, Race, Type, Health, Attack, Vitality, Cost, Image).GetHashCode();

        public Card()
        {
            Name = "Не выбрано";
            Image = "Default.png";
        }
        public Card(string name = "Копейщик",
            string race = "Человек",
            string type = "Ближний бой",
            int health = 100,
            int attack = 1,
            int vitality = 10,
            int cost = 2,
            string image = "ElfArcher.jpg")
        {
            Name = name;
            Race = race;
            Type = type;
            Health = health;
            Attack = attack;
            Vitality = vitality;
            Cost = cost;
            Image = image;
        }

        public void AddUnitToXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement CardElem = xDoc.CreateElement("Card");

            // создаем атрибут name
            XmlAttribute NameAttr = xDoc.CreateAttribute("Name");

            // создаем элементы company и age
            XmlElement IDElem = xDoc.CreateElement("ID");
            XmlElement RaceElem = xDoc.CreateElement("Race");
            XmlElement TypeElem = xDoc.CreateElement("Type");
            XmlElement HealthElem = xDoc.CreateElement("Health");
            XmlElement AttackElem = xDoc.CreateElement("Attack");
            XmlElement VitalityElem = xDoc.CreateElement("Vitality");
            XmlElement CostElem = xDoc.CreateElement("Cost");
            XmlElement ImageElem = xDoc.CreateElement("Image");

            // создаем текстовые значения для элементов и атрибута
            XmlText IDText = xDoc.CreateTextNode(this.ID.ToString());
            XmlText NameText = xDoc.CreateTextNode(this.Name);
            XmlText RaceText = xDoc.CreateTextNode(this.Race);
            XmlText TypeText = xDoc.CreateTextNode(this.Type);
            XmlText HealthText = xDoc.CreateTextNode(this.Health.ToString());
            XmlText AttackText = xDoc.CreateTextNode(this.Attack.ToString());
            XmlText VitalityText = xDoc.CreateTextNode(this.Vitality.ToString());
            XmlText CostText = xDoc.CreateTextNode(this.Cost.ToString());
            XmlText ImageText = xDoc.CreateTextNode(this.Image);

            //добавляем узлы
            NameAttr.AppendChild(NameText);
            IDElem.AppendChild(IDText);
            RaceElem.AppendChild(RaceText);
            TypeElem.AppendChild(TypeText);
            HealthElem.AppendChild(HealthText);
            AttackElem.AppendChild(AttackText);
            VitalityElem.AppendChild(VitalityText);
            CostElem.AppendChild(CostText);
            ImageElem.AppendChild(ImageText);

            // добавляем атрибут name
            CardElem.Attributes.Append(NameAttr);
            // добавляем элементы company и age
            CardElem.AppendChild(IDElem);
            CardElem.AppendChild(RaceElem);
            CardElem.AppendChild(TypeElem);
            CardElem.AppendChild(HealthElem);
            CardElem.AppendChild(AttackElem);
            CardElem.AppendChild(VitalityElem);
            CardElem.AppendChild(CostElem);
            CardElem.AppendChild(ImageElem);
            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(CardElem);
            // сохраняем изменения xml-документа в файл
            xDoc.Save(path);
        }

        public void RemoveFromXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlElement xNode in xRoot)
            {
                if (xNode.Attributes.GetNamedItem("Name").Value == this.Name)
                {
                    xRoot.RemoveChild(xNode);
                }
            }
            xDoc.Save(path);
        }

        public void isDead()
        {
            Type = "";
            Race = "";
            Health = 0;
            Attack = 0;
            Vitality = 0;
            Name = "Убит";
            Image = "Dead.png";
        }

        public void lvlUp()
        {
            if (this.Exp >= 250 && this.Level <=2)
            {
                this.Exp = 0;
                if (this.Level == 1)
                {
                    this.Level++;
                    Card NewCard = ShopClass.UnitListLevel2.Find(x => x.ID == this.ID + 1);
                    if (NewCard != null)
                    {
                        UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, $"Отряд {this.Name} получил повышение уровня и бонус к характеристикам (+{NewCard.Attack} AP, +{NewCard.Vitality} VP, +{NewCard.Health} HP)! Теперь в вашем отряде {NewCard.Name}");

                        this.ID = NewCard.ID;
                        this.Type = NewCard.Type;
                        this.Race = NewCard.Race;
                        this.Health += NewCard.Health;
                        this.Attack += NewCard.Attack;
                        this.Vitality += NewCard.Vitality;
                        this.Name = NewCard.Name;
                        this.Image = NewCard.Image;
                    }
                    else
                        return;
                }
                else if (this.Level == 2)
                {
                    this.Level++;
                    Card NewCard = ShopClass.UnitListLevel3.Find(x => x.ID == this.ID + 1);
                    if (NewCard != null)
                    {
                        UIClass.AddTextToLog(((MainWindow)Application.Current.MainWindow).GameLog, $"Отряд {this.Name} получил повышение уровня и бонус к характеристикам (+{NewCard.Attack} AP, +{NewCard.Vitality} VP, +{NewCard.Health} HP)! Теперь в вашем отряде {NewCard.Name}");

                        this.ID = NewCard.ID;
                        this.Type = NewCard.Type;
                        this.Race = NewCard.Race;
                        this.Health += NewCard.Health;
                        this.Attack += NewCard.Attack;
                        this.Vitality += NewCard.Vitality;
                        this.Name = NewCard.Name;
                        this.Image = NewCard.Image;
                    }
                    else
                        return;
                }
            }
            else
                return;
        }
    }
}
