using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCAPEN_2021.Logica
{
    public class Persona
    {
        int id_Personal;
        String identificacion;
        String nombres;
        String apellidos;
        int codigo;
        String pais;
        int id_Cargo;
        float sueldoPorHora;
        String estado;

        public Persona()
        {

        }
        public Persona(int id_Personal, string identificacion, string nombres, string apellidos, int codigo, 
                       string pais, int id_Cargo, float sueldoPorHora, string estado)
        {
            this.id_Personal = id_Personal;
            this.identificacion = identificacion;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.codigo = codigo;
            this.pais = pais;
            this.id_Cargo = id_Cargo;
            this.sueldoPorHora = sueldoPorHora;
            this.estado = estado;
        }

        public int getIdPersonal() { return id_Personal; }
        public void setIdPersonal(int id_Personal) { this.id_Personal = id_Personal; }

        public String getIdentificacion() { return identificacion; }
        public void setIdentificacion(String identificacion) { this.identificacion = identificacion; }

        public String getNombres() { return nombres; }
        public void setNombres(String nombres) { this.nombres = nombres; }

        public String getApellidos() { return apellidos; }
        public void setApellidos(String apellidos) { this.apellidos = apellidos; }

        public int getCodigo() { return codigo; }
        public void setCodigo(int codigo) { this.codigo = codigo; }

        public String getPais() { return pais; }
        public void setPais(String pais) { this.pais = pais; }

        public int getId_Cargo() { return id_Cargo; }
        public void setId_Cargo(int id_Cargo) { this.id_Cargo = id_Cargo; }

        public float getSueldoPorHora() { return sueldoPorHora; }
        public void setSueldoPorHora(float sueldoPorHora) { this.sueldoPorHora = sueldoPorHora; }

        public String getEstado() { return estado; }
        public void setEstado(String estado) { this.estado = estado; }

    }
}
