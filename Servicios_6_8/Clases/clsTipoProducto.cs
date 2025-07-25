﻿using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public TIpoPRoducto Consultar(int Codigo)
        {
            return dbSuper.TIpoPRoductoes.Where(x => x.Codigo == Codigo).FirstOrDefault();
        }
        public string Actualizar()
        {
            try
            {
                TIpoPRoducto tipoProducto = Consultar(TipoProducto.Codigo);
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
        public List<TIpoPRoducto> LlenarCombo()
        {
            return dbSuper.TIpoPRoductoes
                .Where(t => t.Activo == true)
                .OrderBy(t => t.Nombre)
                .ToList();
        }
        public IQueryable LlenarComboTipo()
        {
            return from T in dbSuper.Set<TIpoPRoducto>()
                   where T.Activo == true
                   orderby T.Nombre
                   select new
                   {
                       Codigo = T.Codigo,
                       Nombre = T.Nombre
                   };
        }
    }
}