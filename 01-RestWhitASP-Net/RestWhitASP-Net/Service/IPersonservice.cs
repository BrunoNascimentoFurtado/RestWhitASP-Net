using RestWhitASP_Net.Model;
using System.Collections.Generic;

namespace RestWhitASP_Net.Service
{
    public interface IPersonservice
    {
        Person Create (Person person);
        Person FindByID (long id);
        List<Person> FindAll ();
        Person update (Person person);
        void Delete (long id);
    }
}
