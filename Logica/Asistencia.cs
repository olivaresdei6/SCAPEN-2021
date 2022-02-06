using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCAPEN_2021.Datos;

public class Asistencia
{
    int id_personal;
    DateTime fecha_entrada;
    DateTime fecha_Salida;
    String estado;
    double hora;
    String observacion;

    public Asistencia(int id_personal, DateTime fecha_entrada, DateTime fecha_Salida, string estado, double hora, string observacion)
    {
        this.id_personal = id_personal;
        this.fecha_entrada = fecha_entrada;
        this.fecha_Salida = fecha_Salida;
        this.estado = estado;
        this.hora = hora;
        this.observacion = observacion;
    }

    public int getIdPersonal() { return id_personal; }
    public void setIdPersonal(int id_Personal) { this.id_personal = id_Personal; }

    public DateTime getFechaEntrada() { return fecha_entrada; }
    public void setFecha_entrada(DateTime fecha_entrada) { this.fecha_entrada = fecha_entrada; }

    public DateTime getFechaSalida() { return fecha_Salida; }
    public void setFechaSalida(DateTime fecha_salida) { this.fecha_Salida = fecha_salida; }

    public String getEstado() { return estado; }
    public void setEstado(String estado) { this.estado = estado; }

    public double getHora() { return hora; }
    public void setHora(double hora) { this.hora = hora; }

    public String getObservacion() { return observacion; }
    public void setObservacion(String observacion) { this.observacion = observacion; }
}

