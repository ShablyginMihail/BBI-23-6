using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab9_2.Serializers;
using ProtoBuf;

namespace Lab9_2.Serializers
{
    internal class MySerializeBin : ISer
    {
        public MySerializeBin() { }
        public void Write<T>(T obj, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Serializer.Serialize<T>(fs, obj);
            }
        }

        public T Read<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return Serializer.Deserialize<T>(fs);
            }
        }
    }
}

