using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using DataObjects.Attributes;

namespace MyOrmLib
{
    [Serializable]
    [TableOrmSave(Name = "ArticleTable")]
    public class Article 
    {
        [FieldOrmSave(Name = "TitleField", type = typeof(string))]
        public string Title{ get; set; }
        [Key]
        [IdFieldOrmSave(Name = "Article_id", type = typeof(int))]
        public int ArticleCode { get; set; }


        public Article()
        {
        }

        public Article(string title, int articleCode)
        {
            Title = title;
            ArticleCode = articleCode;
        }

        public override string ToString()
        {
            return string.Format("Code = {0}, Title= {1}, Value = {2}", ArticleCode, Title);
        }
    }
}
