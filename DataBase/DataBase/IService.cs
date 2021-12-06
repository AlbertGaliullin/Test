using System.ServiceModel;

namespace DataBase
{
    [ServiceContract(CallbackContract =typeof(IServiseBack))]
    public interface IService
    {
        [OperationContract]
        void RetDoc();
       
    }
    public interface IServiseBack
    {
        [OperationContract(IsOneWay = true)]
        void InfRet(string text);
    }
}
