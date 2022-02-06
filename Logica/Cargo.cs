using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCAPEN_2021.Logica
{
    public class Cargo
    {
        int id;
        float sueldo;
        string cargo;

        public Cargo(int id, float sueldo, string cargo)
        {
            this.id = id;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }

        public int getId() { return id; }
        public void setId(int id) { this.id = id; }

        public float getSueldo() { return sueldo; }
        public void setSueldo(float sueldo) { this.sueldo = sueldo; }

        public String getCargo() { return cargo; }
        public void setCargo(String cargo) { this.cargo = cargo; }
    }
}
