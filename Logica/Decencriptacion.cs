using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SCAPEN_2021.Logica
{
    public class Decencriptacion
    {
        static private Encriptacion aes = new Encriptacion();
        static public string CnString;
        static string dbcnString;
        static public string appPwdUnique = "+@SC@PEN2021._-sc@pen2021@+";
        public static object checkServer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            dbcnString = root.Attributes[0].Value;
            CnString = (aes.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;
        }
    }
}
