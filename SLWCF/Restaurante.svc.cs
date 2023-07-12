//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Text;

//namespace SLWCF
//{
//     NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Restaurante" in code, svc and config file together.
//     NOTE: In order to launch WCF Test Client for testing this service, please select Restaurante.svc or Restaurante.svc.cs at the Solution Explorer and start debugging.
//    public class Restaurante : IRestaurante
//    {
//        public SLWCF.Result Add(ML.Restaurante restaurante)
//        {
//            ML.Result result = new ML.Result();
//            result = BL.Restaurante.Add(restaurante);
//            return new SLWCF.Result
//            {
//                Correct = result.Correct,
//                ErrorMessage = result.ErrorMessage,
//                Object = result.Object,
//                Objects = result.Objects,
//            };
//        }

//        public SLWCF.Result Update(ML.Restaurante restaurante)
//        {
//            ML.Result result = new ML.Result();
//            result = BL.Restaurante.Update(restaurante);
//            return new SLWCF.Result
//            {
//                Correct = result.Correct,
//                ErrorMessage = result.ErrorMessage,
//                Object = result.Object,
//                Objects = result.Objects,
//            };
//        }

//        public SLWCF.Result Delete(ML.Restarurante restaurante)
//        {
//            ML.Result result = new ML.Result();
//            result = BL.Restaurante.Delete(restaurante);

//            return new SLWCF.Result
//            {
//                Correct = result.Correct,
//                ErrorMessage = result.ErrorMessage,
//                Object = result.Object,
//                Objects = result.Objects,
//            };
//        }
//        public SLWCF.Result GetAll()
//        {
//            ML.Result result = new ML.Result();
//            result = BL.Restaurante GetAll();

//            return new SLWCF.Result
//            {
//                Correct = result.Correct,
//                ErrorMessage = result.ErrorMessage,
//                Object = result.Object,
//                Objects = result.Objects,
//            };
//        }
//        public SLWCF.Result GetById(int IdAlumno)
//        {
//            ML.Result result = new ML.Result();
//            result = BL.Restaurante.GetById(IdAlumno);
//            return new SLWCF.Result
//            {
//                Correct = result.Correct,
//                ErrorMessage = result.ErrorMessage,
//                Object = result.Object,
//                Objects = result.Objects,
//            };
//        }
//    }
//}
