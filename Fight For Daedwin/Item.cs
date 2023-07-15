using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fight_For_Daedwin
{
    class Item : IEquatable<Item>
    {

        public string Name;
        public string Type;

        public int HealthBuff;
        public int AttackBuff;
        public int VitalityBuff;

        public int Cost;

        public string Image;

        public bool Equals(Item other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                   this.Type == other.Type &&
                   this.HealthBuff == other.HealthBuff &&
                   this.AttackBuff == other.AttackBuff &&
                   this.VitalityBuff == other.VitalityBuff &&
                   this.Cost == other.Cost &&
                   this.Image == other.Image;
        }

        public override bool Equals(object obj) => Equals(obj as Card);
        public override int GetHashCode() => (Name, Type, HealthBuff, AttackBuff, VitalityBuff, Cost, Image).GetHashCode();

        public Item() { }
        public Item(string name = "Монетка",
            string type = "Обычный",
            int health = 0,
            int attack = 0,
            int vitality = 1,
            int cost = 1,
            string image = "Coin.jpg")
        {
            Name = name;
            Type = type;
            HealthBuff = health;
            AttackBuff = attack;
            VitalityBuff = vitality;
            Cost = cost;
            Image = image;
        }

        public void AddItemToXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement CardElem = xDoc.CreateElement("Item");

            // создаем атрибут name
            XmlAttribute NameAttr = xDoc.CreateAttribute("Name");

            // создаем элементы company и age
            XmlElement TypeElem = xDoc.CreateElement("Type");
            XmlElement HealthBuffElem = xDoc.CreateElement("HealthBuff");
            XmlElement AttackBuffElem = xDoc.CreateElement("AttackBuff");
            XmlElement VitalityBuffElem = xDoc.CreateElement("VitalityBuff");
            XmlElement CostElem = xDoc.CreateElement("Cost");
            XmlElement ImageElem = xDoc.CreateElement("Image");

            // создаем текстовые значения для элементов и атрибута
            XmlText NameText = xDoc.CreateTextNode(this.Name);
            XmlText TypeText = xDoc.CreateTextNode(this.Type);
            XmlText HealthBuffText = xDoc.CreateTextNode(this.HealthBuff.ToString());
            XmlText AttackBuffText = xDoc.CreateTextNode(this.AttackBuff.ToString());
            XmlText VitalityBuffText = xDoc.CreateTextNode(this.VitalityBuff.ToString());
            XmlText CostText = xDoc.CreateTextNode(this.Cost.ToString());
            XmlText ImageText = xDoc.CreateTextNode(this.Image);

            //добавляем узлы
            NameAttr.AppendChild(NameText);
            TypeElem.AppendChild(TypeText);
            HealthBuffElem.AppendChild(HealthBuffText);
            AttackBuffElem.AppendChild(AttackBuffText);
            VitalityBuffElem.AppendChild(VitalityBuffText);
            CostElem.AppendChild(CostText);
            ImageElem.AppendChild(ImageText);

            // добавляем атрибут name
            CardElem.Attributes.Append(NameAttr);
            // добавляем элементы company и age
            CardElem.AppendChild(TypeElem);
            CardElem.AppendChild(HealthBuffElem);
            CardElem.AppendChild(AttackBuffElem);
            CardElem.AppendChild(VitalityBuffElem);
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
    }
}
