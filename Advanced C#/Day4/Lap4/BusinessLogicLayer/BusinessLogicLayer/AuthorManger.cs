using BusinessLogicLayer.Model;
using DataAcessLier;
using System.Data;

namespace BusinessLogicLayer
{
    public class AuthorManger
    {
        DBManger DBManger;

        public AuthorManger()
        {
            DBManger = new DBManger();
        }

        // 🔹 Add Author
        public int addAuthor(Author author)
        {
            string sql = $"insert into authors " +
   $"(au_id,au_fname,au_lname, zip,state,city,address,phone,contract) " +
   $"values ('{author.Id}','{author.fName}','{author.lName}','{author.Zip}','{author.State}','{author.City}','{author.address}','{author.Phone}',{(author.Contract ? 1 : 0)})";
            return DBManger.ExcuteNonQuery(sql);//row insert 
        }

        // 🔹 Delete Author
        public int deletAuthor(string id)
        {
            // 1️⃣ امسح من الجدول التاني الأول
            DBManger.ExcuteNonQuery($"delete from titleauthor where au_id = '{id}'");

            // 2️⃣ بعد كده امسح من authors
            return DBManger.ExcuteNonQuery($"delete from authors where au_id = '{id}'");//row delet
        }

        // 🔹 Get All Authors
        public List<Author> getAllAuthor()
        {
            DataTable dt = DBManger.SelectAll("select * from authors");
            return ConvertDataTableToList(dt);
        }

        // 🔹 Convert Row → Object
        private Author ConvertDataRowToAuthor(DataRow row)
        {
            return new Author
            {
                Id = row["au_id"].ToString(),
                fName = row["au_fname"].ToString(),
                lName = row["au_lname"].ToString(),
                Zip = row["zip"].ToString(),
                State = row["state"].ToString(),
                City = row["city"].ToString(),
                address = row["address"].ToString(),
                Phone = row["phone"].ToString(),
                Contract = Convert.ToBoolean(row["contract"])
            };
        }

        // 🔹 Convert Table → List
        private List<Author> ConvertDataTableToList(DataTable dt)
        {
            List<Author> authors = new List<Author>();

            foreach (DataRow row in dt.Rows)
            {
                authors.Add(ConvertDataRowToAuthor(row));
            }

            return authors;
        }
    }
}