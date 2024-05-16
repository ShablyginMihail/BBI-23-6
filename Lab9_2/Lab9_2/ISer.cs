using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_2.Serializers
{
    internal interface ISer
    {
        public void Write<T>(T obj, string path);
        public T Read<T>(string path);
    }
}