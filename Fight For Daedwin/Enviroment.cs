using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fight_For_Daedwin
{
    class Enviroment : IEquatable<Enviroment>
    {

        public string Name;
        public string RaceAllyCondition;
        public string TypeAllyCondition;
        public string RaceEnemyCondition;

        public int HealthAllyBuff;
        public int AttackAllyBuff;
        public int VitalityAllyBuff;
        public int HealthEnemyBuff;
        public int AttackEnemyBuff;

        public string Description;

        public string Image;

        public bool Equals(Enviroment other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name &&
                   this.RaceAllyCondition == other.RaceAllyCondition &&
                   this.TypeAllyCondition == other.TypeAllyCondition &&
                   this.RaceEnemyCondition == other.RaceEnemyCondition &&
                   this.HealthAllyBuff == other.HealthAllyBuff &&
                   this.AttackAllyBuff == other.AttackAllyBuff &&
                   this.VitalityAllyBuff == other.VitalityAllyBuff &&
                   this.HealthEnemyBuff == other.HealthEnemyBuff &&
                   this.AttackEnemyBuff == other.AttackEnemyBuff &&
                   this.Image == other.Image &&
                   this.Description == other.Description;
        }

        public override bool Equals(object obj) => Equals(obj as Spell);
        public override int GetHashCode() => (Name, RaceAllyCondition, TypeAllyCondition, RaceEnemyCondition, HealthAllyBuff, AttackAllyBuff, VitalityAllyBuff,
            HealthEnemyBuff, AttackEnemyBuff, Image, Description).GetHashCode();

        public Enviroment()
        {
            Name = "Поле боя";
            RaceAllyCondition = "Не выбрано";
            TypeAllyCondition = "Не выбрано";
            RaceEnemyCondition = "Не выбрано";
            Description = "Обычное поле боя";
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
            XmlElement RaceAllyConditionElem = xDoc.CreateElement("RaceAllyCondition");
            XmlElement TypeAllyConditionElem = xDoc.CreateElement("TypeAllyCondition");
            XmlElement RaceEnemyConditionElem = xDoc.CreateElement("RaceEnemyCondition");
            XmlElement HealthAllyBuffElem = xDoc.CreateElement("HealthAllyBuff");
            XmlElement AttackAllyBuffElem = xDoc.CreateElement("AttackAllyBuff");
            XmlElement VitalityAllyBuffElem = xDoc.CreateElement("VitalityAllyBuff");
            XmlElement HealthEnemyBuffElem = xDoc.CreateElement("HealthEnemyBuff");
            XmlElement AttackEnemyBuffElem = xDoc.CreateElement("AttackEnemyBuff");
            XmlElement DescriptionElem = xDoc.CreateElement("Description");
            XmlElement ImageElem = xDoc.CreateElement("Image");

            // создаем текстовые значения для элементов и атрибута
            XmlText NameText = xDoc.CreateTextNode(this.Name);
            XmlText RaceAllyConditionText = xDoc.CreateTextNode(this.RaceAllyCondition);
            XmlText TypeAllyConditionText = xDoc.CreateTextNode(this.TypeAllyCondition);
            XmlText RaceEnemyConditionText = xDoc.CreateTextNode(this.RaceEnemyCondition);
            XmlText HealthAllyBuffText = xDoc.CreateTextNode(this.HealthAllyBuff.ToString());
            XmlText AttackAllyBuffText = xDoc.CreateTextNode(this.AttackAllyBuff.ToString());
            XmlText VitalityAllyBuffText = xDoc.CreateTextNode(this.VitalityAllyBuff.ToString());
            XmlText HealthEnemyBuffText = xDoc.CreateTextNode(this.HealthEnemyBuff.ToString());
            XmlText AttackEnemyBuffText = xDoc.CreateTextNode(this.AttackEnemyBuff.ToString());
            XmlText DescriptionText = xDoc.CreateTextNode(this.Description);
            XmlText ImageText = xDoc.CreateTextNode(this.Image);

            //добавляем узлы
            NameAttr.AppendChild(NameText);
            RaceAllyConditionElem.AppendChild(RaceAllyConditionText);
            TypeAllyConditionElem.AppendChild(TypeAllyConditionText);
            RaceEnemyConditionElem.AppendChild(RaceEnemyConditionText);
            HealthAllyBuffElem.AppendChild(HealthAllyBuffText);
            AttackAllyBuffElem.AppendChild(AttackAllyBuffText);
            VitalityAllyBuffElem.AppendChild(VitalityAllyBuffText);
            HealthEnemyBuffElem.AppendChild(HealthEnemyBuffText);
            AttackEnemyBuffElem.AppendChild(AttackEnemyBuffText);
            DescriptionElem.AppendChild(DescriptionText);
            ImageElem.AppendChild(ImageText);

            // добавляем атрибут name
            CardElem.Attributes.Append(NameAttr);
            // добавляем элементы company и age
            CardElem.AppendChild(RaceAllyConditionElem);
            CardElem.AppendChild(TypeAllyConditionElem);
            CardElem.AppendChild(RaceEnemyConditionElem);
            CardElem.AppendChild(HealthAllyBuffElem);
            CardElem.AppendChild(AttackAllyBuffElem);
            CardElem.AppendChild(VitalityAllyBuffElem);
            CardElem.AppendChild(HealthEnemyBuffElem);
            CardElem.AppendChild(AttackEnemyBuffElem);
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

        public void EnviromentUseAlly()
        {
            foreach (Card card in CrewClass.CrewList)
            {
                if (card.Race == this.RaceAllyCondition || card.Type == this.TypeAllyCondition)
                {
                    card.Health += this.HealthAllyBuff;
                    card.Attack += this.AttackAllyBuff;
                    card.Vitality += this.VitalityAllyBuff;
                }
            }
        }
        public void EnviromentUseEnemy()
        {
            foreach (Monster card in EnemyCrewClass.CrewList)
            {
                if (card.Race == this.RaceEnemyCondition)
                {
                    card.Health += this.HealthEnemyBuff;
                    card.Attack += this.AttackEnemyBuff;
                }
            }
        }
        public void EnviromentUnuseAlly()
        {
            foreach (Card card in CrewClass.CrewList)
            {
                if (card.Race == this.RaceAllyCondition || card.Type == this.TypeAllyCondition)
                {
                    card.Health -= this.HealthAllyBuff;
                    card.Attack -= this.AttackAllyBuff;
                    card.Vitality -= this.VitalityAllyBuff;

                    if (card.Health <= 0)
                        card.Health = 1;
                    if (card.Attack <= 0)
                        card.Attack = 1;
                    if (card.Vitality <= 0)
                        card.Vitality = 1;
                }
            }
        }
        public void EnviromentUnuseEnemy()
        {
            foreach (Monster card in EnemyCrewClass.CrewList)
            {
                if (card.Race == this.RaceEnemyCondition)
                {
                    card.Health -= this.HealthEnemyBuff;
                    card.Attack -= this.AttackEnemyBuff;

                    if (card.Health <= 0)
                        card.Health = 1;
                    if (card.Attack <= 0)
                        card.Attack = 1;
                }
            }
        }
    }
}
