using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fight_For_Daedwin
{
    class Spell : IEquatable<Spell>
    {

        public string Name;
        public string RaceCondition;
        public string TypeCondition;

        public int HealthBuff;
        public int AttackBuff;
        public int VitalityBuff;

        public int Cost;
        public string Description;

        public string Image;

        public bool Equals(Spell other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                   this.RaceCondition == other.RaceCondition &&
                   this.TypeCondition == other.TypeCondition &&
                   this.HealthBuff == other.HealthBuff &&
                   this.AttackBuff == other.AttackBuff &&
                   this.VitalityBuff == other.VitalityBuff &&
                   this.Cost == other.Cost &&
                   this.Image == other.Image &&
                   this.Description == other.Description;
        }

        public override bool Equals(object obj) => Equals(obj as Spell);
        public override int GetHashCode() => (Name, RaceCondition, TypeCondition, HealthBuff, AttackBuff, VitalityBuff, Cost, Image, Description).GetHashCode();

        public Spell()
        {
            Name = "Не выбрано";
            RaceCondition = "Не выбрано";
            TypeCondition = "Не выбрано";
            Description = "Выберете заклинание на соответсвующей стадии игры";
            Image = "Default.png";
        }
        public Spell(string name = "За честь!",
            string raceCondition = "Человек",
            string typeCondition = "Ближний бой",
            int healthBuff = 50,
            int attackBuff = 2,
            int vitalityBuff = 0,
            int cost = 2,
            string description = "Все бойцы ближнего боя люди получают бонус к здоровью 50 и бонус к атаке 2", 
            string image = "For the Glory.jpg")
        {
            Name = name;
            RaceCondition = raceCondition;
            TypeCondition = typeCondition;
            HealthBuff = healthBuff;
            AttackBuff = attackBuff;
            VitalityBuff = vitalityBuff;
            Cost = cost;
            Description = description;
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
            XmlElement RaceConditionElem = xDoc.CreateElement("RaceCondition");
            XmlElement TypeConditionElem = xDoc.CreateElement("TypeCondition");
            XmlElement HealthBuffElem = xDoc.CreateElement("HealthBuff");
            XmlElement AttackBuffElem = xDoc.CreateElement("AttackBuff");
            XmlElement VitalityBuffElem = xDoc.CreateElement("VitalityBuff");
            XmlElement CostElem = xDoc.CreateElement("Cost");
            XmlElement DescriptionElem = xDoc.CreateElement("Description");
            XmlElement ImageElem = xDoc.CreateElement("Image");

            // создаем текстовые значения для элементов и атрибута
            XmlText NameText = xDoc.CreateTextNode(this.Name);
            XmlText RaceConditionText = xDoc.CreateTextNode(this.RaceCondition);
            XmlText TypeConditionText = xDoc.CreateTextNode(this.TypeCondition);
            XmlText HealthBuffText = xDoc.CreateTextNode(this.HealthBuff.ToString());
            XmlText AttackBuffText = xDoc.CreateTextNode(this.AttackBuff.ToString());
            XmlText VitalityBuffText = xDoc.CreateTextNode(this.VitalityBuff.ToString());
            XmlText CostText = xDoc.CreateTextNode(this.Cost.ToString());
            XmlText DescriptionText = xDoc.CreateTextNode(this.Description);
            XmlText ImageText = xDoc.CreateTextNode(this.Image);

            //добавляем узлы
            NameAttr.AppendChild(NameText);
            RaceConditionElem.AppendChild(RaceConditionText);
            TypeConditionElem.AppendChild(TypeConditionText);
            HealthBuffElem.AppendChild(HealthBuffText);
            AttackBuffElem.AppendChild(AttackBuffText);
            VitalityBuffElem.AppendChild(VitalityBuffText);
            CostElem.AppendChild(CostText);
            DescriptionElem.AppendChild(DescriptionText);
            ImageElem.AppendChild(ImageText);

            // добавляем атрибут name
            CardElem.Attributes.Append(NameAttr);
            // добавляем элементы company и age
            CardElem.AppendChild(RaceConditionElem);
            CardElem.AppendChild(TypeConditionElem);
            CardElem.AppendChild(HealthBuffElem);
            CardElem.AppendChild(AttackBuffElem);
            CardElem.AppendChild(VitalityBuffElem);
            CardElem.AppendChild(CostElem);
            CardElem.AppendChild(DescriptionElem);
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

        public void SpellUse()
        {
            foreach (Card card in CrewClass.CrewList)
            {
                if(card.Race == this.RaceCondition || card.Type == this.TypeCondition)
                {
                    card.Health += this.HealthBuff;
                    card.Attack += this.AttackBuff;
                    card.Vitality += this.VitalityBuff;
                }
            }
        }
    }
}
