using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public  class HerlperBinarySession
    {
        //VAMOS A CREAR LOS METODOS DE TIPO static
        //PORQUE PARA CONVERTIR NO VO VOY A UTILIZAR NADA DE ESTA CLASE
        //SOLO LA FUNCIONALIDAD
        //CONVERTIMOS OBJETO A BYTE[]
        public static byte[] ObjectToByte(Object objeto)
        {

        #pragma warning disable SYSLIB0011 // Type or member is obsolete
            BinaryFormatter formatter =
                new BinaryFormatter();
        #pragma warning restore SYSLIB0011 // Type or member is obsolete
        #pragma warning restore SYSLIB0011
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }
        //CONVERTIMOS DE BYTE[] A OBJETO
        public static Object ByteToObject(byte[] data)
        {
        #pragma warning disable SYSLIB0011 // Type or member is obsolete
            BinaryFormatter formatter =
                new BinaryFormatter();
        #pragma warning restore SYSLIB0011 // Type or member is obsolete
        #pragma warning restore SYSLIB0011
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object objeto = (Object)
                    formatter.Deserialize(stream);
                return objeto;
            }
        }
    }
}
