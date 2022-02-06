using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCAPEN_2021.Logica
{
    public class Modulos
    {
        int idModulo;
        String modulo;

        public Modulos(int idModulo, string modulo)
        {
            this.idModulo = idModulo;
            this.modulo = modulo;
        }
        public Modulos()
        {

        }

        public void setIdModulo(int idModulo) { this.idModulo = idModulo; }
        public int getIdModulo() { return idModulo; }

        public void setModulo(String modulo) { this.modulo = modulo; }
        public String getModulo() { return modulo; }
    }
}
