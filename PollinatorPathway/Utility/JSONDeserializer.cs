using System.Runtime.Serialization.Json;
using System.Text;

namespace PollinatorPathway.Utility
{
    public class JSONDeserializer   //https://stackoverflow.com/questions/34407061/good-but-easy-method-of-deserializing-json-data-in-c-sharp#:~:text=You%20probably%20want%20to%20deserialize%20the%20string%20%28JSON%29,the%20JsonConvert.DeserializeObject%20method.%20var%20myObject%20%3D%20JsonConvert.DeserializeObject%3CMyClass%3E%20%28json%29%3B
    {
        public static T Deserialize<T>(string json)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T obj = (T)serializer.ReadObject(stream);
                return obj;
            }
        }
    }
}
