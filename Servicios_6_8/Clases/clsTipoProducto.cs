using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsTipoProducto
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public TIpoPRoducto TipoProducto { get; set; }
        public List<TIpoPRoducto> ConsultarTodos()
        {
            return dbSuper.TIpoPRoductoes.ToList();
        }
        public string Insertar()
        {
            try
            {
                dbSuper.TIpoPRoductoes.Add(TipoProducto);
                dbSuper.SaveChanges();
                return "Tipo de producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public PRODucto Consultar(int Codigo)
        {
            return dbSuper.PRODuctoes.Where(x => x.Codigo == Codigo).FirstOrDefault();
        }
        public string Actualizar()
        {
            try
            {
                TIpoPRoducto tipoProducto = dbSuper.TIpoPRoductoes.Where(x => x.Codigo == TipoProducto.Codigo).FirstOrDefault();
                tipoProducto.Nombre = TipoProducto.Nombre;
                tipoProducto.Activo = TipoProducto.Activo;
                dbSuper.SaveChanges();
                return "Tipo de producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}