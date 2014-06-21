using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrmLib;
using MyOrmLib.Interfaces;
using MyOrmLib.MyOrm;

namespace EF_vs_MicroOrm
{
    public class Class1
    {
        static void Main(string[] args)
        {
            ////MyOrmBase context = MyOrmBase.GetInstance();
            ////IEntityConnecter<Person> pc = context.GetConnecter<Person>();
            //ArrayGenerator generator = new ArrayGenerator();
            //Person[] arr = generator.CreateTestPersons(1);
            ////pc.Insert(arr[0]);
            ////var tmp = pc.GetAll();
            ////foreach (var person in tmp)
            ////{
            ////    Console.WriteLine(person);
            ////}
            ////Console.ReadKey();


            //LibrayContext eContext = new LibrayContext();
            //eContext.Persons.Add(arr[0]);
            //eContext.SaveChanges();
            //foreach (var person in eContext.Persons)
            //{
            //    Console.WriteLine(person);
            //}

            //Console.ReadKey();
        }
    }
}
