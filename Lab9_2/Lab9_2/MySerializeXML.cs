using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lab9_2.Serializers;

namespace Lab9_2.Serializers
{
    internal class MySerializeXML : ISer
    {
        public MySerializeXML() { }

        public void Write<T>(T obj, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                new XmlSerializer(typeof(T)).Serialize(fs, obj);
            }
        }

        public T Read<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(fs);
            }
        }
    }
}

