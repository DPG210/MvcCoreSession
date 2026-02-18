using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Models;
using MvcCoreSession.Helpers;
using System.Runtime.Serialization;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.Get("MASCOTA") != null)
            {
                byte[] data = HttpContext.Session.Get("MASCOTA");
                Mascota mascota = (Mascota)Helpers.HerlperBinarySession.ByteToObject(data);
                ViewData["MASCOTA"] = mascota;
            }
            return View();
        }
        public IActionResult SessionSimple(string accion)
        {
            if(accion != null)
            {
                if (accion.ToLower() == "almacenar") 
                {
                    //GUARDAMOS DATOS EN SESSION
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "DATOS ALMACENADOS EN LA SESSION";
                }else if (accion.ToLower() == "mostrar")
                {
                    //RECUPERAMOS LOS DATOS DE SESSION
                    ViewData["NOMBRE"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }
        public IActionResult SessionMascotaBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //GUARDAMOS DATOS EN SESSION
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Wall-E";
                    mascota.Raza = "Cleaner";
                    mascota.Edad = 18;
                    //Para almacenar la mascota en Session, debemos
                    //convertirlo a byte[]
                   
                    byte[] data = HerlperBinarySession.ObjectToByte(mascota);
       
                                  //ALMACENAMOS EL OBJETO EN SESSION
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "MASCOTA ALMACENADA";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //RECUPERAMOS LOS DATOS DE MASCOTA
                    //EN BYTES QUE TENEMOS EN SESSION
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    //CONVERTIMOS BYTES A OBJECT
                    Mascota mascota = (Mascota)Helpers.HerlperBinarySession.ByteToObject(data);
                    //PARA REPRESENTARLO DE FORMA VISUAL, LO ENVIAMOS 
                    //A VIEWDATA
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }
        public IActionResult SessionMascotaCollectionBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //GUARDAMOS DATOS EN SESSION
                    List<Mascota> mascotasList = new List<Mascota>
                    {
                        new Mascota{Nombre= "Nala", Raza="Leona", Edad= 21},
                        new Mascota{Nombre= "Sebastian", Raza="cangrejo", Edad= 24},
                        new Mascota{Nombre= "Rafiki", Raza="Brujo", Edad= 23},
                        new Mascota{Nombre= "Olaf", Raza="Nieve", Edad= 210}
                    };
                    byte[] data = Helpers.HerlperBinarySession.ObjectToByte(mascotasList);
                    HttpContext.Session.Set("Mascotas", data);
                    ViewData["MENSAJE"] = "Coleccion almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("Mascotas");
                    List<Mascota> mascotasList = (List<Mascota>)Helpers.HerlperBinarySession.ByteToObject(data);
                    return View(mascotasList);
                }
            }
            return View();
        }
    }
}
