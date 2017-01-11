using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MybookingpalRestful
{
    public class Deserializer
    {

        public static TDeserializedObject GetDeserializedObject<TDeserializedObject>(string jsonstring)where TDeserializedObject:class 
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            settings.Error += onerror;
            return JsonConvert.DeserializeObject<TDeserializedObject>(jsonstring, settings);
        }

        private static void onerror(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine(errorEventArgs.ErrorContext.Error);
        }
    }
}
