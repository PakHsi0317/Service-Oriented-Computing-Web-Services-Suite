using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace project2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string WordCount1(Stream fileStream);//interface to pass WordCount service
        [OperationContract]
        string Number2Words(string number);//interface to pass make easy-words service
        //don't consider this service
        [OperationContract]
        string[] getWsdlAddress(string url);
        [OperationContract]
        string[] GetWsOperations(string url);
    }

}
