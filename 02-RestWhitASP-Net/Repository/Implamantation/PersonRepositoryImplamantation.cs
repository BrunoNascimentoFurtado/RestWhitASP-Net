using Microsoft.EntityFrameworkCore;
using RestWhitASP_Net.Model;
using RestWhitASP_Net.Model.Context;
using System;

namespace RestWhitASP_Net.Repository.Implamantation
{
    public class PersonRepositoryImplamantation : IPersonRepository
    {
        private volatile int count;
        private MySqlContex _context;

        //private readonly  IPersonRepository _repository;  // duvida

        public PersonRepositoryImplamantation(MySqlContex contex)
        {
            _context = contex;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception )
            {

                throw ;
            }


            return person;
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();

        }

        public Person FindByID(int id)
        {
            var response = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
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
            var result = _context.Persons.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges(); // commit
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
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));         // select * from person where id = 1 limit 1
            //var result =  _repository.Persons.Where(x => x.Id == person.Id).FirstOrDefault();    // select * from person where id = 1
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }

        public bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
