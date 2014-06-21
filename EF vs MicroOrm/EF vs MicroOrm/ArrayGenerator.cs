using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrmLib;

namespace EF_vs_MicroOrm
{
    class ArrayGenerator
    {
        readonly int articlesSize ;
        private readonly Random _rng = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        public ArrayGenerator(int articlesSize)
        {
            this.articlesSize = articlesSize;
        }

        public Person[] CreateTestPersons(int size)
        {

            Person[] testPersons = new Person[size];
            for (int i = 0; i < size; i++)
            {
                testPersons[i] = GetRandomPerson();
            }
            return testPersons;
        }

        private Person GetRandomPerson()
        {
            Person result = new Person(RandomString(5), _rng.Next());
            result.articles = GetArticlesArray();
            return result;
        }

        private Article[] GetArticlesArray()
        {
            Article[] articles = new Article[articlesSize];
            for (int i = 0; i < articlesSize; i++)
            {
                articles[i] = new Article(RandomString(5), _rng.Next());
            }
            return articles;
        }

        private string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}
