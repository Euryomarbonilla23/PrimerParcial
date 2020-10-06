using System;
using System.Linq;
using System.Linq.Expressions;
using PrimerParcial.DAL;
using System.Collections.Generic;
using PrimerParcial.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.BLL
{
    public class CiudadesBLL
    {
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
              
                var Ciudad = contexto.Ciudades.Find(id);
                if (Ciudad != null)
                {
                    contexto.Ciudades.Remove(Ciudad);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Ciudades Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Ciudades Ciudad;

            try
            {
                Ciudad = contexto.Ciudades.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Ciudad;


        }
        public static bool Guardar(Ciudades Ciudad)
        {
            if (!Existe(Ciudad.CiudadId))
                return Insertar(Ciudad);
            else
                return Modificar(Ciudad);
        }
        public static bool Modificar(Ciudades Ciudad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Ciudad).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Ciudades Ciudad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
              
                contexto.Ciudades.Add(Ciudad);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


       
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Ciudades
                .Any(e => e.CiudadId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; 
        }
    }
}