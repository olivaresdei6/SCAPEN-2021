using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCAPEN_2021.Logica
{
    public class Permisos
    {
        int idPermiso;
        int idModulo;
        int idUsuario;

        public Permisos(int idPermiso, int idModulo, int idUsuario)
        {
            this.idPermiso = idPermiso;
            this.idModulo = idModulo;
            this.idUsuario = idUsuario;
        }

        public Permisos()
        {

        }
        public void setIdPermiso(int idPermiso) { this.idPermiso = idPermiso; }
        public int getIdPermiso() { return idPermiso; }

        public void setIdModulo(int idModulo) { this.idModulo = idModulo; }
        public int getIdModulo() { return idModulo; }

        public void setIdUsuario(int idUsuario) { this.idUsuario = idUsuario; }
        public int getIdUsuario() { return idUsuario; }
    }
}
