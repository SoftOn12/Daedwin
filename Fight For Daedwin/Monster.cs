using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    class Monster : IEquatable<Monster>
    {
        public string Name;
        public string Race;

        public int Health;
        public int Attack;

        public string Image;

        public bool Equals(Monster other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                   this.Race == other.Race &&
                   this.Health == other.Health &&
                   this.Attack == other.Attack &&
                   this.Image == other.Image;
        }

        public override bool Equals(object obj) => Equals(obj as Monster);
        public override int GetHashCode() => (Name, Race, Health, Attack, Image).GetHashCode();

        public Monster()
        {
            Name = "Не выбрано";
            Image = "Default.png";
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
            XmlElement RaceElem = xDoc.CreateElement("Race");
            XmlElement HealthElem = xDoc.CreateElement("Health");
            XmlElement AttackElem = xDoc.CreateElement("Attack");
            XmlElement ImageElem = xDoc.CreateElement("Image");

            // создаем текстовые значения для элементов и атрибута
            XmlText NameText = xDoc.CreateTextNode(this.Name);
            XmlText RaceText = xDoc.CreateTextNode(this.Race);
            XmlText HealthText = xDoc.CreateTextNode(this.Health.ToString());
            XmlText AttackText = xDoc.CreateTextNode(this.Attack.ToString());
            XmlText ImageText = xDoc.CreateTextNode(this.Image);

            //добавляем узлы
            NameAttr.AppendChild(NameText);
            RaceElem.AppendChild(RaceText);
            HealthElem.AppendChild(HealthText);
            AttackElem.AppendChild(AttackText);
            ImageElem.AppendChild(ImageText);

            // добавляем атрибут name
            CardElem.Attributes.Append(NameAttr);
            // добавляем элементы company и age
            CardElem.AppendChild(RaceElem);
            CardElem.AppendChild(HealthElem);
            CardElem.AppendChild(AttackElem);
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
            Race = "";
            Health = 0;
            Attack = 0;
            Name = "Убит";
            Image = "Dead.png";
        }

        public void StageProgression()
        {
            //Каждый раунд + 5  HP и +2 АР
            GameState.MonsterProgressionIncValue = MonsterFightClass.Stage / 5;

            this.Health += GameState.MonsterProgressionIncValue * GameState.MonsterProgressionScaleHPValue;
            this.Attack += GameState.MonsterProgressionIncValue * GameState.MonsterProgressionScaleAttackValue;
        }
    }
}
