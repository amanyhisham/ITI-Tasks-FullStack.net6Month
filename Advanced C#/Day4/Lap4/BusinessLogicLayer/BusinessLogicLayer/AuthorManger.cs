using BusinessLogicLayer.Model;
using DataAcessLier;
using System.Data;
using System.Data.Common;

namespace BusinessLogicLayer
{
    //محتاجه اكلم دتا بيز عن طريق دتا اكسس لير
    public class AuthorManger
    {//عشان اكلم دتا بيز مانجر
        DBManger DBManger;
        private object row;

        public AuthorManger()
        {
            DBManger = new DBManger();
        }
        public int addAuthor(Author author)
        {
            int rowsaffected = DBManger.ExcuteNonQuery($"insert into authors (au_id,au_fName,au_lName, Zip,State,City,Address,Phone,Contract) values ({author.Id},'{author.fName}','{author.lName}','{author.Zip}','{author.State}','{author.City}','{author.address}','{author.Phone}',{author.Contract})");
            return rowsaffected;

        }
        public int deletAuthor(int id)
        {
            int rowsaffected = DBManger.ExcuteNonQuery($"delete from authors where au_id={id}");
            return rowsaffected;

        }

        public int deletAuthor(string? id)
        {
            throw new NotImplementedException();
        }

        public List<Author> getAllAuthor()
        {
            DataTable allAuthors = DBManger.SelectAll("select * from authors");//dt
            return ConvertDataTableToList(allAuthors);//display all authors in list form




        }
        private Author ConvertDataRowToAuthor(DataRow row)//dt
        {
            Author author = new Author();
            author.Id =  row["au_id"].ToString();
            author.fName = row["au_fname"].ToString();
            author.lName = row["au_lname"].ToString();
            author.Zip = row["zip"].ToString();
            author.State = row["state"].ToString();
            author.City = row["city"].ToString();
            author.address = row["address"].ToString();
            author.Phone = row["phone"].ToString();
            author.Contract =  row["contract"].ToString();
            return author;
        }
        private List<Author> ConvertDataTableToList(DataTable dt)
        {
            List<Author> authors = new List<Author>();
            foreach (DataRow row in dt.Rows)
            {
                Author author = ConvertDataRowToAuthor(row);
                authors.Add(author);
            }
            return authors;
        }

    }
}
