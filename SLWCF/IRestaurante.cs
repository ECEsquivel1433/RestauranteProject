using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestaurante" in both code and config file together.
    [ServiceContract]
    public interface IRestaurante
    {
        [OperationContract]
        SLWCF.Result Add(ML.Restaurante restaurante);
        [OperationContract]
        SLWCF.Result Update(ML.Restaurante restaurante);
        [OperationContract]
        SLWCF.Result Delete();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Restaurante))]
        SLWCF.Result GetAll();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Restaurante))]
        SLWCF.Result GetByID();

            
    }
}
