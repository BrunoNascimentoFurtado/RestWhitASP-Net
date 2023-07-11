using RestWhitASP_Net.Model;
using RestWhitASP_Net.Model.Context;

namespace RestWhitASP_Net.Service.Implamantation
{
    public class PersonServiceImplamantation : IPersonservice
    {
        private volatile int count;
        private MySqlContex _context;


        public  PersonServiceImplamantation(MySqlContex contex)
        {
            _context = contex;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++) 
            {
                Person person = MockPerson(i);
                persons.Add(person);
                
            }
            return persons;
               
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncremetandGet(),
                nome = "rafael" + i,
                logradouro = "V. Velha ES - Brasil" + i
            };
        }

        private int IncremetandGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncremetandGet(),
                nome = "Bruno",
                logradouro = "Vitória Es - Brasil"
            };
        }

        public Person update(Person person)
        {
            return person;
        }
    }
}
