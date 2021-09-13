using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.EmpleadoAdd(empleado.NumeroNomina,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.EntidadFederativa.Id);

                    if(query>0){
                    result.Correct=true;

                    }
                    else{
                        result.Correct=false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
            
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.EmpleadoUpdate(empleado.Id,empleado.NumeroNomina,empleado.Nombre,empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.EntidadFederativa.Id);

                    if(query>0){
                    result.Correct=true;

                    }
                    else{
                        result.Correct=false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
            
        }
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.EmpleadoDelete(IdEmpleado);

                    if(query>0){
                    result.Correct=true;

                    }
                    else{
                        result.Correct=false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
            
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.EmpleadoGetAll().ToList();


                    if(query!=null){

                        result.Objects= new List<object>();

                        foreach(var objeto in query){
                            ML.Empleado empleado =new ML.Empleado();

                            empleado.Id=objeto.Id;
                            empleado.NumeroNomina=objeto.NumeroNomina;
                            empleado.Nombre= objeto.Nombre;
                            empleado.ApellidoPaterno=objeto.ApellidoPaterno;
                            empleado.ApellidoMaterno=objeto.ApellidoMaterno;
                            empleado.EntidadFederativa= new ML.EntidadFederativa();
                            empleado.EntidadFederativa.Id=objeto.IdEstado.Value;

                            result.Objects.Add(empleado);
                        }
                    result.Correct=true;

                    }
                    else{
                        result.Correct=false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
            
        }
         public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.EmpleadoGetById(IdEmpleado).FirstOrDefault();


                    if(query!=null){
                   
                            ML.Empleado empleado =new ML.Empleado();

                     
                            empleado.NumeroNomina=query.NumeroNomina;
                            empleado.Nombre= query.Nombre;
                            empleado.ApellidoPaterno=query.ApellidoPaterno;
                            empleado.ApellidoMaterno=query.ApellidoMaterno;
                            empleado.EntidadFederativa= new ML.EntidadFederativa();
                            empleado.EntidadFederativa.Id=query.IdEstado.Value;
                            
                        result.Object=empleado;

                        
                    result.Correct=true;

                    }
                    else{
                        result.Correct=false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
            
        }

        
    }
}
