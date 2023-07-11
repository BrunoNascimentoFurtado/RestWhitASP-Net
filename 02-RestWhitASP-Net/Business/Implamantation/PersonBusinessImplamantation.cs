using Microsoft.EntityFrameworkCore;
using RestWhitASP_Net.Model;
using RestWhitASP_Net.Model.Context;
using RestWhitASP_Net.Repository;
using System;

namespace RestWhitASP_Net.Business.Implamantation
{
    public class PersonBusinessImplamantation : IpersonBusiness
    {
        private volatile int count;
        private MySqlContex _repository;

       private readonly IPersonRepository _repository;  // duvida

        public  PersonBusinessImplamantation(MySqlContex repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            try
            {
                _repository.Add(person);
                _repository.SaveChanges();
            }
            catch (Exception )
            {

                throw ;
            }


            return person;
        }

        public List<Person> FindAll()
        {

            return _repository.Persons.ToList();

        }

        public Person FindByID(int id)
        {
            var response = _repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
            return response;
            /*
            return _repository.Persons
                .Include(x => x.OutraClasse.Where(x => x.Ativo == true))
                .Where(x => x.Id == id && x.cidade == "").FirstOrDefault();
            */
        }

        public void Delete(int id)
        {
            //var result =  _repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
            var result = _repository.Persons.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    _repository.Persons.Remove(result);
                    _repository.SaveChanges(); // commit
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // context.Person.Where(x => x.id == person.Id).FirstOrDefault();

        public Person update(Person person)
        {

            if (!Exists(person.Id)) return new Person();
            var result = _repository.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));         // select * from person where id = 1 limit 1
            //var result =  _repository.Persons.Where(x => x.Id == person.Id).FirstOrDefault();    // select * from person where id = 1
            if (result != null)
            {
                try
                {
                    _repository.Entry(result).CurrentValues.SetValues(person);
                    _repository.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }

        private bool Exists(int id)
        {
            return _repository.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
