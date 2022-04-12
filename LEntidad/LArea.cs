using System;
using System.Collections.Generic;
using System.Text;

namespace LEntidad
{
    public class LArea
    {
        private string _Accion;
      private int  _IdArea;
       private string _Nombre;
        private string _Descripcion;

        public int IdArea { get => _IdArea; set => _IdArea = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Accion { get => _Accion; set => _Accion = value; }
    }
}
