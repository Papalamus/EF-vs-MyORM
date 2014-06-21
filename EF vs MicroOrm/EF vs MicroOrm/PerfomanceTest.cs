using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyOrmLib;
using MyOrmLib.Interfaces;
using MyOrmLib.MyOrm;
using NUnit.Framework;

namespace EF_vs_MicroOrm
{
    [TestFixture]
    class PerfomanceTest
    {
        private MyOrmBase context;
        private LibrayContext _eContext;
        private IEntityConnecter<Person> _connecter;

        const int personSize = 100;
        const int articlesSize = 5;
        const int count = 100;

        [SetUp]
        public void SetUp()
        {
           
         
            //Set Up  MyOrm 
            context = MyOrmBase.GetInstance(false);
            _connecter = context.GetConnecter<Person>();
            
            //Set up EF
            _eContext = new LibrayContext();

            ArrayGenerator ag = new ArrayGenerator(articlesSize);
            Person[] testValues = ag.CreateTestPersons(personSize);

            for (int i = 0; i < testValues.Length; i++)
            {
                _connecter.Insert(testValues[i]);
            }
            _eContext.Persons.AddRange(testValues);
            _eContext.SaveChanges();
        }

        [Test]
        public void MyORM_SimpleSelect()
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
         
            for (int i = 0; i < count; i++)
            {
                _connecter.GetAll();
            }
            stopWatch.Stop();
            TimeSpan myOrmTime = stopWatch.Elapsed;
            
            Console.WriteLine(" MyORM - "+ myOrmTime);
        }

        [Test]
        public void EF_SimpleSelect()
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < count; i++)
            {
                var persons = _eContext.Persons.ToList();
                foreach (var person in persons)
                {
                    persons.ToList();
                }
            }
            stopWatch.Stop();
            TimeSpan EfTime = stopWatch.Elapsed;
            Console.WriteLine(" EF - " + EfTime);
        }
        
        
        [Test]
        public void EF_SelectWithRelated()
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < count; i++)
            {
                var persons = _eContext.Persons.ToList();
                foreach (var person in persons)
                {
                    person.articles.ToList();
                }
            }
            stopWatch.Stop();
            TimeSpan EfTime = stopWatch.Elapsed;


            Console.WriteLine(" EF select related- " + EfTime);
        }

        [Test]
        public void MyORM_SelectWithRelated()
        {
            context.LoadRelated = true;
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            for (int i = 0; i < count; i++)
            {
                _connecter.GetAll();
            }
            stopWatch.Stop();
            TimeSpan myOrmTime = stopWatch.Elapsed;

            Console.WriteLine(" MyORM select related - " + myOrmTime);
        }


        [TearDown]
        public void TearDown()
        {
        
        }
    }
}
