using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //VAMOS A ALMACENAR DATOS EN SESSION MEDIANTE
        //EL METODO GetString, SetString
        public static string SerializeObject<T>(T data)
        {
            //CONVERTIMOS EL OBJETO A STRING MEDIANTE NEWTON
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        //RECIBIMOS UN STRING Y DEVOLVER CUALQUIER OBJETO
        public static T DeserializeObject<T>(string data)
        {
            //MEDIANTE NEWTON DESERIALIZAMOS EL OBJETO
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}
