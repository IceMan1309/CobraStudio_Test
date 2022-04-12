using System;
using System.Collections.Generic;
using System.Text;

namespace LEntidad
{
    public class LEmpleado
    {
        private string _Accion;
        private int _IdEmpleado;
        private string _NombreCompleto;
        private string _Cedula;
        private string _Correo;
        private DateTime _FechaNacimiento;
        private DateTime _FechaIngreso;
        private int? _IdJefe;
        private int _IdArea;
        private byte[] _Foto;

        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string NombreCompleto { get => _NombreCompleto; set => _NombreCompleto = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public DateTime FechaIngreso { get => _FechaIngreso; set => _FechaIngreso = value; }
        public int IdJefe { get => (int)_IdJefe; set => _IdJefe = value; }
        public int IdArea { get => _IdArea; set => _IdArea = value; }
        public byte[] Foto { get => _Foto; set => _Foto = value; }
        public string Accion { get => _Accion; set => _Accion = value; }
    }
}
