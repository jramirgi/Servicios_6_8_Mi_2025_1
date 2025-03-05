using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsEmpleado
    {
        private DBSuperEntities dbSuper = new DBSuperEntities(); //Objeto de la base de datos. Permite manipular el CRUD de los objetos generados por el Entity Framework
        public EMPLeado empleado { get; set; } //Permite manipular o acceder a los atributos de la tabla EMPLEADO
        public string Insertar()
        {
            try
            {
                dbSuper.EMPLeadoes.Add(empleado); //Agrega un nuevo empleado a la tabla EMPLEADO (INSERT INTO)
                dbSuper.SaveChanges(); //Guarda los cambios en la base de datos
                return "Empleado insertado correctamente"; //Mensaje de confirmación
            }
            catch (Exception ex)
            {
                return "Error al insertar el empleado: " + ex.Message; //Mensaje de error
            }
        }
        public string Actualizar()
        {
            //Para asegurar que realmente se esté actualizando un dato de un empleado, se debe consultar el empleado por su documento
            EMPLeado emp = Consultar(empleado.Documento); //Consulta un empleado por su documento
            if (emp == null)
            {
                //El empleado no existe, se debe insertar o el documento no es válido
                return "El documento del empleado no es válido";
            }
            dbSuper.EMPLeadoes.AddOrUpdate(empleado); //Actualiza un empleado en la tabla EMPLEADO (UPDATE)
            dbSuper.SaveChanges(); //Guarda los cambios en la base de datos
            return "Se actualizó el empleado correctamente"; //Mensaje de confirmación
        }
        public EMPLeado Consultar(string Documento)
        {
            //Expresiones lambda: Variables que se adaptan a la consulta que se desea realizar. Se convierten en objetos del tipo que se está manipulando
            //FirstOrDefault: Devuelve el primer elemento que cumpla con la condición de la expresión lambda
            EMPLeado emp = dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == Documento); //Consulta un empleado por su documento
            return  emp; //Devuelve el empleado consultado
        }
        public List<EMPLeado> ConsultarTodos()
        {
            return dbSuper.EMPLeadoes
                .OrderBy(e => e.PrimerApellido) //Ordena los empleados por su primer apellido
                .ToList(); //Consulta todos los empleados
        }
        public string Eliminar()
        {
            try
            {
                //Se debe consultar el empleado
                EMPLeado emp = Consultar(empleado.Documento); //Consulta un empleado por su documento
                if (emp == null)
                {
                    //El empleado no existe, se debe insertar o el documento no es válido
                    return "El documento del empleado no es válido";
                }
                dbSuper.EMPLeadoes.Remove(emp); //Elimina un empleado en la tabla EMPLEADO (DELETE)
                dbSuper.SaveChanges(); //Guarda los cambios en la base de datos
                return "Se eliminó el empleado correctamente"; //Mensaje de confirmación
            }
            catch(Exception ex)
            {
                return ex.Message; //Mensaje de error
            }
        }
        public string EliminarXDocumento(string Documento)
        {
            try
            {
                //Se debe consultar el empleado
                EMPLeado emp = Consultar(Documento); //Consulta un empleado por su documento
                if (emp == null)
                {
                    //El empleado no existe, se debe insertar o el documento no es válido
                    return "El documento del empleado no es válido";
                }
                dbSuper.EMPLeadoes.Remove(emp); //Elimina un empleado en la tabla EMPLEADO (DELETE)
                dbSuper.SaveChanges(); //Guarda los cambios en la base de datos
                return "Se eliminó el empleado correctamente"; //Mensaje de confirmación
            }
            catch (Exception ex)
            {
                return ex.Message; //Mensaje de error
            }
        }
    }
}