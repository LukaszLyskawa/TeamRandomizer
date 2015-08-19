using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TeamRandomizer
{
    public static class StringToObjectHelper
    {
        public static string CastToString<T>(T data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, data);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                return Convert.ToBase64String(buffer);
                //Properties.Settings.Default.GroupingSettings = Convert.ToBase64String(buffer);
                //Properties.Settings.Default.Save();
            }
        }

        public static T CastFromString<T>(string data)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (T)bf.Deserialize(ms);
            }
        }
    }
}
