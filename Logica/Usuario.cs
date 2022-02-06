using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCAPEN_2021.Logica
{
    public class Usuario
    {
        String nombre;
        String apellidos;
        String identificacion;
        String usuario;
        String password;
        byte[] icono;

        public Usuario(string nombre, string apellidos, string identificacion, string usuario, string password, byte[] icono)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.identificacion = identificacion;
            this.usuario = usuario;
            this.password = password;
            this.icono = icono;
        }

        public void setNombre(String nombre) { this.nombre = nombre; }
        public String getNombre() { return nombre; }

        public void setApellidos(String apellidos) { this.apellidos = apellidos; }
        public String getApellidos() { return apellidos; }

        public void setIdentificacion(String identificacion) { this.nombre = identificacion; }
        public String getIdentificacion() { return identificacion; }

        public void setUsuario(String usuario) { this.usuario = usuario; }
        public String getUsuario() { return usuario; }

        public void setPassword(String password) { this.password = password; }
        public String getPassword() { return password; }

        public void setIcono(byte[] icono) { this.icono = icono; }
        public byte[] getIcono() { return icono; }
    }
}
