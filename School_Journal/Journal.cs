using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Runtime.Serialization.Json;
using System.Text;
//using System.Text.Json;
using System.Xml.Serialization;

namespace School_Journal
{
    [Serializable]
    public class Journal
    {
        [XmlAttribute]
        public string Surname;
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public DateTime Birthday;
        [XmlAttribute]
        public int num = 0;

        public Journal()
        {

        }

        public Journal(string surname, string name, DateTime birthday)
        {
            this.Surname = surname;
            this.Name = name;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{this.Surname} {this.Name} {this.Birthday}";
        }
        static public void Serealize_it(List<Journal> objectGrath, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Journal>));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fStream, objectGrath);
            }
        }
        static public void Deserealize_it(string filename, out List<Journal> lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Journal>));
            using (Stream fStream = new FileStream(filename, FileMode.OpenOrCreate,
                FileAccess.Read))
            {
                lst = (List<Journal>)xmlSerializer.Deserialize(fStream);
            }
        }
    }
}
