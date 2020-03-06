using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleXML
{
    public class AcronymWord
    {
        /// <summary>
        /// Сокращение
        /// </summary>
        [XmlAttribute()]
        public string Name;

        /// <summary>
        /// Категория (предметная область)
        /// </summary>
        [XmlAnyAttribute()]
        public string Category;

        /// <summary>
        /// Расшифровка
        /// </summary>
        [XmlText()]
        public string Discription;
    }
}
