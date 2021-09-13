using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EntidadFederativa
    {
        public static ML.Result GetAll()
        {

            ML.Result result= new ML.Result();
              try
            {

                using(DL.MGarciaLeenkenGroupEntities context= new DL.MGarciaLeenkenGroupEntities()){

                    var query= context.CatEntidadFederativaGetAll().ToList();


                    if(query!=null){

                        result.Objects= new List<object>();

                        foreach(var objeto in query){
                           ML.EntidadFederativa entidadFederativa= new ML.EntidadFederativa();            
          
                            entidadFederativa.Id=objeto.Id;
                            entidadFederativa.Estado=objeto.Estado;

                            result.Objects.Add(entidadFederativa);

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

    }
}
