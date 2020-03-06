using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SampleXML
{
    /// <summary>
    /// Список сокращений
    /// </summary>
    /// <param name="name">Имя файла или URL</param>
    
    [XmlRoot("AcronymList", Namespace = "http://www.orioner.ru/croc")]
    public class AcronymArray
    {
        [XmlElement(ElementName ="Acronym")]
        public List<AcronymWord> Acronym;

        public static AcronymArray Load(string name)
        {
            var xmlSerializer = new XmlSerializer(typeof(AcronymArray));
            // Подготовка к чтению XML-файла
            XmlReader reader = XmlReader.Create(name);
            return (AcronymArray)xmlSerializer.Deserialize(reader);
        }

        public void Save(string name)
        {
            var xmlSerializer = new XmlSerializer(typeof(AcronymArray));
            // Настройка записи
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true // Человеческое форматирование
            };
            using (XmlWriter writer = XmlWriter.Create(name, xmlWriterSettings))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}