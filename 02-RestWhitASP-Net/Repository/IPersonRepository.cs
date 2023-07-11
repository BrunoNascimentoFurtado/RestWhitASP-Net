using RestWhitASP_Net.Model;
using System.Collections.Generic;

namespace RestWhitASP_Net.Business
{
    public interface IPersonservice
    {
        Person Create (Person person);
        Person FindByID (int id);
        List<Person> FindAll ();
        Person update (Person person);
        void Delete (int id);
    }
}
