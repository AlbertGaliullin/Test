using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataBase
{
   public class Service : IService
    {
        public void RetDoc()
        {
            OperationContext operationContext = OperationContext.Current;
            string text, meaning = "";
            using (StreamReader sRead = new StreamReader(@"1.txt"))
            {
                while ((text = sRead.ReadLine()) != null)
                {
                    meaning += text + ";";
                }
            }


            operationContext.GetCallbackChannel<IServiseBack>().InfRet(meaning);

        }
    }
}
