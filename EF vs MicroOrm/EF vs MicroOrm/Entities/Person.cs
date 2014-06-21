using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataObjects.Attributes;

namespace MyOrmLib
{
    [Serializable]
    [TableOrmSave(Name = "PersonTable")]
    public class Person
    {

        [FieldOrmSave(Name = "NameField", type = typeof(string))]
        public string Name { get; set; }
        [Key]
        [IdFieldOrmSave(Name = "Person_id", type = typeof(int))]
        public int INN { get; set; }

        [FieldOrmSave (Name = "ArticleField", type = typeof(Article))]
        public Article[] articles = new Article[3];

        public Person() { }
        
        public Person(string name,int INN)
        {
           this.INN = INN;
           this.Name = name;         
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Person p  = (Person)obj;
            Type t = this.GetType();

            var fields = from f in t.GetFields()
                         select f;

            bool equals = true;
            foreach (var field in fields)
            {
                if (field.GetValue(this).Equals(field.GetValue(p)))
                {
                    equals = false;
                }

            }
            return equals;
        }

       

        public override string ToString()
        {
            return "INN = " + INN + ", Name = " + Name;
        }
    }
}


