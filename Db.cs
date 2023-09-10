using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace Monitoring
{
    class Db
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;

        public DataTable getHelpRecords()
        {
            con = new MySqlConnection("server=sg2nlmysql35plsk.secureserver.net;port=3306;database=samplemydb;user id=usrsamplemydb;pwd=c99&4pXk");
            con.Open();
            string sql = "select users.name , users.mobile , locations.latitude , locations.longitude , locations.created_at , locations.id from users,locations where users.id = locations.user_id and status = 'N'";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            con.Close();
            return buffer;
        }

        public void Update(string id)
        {
            con = new MySqlConnection("server=sg2nlmysql35plsk.secureserver.net;port=3306;database=samplemydb;user id=usrsamplemydb;pwd=c99&4pXk");
            con.Open();
            string sql = "update locations set status = 'Y' where id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable getAllHelpRecords()
        {
            con = new MySqlConnection("server=sg2nlmysql35plsk.secureserver.net;port=3306;database=samplemydb;user id=usrsamplemydb;pwd=c99&4pXk");
            con.Open();
            string sql = "select * from locations";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            con.Close();
            return buffer;
        }

    }
}
