using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace PrepodsTest
{
    /// <summary>
    /// 
    ///connection: will be used to open a connection to the database.
    ///server: indicates where our server is hosted, in our case, it's localhost.
    ///database: is the name of the database we will use, in our case it's the database we already created earlier which is prepods2.
   /// uid: is our MySQL username.
   /// password: is our MySQL password.
   /// connectionString: contains the connection string to connect to the database, and will be assigned to the connection variable.

    /// </summary>
    class Connector
    {
		
       
    	private static string MySQLEscape(string str)
		{
		    return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
		        delegate(Match match)
		        {
		            string v = match.Value;
		            switch (v)
		            {
		                case "\x00":            // ASCII NUL (0x00) character
		                    return "\\0";   
		                case "\b":              // BACKSPACE character
		                    return "\\b";
		                case "\n":              // NEWLINE (linefeed) character
		                    return "\\n";
		                case "\r":              // CARRIAGE RETURN character
		                    return "\\r";
		                case "\t":              // TAB
		                    return "\\t";
		                case "\u001A":          // Ctrl-Z
		                    return "\\Z";
		                default:
		                    return "\\" + v;
		            }
		        });
		} 
		public void UpdateSpec(string id, string name, string course, string semester)
		{
			//date - yyyy-MM-dd
			//�������
			name = name.Replace("\"","");
			name = name.Replace("\'","");
			name = MySQLEscape(name);
			
            string query = "UPDATE specializations SET name='" + name + "', ";
            query = query + "course='" + course + "', semester='"+ semester+ "' ";
            query = query + " WHERE specializations.Id='"+id+"' ; ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
		}
        
		public void InsertSpec(string name, string course, string semester)
		{
			name = name.Replace("\"","");
			name = name.Replace("\'","");
			name = MySQLEscape(name);

            
            string query = "SET FOREIGN_KEY_CHECKS=0;  ";
            query=query+"INSERT INTO specializations (name, course, semester) VALUES";
            course = (course=="")?"0":course;
            semester = (semester=="")?"0":semester;

            query = query + " ('" + name + "', '" + course + "', '" + semester + "');";
            
            query=query+"	SET FOREIGN_KEY_CHECKS=1;";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
		}
        public void UpdateKlass(string id, string name, string People, string yearOfStudy)
        {
            //date - yyyy-MM-dd
            //�������
            name = name.Replace("\"", "");
            name = name.Replace("\'", "");
            name = MySQLEscape(name);

            string query = "UPDATE Klasses SET name='" + name + "', ";
            query = query + "People='" + People + "', yearOfStudy='" + yearOfStudy + "' ";
            query = query + " WHERE Klasses.Id='" + id + "' ; ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void InsertKlass(string name, string People, string yearOfStudy)
        {
            name = name.Replace("\"", "");
            name = name.Replace("\'", "");
            name = MySQLEscape(name);
            

            string query = "SET FOREIGN_KEY_CHECKS=0;  ";
            query = query + "INSERT INTO Klasses (name, People, yearOfStudy) VALUES";
            People = (People == "") ? "0" : People;


            query = query + " ('" + name + "', '" + People + "', '" + yearOfStudy + "');";

            query = query + "	SET FOREIGN_KEY_CHECKS=1;";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
		public void DeleteSpec(string id)
		{
			//DELETE FROM `prepods4`.`specializations` WHERE <{where_expression}>;
			string query = "DELETE FROM specializations WHERE specializations.Id='"+id+"' ; ";
			
			
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
		}
        public void DeleteKlass(string id)
        {
            //DELETE FROM `prepods4`.`specializations` WHERE <{where_expression}>;
            string query = "DELETE FROM Klasses WHERE Klasses.Id='" + id + "' ; ";


            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void DeletePrepod(string id)
        {
            //DELETE FROM `prepods4`.`specializations` WHERE <{where_expression}>;
            string query = "DELETE FROM Prepods WHERE Prepods.Id='" + id + "' ; ";


            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        private MySqlConnection connection;
        private string MySqlServer;
        private string MySqlSchema;
        private string mySqlUser;
        private string mySqlPassword;
        private int port;
        private string MySqlServer1;
        private string MySqlSchema1;
        private string mySqlUser1;
        private string mySqlPassword1;
        private string port1;
        private string schema;
        
        //Constructor
        public Connector()
        {
            //Initialize();
        }
        public void InitializeCreateScheme()
        {
            // server = "193.124.59.51";
            //https://phpmyadmin:RedChiken1981@phpmyadmin.s05.cverg.ru
            //database = schema;
            //  uid = "admin1";
            //localhost 195.128.124.100  phpmyadmin.s05.cverg.ru
            //phpmyadmin  tupov-a
            //RedChicken1981  3Ln7ETvKMyb3na5X
            using (var sr = new System.IO.StreamReader("InfoServer.txt", Encoding.Default))
            {
                int i = 0;
                string line = null;
                while (i != 5)
                {

                    i = i + 1;
                    if (i == 1) { port1 = sr.ReadLine(); port1 = port1.Remove(0, 5); }
                    if (i == 2) { MySqlServer1 = sr.ReadLine(); MySqlServer1 = MySqlServer1.Remove(0, 12); }
                    if (i == 3) { mySqlPassword1 = sr.ReadLine(); mySqlPassword1 = mySqlPassword1.Remove(0, 14); }
                    if (i == 4) { mySqlUser1 = sr.ReadLine(); mySqlUser1 = mySqlUser1.Remove(0, 10); }
                    if (i == 5) { MySqlSchema1 = sr.ReadLine(); MySqlSchema1 = MySqlSchema1.Remove(0, 12); }

                }
            }
            port = Convert.ToInt32(port1);
            MySqlServer = MySqlServer1;
            mySqlPassword = mySqlPassword1;
            mySqlUser = mySqlUser1;
            MySqlSchema = MySqlSchema1;
            //mySqlUser = "tupov-a";
            //MySqlServer = "195.128.124.100";
            //mySqlUser = "yuri";
            //mySqlPassword = "3Ln7ETvKMyb3na5X";
            //mySqlPassword = "9769";
            //MySqlSchema = "tupov-a";

            string connectionString;
            connectionString = "SERVER=" + MySqlServer + ";PORT=" + port + ";" + 
             "UID=" + mySqlUser + ";" + "PASSWORD=" + mySqlPassword + ";";
            try
            {

                connection = new MySqlConnection(connectionString);
                bool ping = connection.Ping();

                var a = 5;


            }
            catch (System.Net.Sockets.SocketException e)
            {
                MessageBox.Show(string.Format("Socket connection error: {0}", e.Message));

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("General exception: {0}", e.Message));
            }

        }
        public void Initialize()
        {
            // server = "193.124.59.51";
            //https://phpmyadmin:RedChiken1981@phpmyadmin.s05.cverg.ru
            //database = schema;
            //  uid = "admin1";
            //localhost 195.128.124.100  phpmyadmin.s05.cverg.ru
            //phpmyadmin  tupov-a
            //RedChicken1981  3Ln7ETvKMyb3na5X
            using (var sr = new System.IO.StreamReader("InfoServer.txt", Encoding.Default))
            {
                int i=0;
                string line=null;
                while (i!=5)
                {
                    
                    i = i + 1;
                    if (i == 1) { port1 = sr.ReadLine(); port1 = port1.Remove(0, 5); }
                    if (i == 2) { MySqlServer1 = sr.ReadLine(); MySqlServer1 = MySqlServer1.Remove(0, 12); }
                    if (i == 3) { mySqlPassword1 = sr.ReadLine(); mySqlPassword1 = mySqlPassword1.Remove(0, 14); }
                    if (i == 4) { mySqlUser1 = sr.ReadLine(); mySqlUser1 = mySqlUser1.Remove(0, 10); }
                    if (i == 5) { MySqlSchema1 = sr.ReadLine(); MySqlSchema1 = MySqlSchema1.Remove(0, 12); }

                }
            }
                port = Convert.ToInt32(port1);
                MySqlServer = MySqlServer1;
                mySqlPassword = mySqlPassword1;
                mySqlUser = mySqlUser1;
                MySqlSchema = MySqlSchema1;
                //mySqlUser = "tupov-a";
                //MySqlServer = "195.128.124.100";
                //mySqlUser = "yuri";
                //mySqlPassword = "3Ln7ETvKMyb3na5X";
                //mySqlPassword = "9769";
                //MySqlSchema = "tupov-a";
                
                string connectionString;
                connectionString = "SERVER=" + MySqlServer + ";PORT=" + port + ";" + "DATABASE=" +
                MySqlSchema + ";" + "UID=" + mySqlUser + ";" + "PASSWORD=" + mySqlPassword + ";";
                try
                {

                    connection = new MySqlConnection(connectionString);
                    bool ping = connection.Ping();

                    var a = 5;


                }
                catch (System.Net.Sockets.SocketException e)
                {
                    MessageBox.Show(string.Format("Socket connection error: {0}", e.Message));

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("General exception: {0}", e.Message));
                }
           
            }
        
        //Count test
        public int CountTest(string tableName)
        {
            string query = "SELECT Count(*) FROM " + tableName;
            int Count = -1;
            //CheckConnection();
            //Open Connection
            //connection.Ping();
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }

            return Count;

        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator " + ex.Message);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again " + ex.Message);
                        break;
                    default: MessageBox.Show("Exception #"+ex.Number + ex.Message);
                       break;
                }
                return false;
            }
        }

        //Close connection and close SSH
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                //close SSH also!!
                //clientMain.Disconnect();
                //clientMain.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<GridPrepodsReplace> SelectPrepodsReplaceToGrid(string id = "")
        {
            string query = "SELECT * FROM Prepods";
            if (id != "")
            {
                query = query + " WHERE Prepods.id='" + id + "'";
            }
            //Create a list to store the result
            List<GridPrepodsReplace> toreturn = new List<GridPrepodsReplace>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    DateTime bday = (DateTime)dataReader["Birthday"];
                    GridPrepodsReplace curgrid = new GridPrepodsReplace(dataReader["id"].ToString(), dataReader["FioFull"].ToString(),
                                                      dataReader["FioShort"].ToString(),
                                                       dataReader["MobPhoneNumber"].ToString(),
                                                       bday);
                    toreturn.Add(curgrid);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }
        }

        public void CreateTable()  
        {
            string query = "CREATE schema prepods3;";
            query = query + "CREATE TABLE prepods3.`Prepods` (`id` bigint NOT NULL AUTO_INCREMENT,`FioFull` varchar(255) NOT NULL,`FioShort` varchar(255),`MobPhoneNumber` varchar(255) NOT NULL,`Birthday` DATE NOT NULL,`Adress` varchar(255),`Comment` TEXT(1000),PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`Specializations` (`id` bigint NOT NULL AUTO_INCREMENT,`name` varchar(255) NOT NULL,`course` tinyint,`semester` tinyint,`comment` varchar(255),PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`PrepodsSpec` (`id` bigint NOT NULL AUTO_INCREMENT,`idPrepod` bigint NOT NULL,`idSpec` bigint NOT NULL,PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`Otchet` (`id` bigint NOT NULL AUTO_INCREMENT,`idPrepod` bigint NOT NULL,`idRoom` bigint NOT NULL,`idSpec` bigint NOT NULL,`count` bigint NOT NULL,`idKlass` bigint NOT NULL,`isSubGroup` bool NOT NULL,`numSubGroup` bigint,`idReplacedPrepod` bigint NOT NULL,`DateReplace` DATE NOT NULL, PRIMARY KEY (`id`) );";
            query = query + "CREATE TABLE prepods3.`Rooms` (`id` bigint NOT NULL AUTO_INCREMENT,`capacity` bigint NOT NULL,`name` varchar(20) NOT NULL,`FullLocation` varchar(255),PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`Klasses` (`id` bigint NOT NULL AUTO_INCREMENT,`name` varchar(20) NOT NULL,`People` int NOT NULL,`yearOfStudy` varchar(4),PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`PrepodsKlasses` (`id` bigint NOT NULL AUTO_INCREMENT,`idPrepod` bigint NOT NULL,`idKlass` bigint NOT NULL,PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`ServerInfo` (`id` bigint NOT NULL AUTO_INCREMENT,`IPadress` bigint NOT NULL,`port` bigint NOT NULL, `MySQLlogin` bigint NOT NULL, `MySQLpass` bigint NOT NULL, `NameSchema` bigint NOT NULL, `SSHlog` bigint NOT NULL, `SSHpass` bigint NOT NULL, `InfoServer` bigint NOT NULL, PRIMARY KEY (`id`));";
            query = query + "CREATE TABLE prepods3.`Schedule` (`id` bigint NOT NULL AUTO_INCREMENT,`lessonNumber` int NOT NULL,`idSpec` bigint NOT NULL,`idKlass` bigint NOT NULL,`isSubGroup` bool NOT NULL,`numDayOfWeek` bigint NOT NULL,`nameDayOfWeek` varchar(50),`idPrepod` bigint NOT NULL,`idRoom` bigint NOT NULL,`numSubGroup` bigint,`isEven` bool ,`isPair` bool ,`TimeBegin` TIME,`TimeEnd` TIME,PRIMARY KEY (`id`));";
             if (this.OpenConnection() == true)
             {
                 MySqlCommand sqlCom = new MySqlCommand(query, connection);
                 sqlCom.ExecuteNonQuery();

                 schema = "prepods3";
             }
        }

        //Insert statement
        public void Insert()
        {
            //date - yyyy-MM-dd
            Random rnd = new Random();
            int r = rnd.Next(100000, 999999);
            string query = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO Prepods (FioFull, FioShort, MobPhoneNumber, Birthday) VALUES ('������ ���"+r.ToString()+"', '��', '+79841112233', '1988-11-29');SET FOREIGN_KEY_CHECKS=1;";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Insert statement
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="fioshort"></param>
        /// <param name="mobno"></param>
        /// <param name="bday">yyyy-MM-dd</param>
        public void InsertPrepod(string fio,string fioshort, string mobno,string bday)
        {
           

            string query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO Prepods (FioFull, FioShort, MobPhoneNumber, Birthday) VALUES";
            query=query+" ('" + fio + "', '" + fioshort + "', '" + mobno + "', '" + bday + "'); SET FOREIGN_KEY_CHECKS=1;";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void InsertInfoServer(string ip, string port, string mysqllog, string mysqlpass, string nameschema, string sshlog, string sshpass, string TypeServer)
        {

            string query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO ServerInfo (IPadress, port, MySQLlog, MySQLpass, schema) VALUES";
            query = query + " ('" + "195.128.124.100" + "', '" + "3306" + "', '" + "tupov-a" + "', '" + "3Ln7ETvKMyb3na5X" + "', '" + "tupov-a" + "'', '" + TypeServer + "'); SET FOREIGN_KEY_CHECKS=1;";

            if (TypeServer == "1")
            {
                 query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO ServerInfo (IPadress, port, MySQLlog, MySQLpass, schema) VALUES";
                query = query + " ('" + "195.128.124.100" + "', '" + "3306" + "', '" + "tupov-a" + "', '" + "3Ln7ETvKMyb3na5X" + "', '" + "tupov-a" + "'', '" + "1" + "'); SET FOREIGN_KEY_CHECKS=1;";
            }
            if (TypeServer == "2")
            {
                 query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO ServerInfo (IPadress, port, MySQLlog, MySQLpass, schema) VALUES";
                query = query + " ('" + ip + "', '" + port + "', '" + mysqllog + "', '" + mysqlpass + "', '" + nameschema + "'', '" + TypeServer + "'); SET FOREIGN_KEY_CHECKS=1;";
            }
            if (TypeServer == "3")
            {
                 query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO ServerInfo (IPadress, port, MySQLlog, MySQLpass, schema) VALUES";
                query = query + " ('" + ip + "', '" + port + "', '" + mysqllog + "', '" + mysqlpass + "', '" + nameschema + "', '" + sshlog + "', '" + sshpass + "', '" + TypeServer + "'); SET FOREIGN_KEY_CHECKS=1;";
            }

            

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void InsertRoom(string name, string capacity, string fulllocation)
        {
            //date - yyyy-MM-dd

            string query = "SET FOREIGN_KEY_CHECKS=0;  INSERT INTO Rooms (capacity, name, FullLocation) VALUES";
            query = query + " ('" + capacity + "', '" + name + "', '" + fulllocation + "'); SET FOREIGN_KEY_CHECKS=1;";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="fioshort"></param>
        /// <param name="mobno"></param>
        /// <param name="bday">yyyy-MM-dd</param>
        public void UpdatePrepod(string fio, string fioshort, string mobno, string bday, string id)
        {
            //date - yyyy-MM-dd

            string query = "UPDATE Prepods SET FioFull='" + fio + "', ";
            query = query + "FioShort='" + fioshort + "', MobPhoneNumber='" + mobno + "', ";
            query = query + " Birthday='" + bday + "' WHERE Prepods.Id='"+id+"' ; ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Update statement
        public void Update()
        {
            string query = "UPDATE Prepods SET MobPhoneNumber='112233', Snils='7778888' WHERE Snils='155444'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
        }
        public List<string> SelectIdSpecsForPrepod(string idPrepod)
        {
            List<string> IdSpecsForPrepod = new List<string>();
            string query = "SELECT idSpec FROM PrepodsSpec WHERE idPrepod='"+idPrepod+"'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    IdSpecsForPrepod.Add( dataReader["idSpec"].ToString() );
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return IdSpecsForPrepod;
            }

            return IdSpecsForPrepod;
        }
        public List<string> SelectIdKlassesForPrepod(string idPrepod)
        {
            List<string> IdKlassForPrepod = new List<string>();
            string query = "SELECT idKlass FROM prepodsklasses WHERE idPrepod='" + idPrepod + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    IdKlassForPrepod.Add(dataReader["idKlass"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return IdKlassForPrepod;
            }

            return IdKlassForPrepod;
        }
        public void DeletePrepodsSpecIfExist(string idPrepod, string idSpecNOTChecked)
        {
            //date - yyyy-MM-dd
            string query1 = "SELECT idSpec,idPrepod FROM PrepodsSpec WHERE idPrepod='" + idPrepod + "' AND idSpec='" + idSpecNOTChecked + "'";

            string queryDel = "DELETE FROM PrepodsSpec WHERE idPrepod='" + idPrepod + "' AND idSpec='" + idSpecNOTChecked + "'";

            deletequery(query1, queryDel);
        }
        private void deletequery(string query1, string queryDel)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd1.ExecuteReader();
                bool existRecord = dataReader.Read();
                if (existRecord == true)
                {
                    //close connection
                    this.CloseConnection();
                    this.OpenConnection();
                    //DELETE
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(queryDel, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();


                }
                //close connection
                this.CloseConnection();

            }
        }
        public void DeletePrepodsKlassIfExist(string idPrepod, string idKlassNotCkecked)
        {
            //date - yyyy-MM-dd
            string query1 = "SELECT idKlass,idPrepod FROM prepodsklasses WHERE idPrepod='" + idPrepod + "' AND idKlass='" + idKlassNotCkecked + "'";

            string queryDel = "DELETE FROM prepodsklasses WHERE idPrepod='" + idPrepod + "' AND idKlass='" + idKlassNotCkecked + "'";
            deletequery(query1, queryDel);
            
        }
        public void InsertPrepodsSpec(string idPrepod, string idSpec)
        {
            //date - yyyy-MM-dd
            string query1 = "SELECT idSpec,idPrepod FROM PrepodsSpec WHERE idPrepod='" + idPrepod + "' AND idSpec='" + idSpec + "'";

            string query = "  INSERT INTO PrepodsSpec (idPrepod, idSpec) VALUES";
            query = query + " ('" + idPrepod + "', '" + idSpec + "'); ";

            insertQuery(query1, query);
        }
        private void insertQuery(string query1, string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd1.ExecuteReader();
                bool existRecord = dataReader.Read();
                if (existRecord == false)
                {
                    //close connection
                    this.CloseConnection();
                    this.OpenConnection();
                    //INSERT
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();


                }
                //close connection
                this.CloseConnection();

            }
        }

        public void InsertPrepodsKlass(string idPrepod, string idKlass)
        {
            //date - yyyy-MM-dd
            string query1 = "SELECT idKlass,idPrepod FROM prepodsklasses WHERE idPrepod='" + idPrepod + "' AND idKlass='" + idKlass + "'";

            string query = "  INSERT INTO prepodsklasses (idPrepod, idKlass) VALUES";
            query = query + " ('" + idPrepod + "', '" + idKlass + "'); ";

            insertQuery(query1, query);
        }
        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM Prepods";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add("id="+dataReader["id"] + "");
                    list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        public List<ListKlasses> SelectKlassesToList()
        {
            //Create a list to store the result
            List<ListKlasses> toreturn = new List<ListKlasses>();
            string query = "SELECT * FROM Klasses";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    ListKlasses curgrid = new ListKlasses(dataReader["id"].ToString(), dataReader["name"].ToString(),
                                                      dataReader["People"].ToString(),
                                                       dataReader["yearOfStudy"].ToString());
                    toreturn.Add(curgrid);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }
		public List<GridPrepods> SelectPrepodsToGrid(string id="")
        {
            string query = "SELECT * FROM Prepods";
            if (id != "")
            {
                query = query + " WHERE Prepods.id='" + id + "'";
            }
            //Create a list to store the result
            List<GridPrepods> toreturn = new List<GridPrepods>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                	DateTime bday= (DateTime)dataReader["Birthday"] ;
                	GridPrepods curgrid = new GridPrepods(dataReader["id"].ToString(),dataReader["FioFull"].ToString(),
                	                                  dataReader["FioShort"].ToString(),
                	                                   dataReader["MobPhoneNumber"].ToString(),
                	                                   bday);
                	toreturn.Add(curgrid);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }
        }
        /// <summary>
        /// ������ ������ �� ��������, � �������  
        /// ���� ���� �������� (��� ������ � ������� ����� ����� ��, ��� ����������)
        /// </summary>
        /// <param name="NumDay">����� ��� (�� ������������ � 24.01.2016)</param>
        /// <param name="lessonNum">����� ����������� �����</param>
        /// <param name="idPrepReplaced">id ����������� �������</param>
        /// <returns></returns>
        public List<string> SelectIdsPrepodsClassToGridForReplace(int NumDay, int lessonNum, int idPrepReplaced)
        {
            //SELECT DISTINCT idPrepod FROM schedule WHERE numDayOfWeek=3 and (not lessonNumber=1) and (not idPrepod=3)
            //string query = "SELECT DISTINCT idPrepod FROM schedule WHERE numDayOfWeek='" + NumDay + "' AND (NOT lessonNumber='" + lessonNum + "') AND (NOT idPrepod='" + idPrepReplaced + "')";
            string query = "SELECT DISTINCT idPrepod FROM schedule WHERE (NOT lessonNumber='" + lessonNum + "') AND (NOT idPrepod='" + idPrepReplaced + "')";


            //Create a list to store the result
            //List<GridPrepodsClass> toreturn = new List<GridPrepodsClass>();
            List<string> idsPrepods = new List<string>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string curPrepId = dataReader["idPrepod"].ToString();

                    idsPrepods.Add(curPrepId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return idsPrepods;
            }
            else
            {
                return idsPrepods;
            }
        }
		public BindingSource SelectSpecsToGrid()
		{
			string query="SELECT name,course,semester,id FROM specializations";

            return SelectQuery(query);
		}
        public BindingSource SelectKlassesToGrid()
        {
            string query = "SELECT * FROM Klasses";

            return SelectQuery(query);
        }
        private BindingSource SelectQuery(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                //MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                //MySqlDataReader dataReader = cmd.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                return bSource;
            }
            else
            {
                return null;
            }
        }
        public BindingSource SelectRoomsToGrid()
        {
            string query = "SELECT id,name,capacity FROM Rooms";

            return SelectQuery(query);
        }
		public BindingSource SelectPrepodsToGridNew()
		{
			string query="SELECT * FROM prepods";

            return SelectQuery(query);
		}
		public List<GridSpecs> SelectSpecsToCheckboxes()
        {
            string query = "SELECT * FROM specializations";

            //Create a list to store the result
            List<GridSpecs> toreturn = new List<GridSpecs>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                	//DateTime bday= (DateTime)dataReader["Birthday"] ;
                	GridSpecs curgrid = new GridSpecs(dataReader["id"].ToString(),dataReader["name"].ToString(),
                	                                  dataReader["course"].ToString(),
                	                                   dataReader["semester"].ToString(),
                	                                   dataReader["comment"].ToString());
                	toreturn.Add(curgrid);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }
        }
        public List<GridKlasses> SelectKlassesToCheckboxes()
        {
            string query = "SELECT * FROM klasses";

            //Create a list to store the result
            List<GridKlasses> toreturn = new List<GridKlasses>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    
                    GridKlasses curgrid = new GridKlasses(dataReader["id"].ToString(), dataReader["name"].ToString(),
                                                      dataReader["People"].ToString(),
                                                       dataReader["yearOfStudy"].ToString());
                    toreturn.Add(curgrid);
                    
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }
        }
        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM Prepods";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }



        internal void DeleteRoom(string idRoom)
        {
            //DELETE FROM `prepods4`.`specializations` WHERE <{where_expression}>;
            string query = "DELETE FROM Rooms WHERE Rooms.Id='" + idRoom + "' ; ";


            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        internal void UpdateRoom(string capacity, string name, string fullloc, string id)
        {

            string query = "UPDATE Rooms SET capacity='" + capacity + "', ";
            query = query + "name='" + name + "', FullLocation='" + fullloc + "' ";
            query = query + " WHERE Rooms.Id='" + id + "' ; ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            } 
        }

        internal BindingSource SelectSheduleToGrid()
        {
        	string query = "SELECT schedule.id, idKlass, idSpec, idPrepod, idRoom, isSubGroup, numSubGroup,CONCAT(klasses.name,' (',klasses.yearofstudy,')')  AS klassnameyear , prepods.FioFull AS prepodFIO, rooms.name AS RoomName,";
            query = query+"  numDayOfWeek, nameDayOfWeek, lessonNumber,  isEven, isPair";
            query = query + " FROM schedule LEFT JOIN klasses on schedule.idKlass=klasses.id LEFT JOIN prepods on schedule.idPrepod=prepods.id LEFT JOIN rooms on schedule.idRoom=rooms.id ";

            return SelectQuery(query);
        }

        internal int GetKlassId(string klassname, string klassyear)
        {
            string query1 = "SELECT id FROM klasses WHERE name='" + klassname + "' AND yearOfStudy='" + klassyear + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["id"].ToString();
                    id = int.Parse(id_s);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return id;
            }
            return 0;
        }

        internal List<string> SelectSpecsToList()
        {
            
            List<string> toreturn = new List<string>();
            string query = "Select NotUniqSpec.name, NotUniqSpec.id , Concat( NotUniqSpec.name,' (',NotUniqSpec.course,')',' (',NotUniqSpec.semester,')') as SpecCourseSem from specializations as NotUniqSpec where NotUniqSpec.name IN (";
            query = query + " SELECT spec.name   FROM specializations AS spec    GROUP BY spec.name  HAVING COUNT(*) > 1 )";
            query = query + " UNION Select UniqSpec.name, UniqSpec.id ,  UniqSpec.name as SpecCourseSem from specializations as UniqSpec where UniqSpec.name IN (";
            query = query + " SELECT spec.name  FROM specializations AS spec    GROUP BY spec.name  HAVING COUNT(*) =1 )";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string SpecCourseSem = dataReader["SpecCourseSem"].ToString();
                    toreturn.Add(SpecCourseSem);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal List<string> SelectPrepodsToList()
        {
            //���� ���� ������� � ���������� ������ ���, ��������� ���� ��������.
            List<string> toreturn = new List<string>();
            string query = "Select NotUniqPrep.FioFull, NotUniqPrep.id , Concat( NotUniqPrep.FioFull,' (',NotUniqPrep.Birthday,')') as fioBday from prepods as NotUniqPrep where NotUniqPrep.FioFull IN (";
            query = query+" SELECT p.FioFull   FROM prepods AS p    GROUP BY p.FioFull  HAVING COUNT(*) > 1 )";
            query = query + " UNION Select UniqPrep.FioFull, UniqPrep.id ,  UniqPrep.FioFull as fioBday from prepods as UniqPrep where UniqPrep.FioFull IN (";
            query = query+" SELECT p.FioFull  FROM prepods AS p    GROUP BY p.FioFull  HAVING COUNT(*) =1 )";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string fioBday = dataReader["fioBday"].ToString();
                    toreturn.Add(fioBday);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }
        internal string SelectPrepodsNameById(string id)
        {
            //���� ���� ������� � ���������� ������ ���, ��������� ���� ��������.
            string toreturn = "";
            string query = "Select NotUniqPrep.FioFull, NotUniqPrep.id , Concat( NotUniqPrep.FioFull,' (',NotUniqPrep.Birthday,')') as fioBday from prepods as NotUniqPrep where NotUniqPrep.FioFull IN (";
            query = query + " SELECT p.FioFull   FROM prepods AS p    GROUP BY p.FioFull  HAVING COUNT(*) > 1 )  having NotUniqPrep.id='" + id + "'";
            query = query + " UNION Select UniqPrep.FioFull, UniqPrep.id ,  UniqPrep.FioFull as fioBday from prepods as UniqPrep where UniqPrep.FioFull IN (";
            query = query + " SELECT p.FioFull  FROM prepods AS p    GROUP BY p.FioFull  HAVING COUNT(*) =1 ) having UniqPrep.id='"+id+"'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string fioBday = dataReader["fioBday"].ToString();
                    toreturn = fioBday;
                    //toreturn.Add(fioBday);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }
        internal List<string> SelectRoomsToList()
        {
            //Create a list to store the result
            List<string> toreturn = new List<string>();
            string query = "SELECT CONCAT(rooms.name,' (',rooms.capacity,')')  AS roomNameCapacity  FROM rooms";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string roomNameCapacity = dataReader["roomNameCapacity"].ToString();
                    toreturn.Add(roomNameCapacity);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal int GetRoomId(string roomName, string roomCapacity)
        {
            string query1 = "SELECT id FROM rooms WHERE name='" + roomName + "' AND capacity='" + roomCapacity + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["id"].ToString();
                    id = int.Parse(id_s);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return id;
            }
            return 0;
        }

        internal int GetSpecsId(string nameSpec, string specCourse = "", string specSemestr = "")
        {
            string query1 = "SELECT id FROM specializations WHERE name='" + nameSpec + "'";
            if (specCourse != "")
            {

                query1 = query1 + " AND course='" + specCourse + "'";
            }
            if (specSemestr != "")
            {

                query1 = query1 + " AND semester='" + specSemestr + "'";
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["id"].ToString();
                    id = int.Parse(id_s);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return id;
            }
            return 0;
        }

        internal int GetPrepodId(string PrepFioFull, string PrepDate="")
        {
            string query1 = "SELECT id FROM prepods WHERE FioFull='" + PrepFioFull + "'";
            if (PrepDate!="")
            {
                //yyyy-MM-dd
                query1 = query1 + " AND Birthday='" + PrepDate + "'";
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["id"].ToString();
                    id = int.Parse(id_s);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return id;
            }
            return 0;
        }
		
        internal int InsertSchedule(int lessonNum, int specId, int klassId, bool isSubGrup, object numDayOfWeek, string nameDay, int prepodId, int roomId, int NumSubGrup, bool isEven, bool isPair)
        {
            //date - yyyy-MM-dd
            //string query = "SELECT schedule.id, idKlass, idPrepod, idRoom, isSubGroup, numDayOfWeek, nameDayOfWeek, lessonNumber, numSubGroup, isEven, isPair, ";
            //query = query + " CONCAT(klasses.name,' (',klasses.yearofstudy,')')  AS klassnameyear , prepods.FioFull AS prepodFIO, rooms.name AS RoomName ";
            //query = query + " FROM schedule LEFT JOIN klasses on schedule.idKlass=klasses.id LEFT JOIN prepods on schedule.idPrepod=prepods.id LEFT JOIN rooms on schedule.idRoom=rooms.id ";


            string query = " INSERT INTO schedule (idKlass, idSpec, idPrepod, idRoom, isSubGroup, numDayOfWeek, nameDayOfWeek, lessonNumber, numSubGroup, isEven, isPair ) VALUES";
            query = query + " ('" + klassId + "', '" + specId + "', '" + prepodId + "', '" + roomId + "', '" + Convert.ToInt32(isSubGrup) + "', '" + numDayOfWeek + "' , '" + nameDay + "', '" + lessonNum + "' ,  ";
            query = query + "  '" + NumSubGrup + "' , '" + Convert.ToInt32(isEven) + "', '" + Convert.ToInt32(isPair) + "' ); select last_insert_id();";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                //cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                //close connection
                this.CloseConnection();
                return id;
            }
            return 0;
        }

        internal void Updatechedule(string id, int lessonNum, int specId, int klassId, bool isSubGrup, object numDayOfWeek, string nameDay, int prepodId, int roomId, int NumSubGrup, bool isEven, bool isPair)
        {
            //date - yyyy-MM-dd
            //string query = "SELECT schedule.id, idKlass, idPrepod, idRoom, isSubGroup, numDayOfWeek, nameDayOfWeek, lessonNumber, numSubGroup, isEven, isPair, ";
            //query = query + " CONCAT(klasses.name,' (',klasses.yearofstudy,')')  AS klassnameyear , prepods.FioFull AS prepodFIO, rooms.name AS RoomName ";
            //query = query + " FROM schedule LEFT JOIN klasses on schedule.idKlass=klasses.id LEFT JOIN prepods on schedule.idPrepod=prepods.id LEFT JOIN rooms on schedule.idRoom=rooms.id ";

            string query = "UPDATE schedule SET idKlass='" + klassId + "', ";
            query = query + "idPrepod='" + prepodId + "', idRoom='" + roomId + "', ";
            query = query + "idSpec='" + specId + "', ";
            query = query + "isSubGroup='" + Convert.ToInt32(isSubGrup) + "', numDayOfWeek='" + numDayOfWeek + "', ";
            query = query + "nameDayOfWeek='" + nameDay + "', lessonNumber='" + lessonNum + "', ";
            query = query + "numSubGroup='" + NumSubGrup + "', isEven='" + Convert.ToInt32(isEven) + "',  isPair='" + Convert.ToInt32(isPair) + "' ";
            query = query + " WHERE schedule.Id='" + id + "' ; ";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        internal string GetSpecName(int specId)
        {
            string query1 = "SELECT name FROM specializations WHERE specializations.id='" + specId + "' ";
            
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["name"].ToString();
                    //id = int.Parse(id_s);
                    return id_s;
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return "";
            }
            return "";
        }
        internal int GetSpecId(string specNameFull, string specCourse="", string specSem="")
        {
            string query1 = "SELECT id FROM specializations WHERE specializations.name='" + specNameFull+"' ";
            if (specCourse != "" && specSem!="")
            {
                //yyyy-MM-dd
                query1 = query1 + " AND course='" + specCourse + "' AND semester='" + specSem+"' ";
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int id = 0;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //DateTime bday= (DateTime)dataReader["Birthday"] ;
                    string id_s = dataReader["id"].ToString();
                    id = int.Parse(id_s);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return id
                return id;
            }
            return 0;
        }

        internal void DeleteShedule(string id)
        {
            //DELETE FROM `prepods4`.`specializations` WHERE <{where_expression}>;
            string query = "DELETE FROM shedule WHERE shedule.Id='" + id + "' ; ";


            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        internal string SelectRoomNameById(string curRoomId)
        {
            //Create a list to store the result
            string toreturn = "";
            string query = "SELECT CONCAT(rooms.name,' (',rooms.capacity,')')  AS roomNameCapacity  FROM rooms WHERE rooms.id='"+curRoomId+"'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string roomNameCapacity = dataReader["roomNameCapacity"].ToString();
                    toreturn = roomNameCapacity;
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal string SelectSpecNameById(string curSpecId)
        {
            string toreturn = "";
            string query = "Select NotUniqSpec.name, NotUniqSpec.id , Concat( NotUniqSpec.name,' (',NotUniqSpec.course,')',' (',NotUniqSpec.semester,')') as SpecCourseSem from specializations as NotUniqSpec where NotUniqSpec.name IN (";
            query = query + " SELECT spec.name   FROM specializations AS spec    GROUP BY spec.name  HAVING COUNT(*) > 1 ) HAVING NotUniqSpec.id='"+curSpecId+"'";
            query = query + " UNION Select UniqSpec.name, UniqSpec.id ,  UniqSpec.name as SpecCourseSem from specializations as UniqSpec where UniqSpec.name IN (";
            query = query + " SELECT spec.name  FROM specializations AS spec    GROUP BY spec.name  HAVING COUNT(*) =1 ) HAVING UniqSpec.id='" + curSpecId + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string SpecCourseSem = dataReader["SpecCourseSem"].ToString();
                    toreturn = SpecCourseSem;
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal BindingSource SelectPrepodLessonsToGrid(int dayNum, int prepodId, bool UseEvenWeek=false, bool EvenWeek=false)
        {
            string query = "SELECT schedule.id, idKlass, idSpec, idRoom, isSubGroup, lessonNumber, numSubGroup, ";
            query = query + " CONCAT(klasses.name,' (',klasses.yearofstudy,' - ',numSubGroup,' )')  AS klassnameyear , rooms.name AS RoomName, isEven ";
            query = query + " FROM schedule LEFT JOIN klasses on schedule.idKlass=klasses.id LEFT JOIN rooms on schedule.idRoom=rooms.id WHERE schedule.numDayOfWeek='" + dayNum + "' AND schedule.idPrepod='" + prepodId + "'";
            if (UseEvenWeek)
            {
                query = query + " AND schedule.isEven='" + Convert.ToInt32(EvenWeek) + "' ";
            }
            query = query + " ORDER BY schedule.lessonNumber";
            return SelectQuery(query);
        }
        /// <summary>
        /// ����������: 5 ���� ��������� id, 4 ���� ��������� ���, 3 ���� ���� ������ � ������� course &lt;=2 , 2 ���� ������� semester &lt;=2 �� ������, ����� 1
        /// </summary>
        /// <param name="prepId"></param>
        /// <param name="specId"></param>
        /// <param name="specNameNoSemester"></param>
        /// <returns></returns>
        internal int CoefPrepodSpec(string prepId, int specId, string specNameNoSemester)
        {
            int coefResult = 1;
            //���� � ���������� �����
            string query_infoSpec = "SELECT specializations.id, specializations.name,specializations.course,specializations.semester FROM specializations WHERE specializations.id='"+specId+"'";
            //info � ���� �������������� �������
            string query = "SELECT prepodsspec.id, specializations.id AS sid, specializations.name,specializations.course,specializations.semester  FROM prepodsspec LEFT JOIN specializations ON prepodsspec.idSpec=specializations.id WHERE prepodsspec.idPrepod='" + prepId + "'";


            //2)���� �� ����� � ������� ������ (������)
            //myCon.Initialize();
           // List<string> allSpecsWithSameName = myCon.GetSpecsWithSameName(prepId, specNameNoSemester);
            //int countSpecsWithSameName = allSpecsWithSameName.Count;
            //Open connection
            if (this.OpenConnection() == true)
            {
                GridSpecs specinfoReplace=new GridSpecs();
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query_infoSpec, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader1.Read())
                {
                    specinfoReplace = new GridSpecs(dataReader1["id"].ToString(),
                        dataReader1["name"].ToString(),
                        dataReader1["course"].ToString(),
                        dataReader1["semester"].ToString(),
                        "");
                }
                dataReader1.Close();

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<GridSpecs> specsForCurPrepod = new List<GridSpecs>();
                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string id = dataReader["id"].ToString();
                    coefResult = 0;
                    GridSpecs specinfoCur = new GridSpecs(dataReader["id"].ToString(),
                        dataReader["name"].ToString(),
                        dataReader["course"].ToString(),
                        dataReader["semester"].ToString(),
                        "");
                    specsForCurPrepod.Add(specinfoCur);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }
                ///�������
                ///
                //1)��������� �� id
                foreach (var spec in specsForCurPrepod)
                {
                    if (spec.ID == specinfoReplace.ID)
                    {
                        coefResult = 5;
 
                    }
                }
                if (coefResult != 5)
                {
                    //2)���������� ����� �����
                    foreach (var spec in specsForCurPrepod)
                    {
                        if (spec.name.ToLowerInvariant().Trim() == specinfoReplace.name.ToLowerInvariant().Trim())
                        {
                            coefResult = 4;

                        }
                    }
                    if (coefResult != 4)
                    {
                        //���� ���� ������ � ������� course <=2 
                        int replCourse = Convert.ToInt32(specinfoReplace.course);
                        foreach (var spec in specsForCurPrepod)
                        {
                            int course = Convert.ToInt32(spec.course);

                            if (course >= replCourse && (course - replCourse) <= 2)
                            {
                                coefResult = 3;

                            }
                        }
                        if (coefResult != 3)
                        {
                            // ���� ������� semester <=2 �� ������
                            int replSem = Convert.ToInt32(specinfoReplace.semester);
                            foreach (var spec in specsForCurPrepod)
                            {
                                int semester = Convert.ToInt32(spec.semester);

                                if (Math.Abs(semester - replSem) <= 2)
                                {
                                    coefResult = 2;

                                }
                            }
                        }
                    }
                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return 
                return coefResult;
            }
            else
            {
                return coefResult;
            }

            return coefResult;
        }

        internal List<string> GetSpecsWithSameName(string prepId, string specNameNoSemester)
        {
            //Create a list to store the result
            List<string> toreturn = new List<string>();
            string query = "SELECT prepodsspec.id as pid, specializations.id as specId From prepodsspec LEFT JOIN specializations ON prepodsspec.idSpec=specializations.id WHERE prepodsspec.idPrepod='" + prepId + "' AND specializations.name Like '%" + specNameNoSemester + "%'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string specId = dataReader["specId"].ToString();
                    toreturn.Add(specId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal List<string> GetReplacementsForKlass(string prepId, int idKlass)
        {
            //Create a list to store the result
            List<string> toreturn = new List<string>();
            string query = "SELECT otchet.id as id FROM otchet WHERE idPrepod='" + prepId + "' AND idKlass='" + idKlass + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string specId = dataReader["id"].ToString();
                    toreturn.Add(specId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }

        internal List<string> GetShedulePrepForKlass(string prepId, int idKlass)
        {
            //Create a list to store the result
            List<string> toreturn = new List<string>();
            string query = "SELECT DISTINCT schedule.id as id FROM schedule WHERE idPrepod='" + prepId + "' AND idKlass='" + idKlass + "'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    string specId = dataReader["id"].ToString();
                    toreturn.Add(specId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return toreturn;
            }
            else
            {
                return toreturn;
            }

            return toreturn;
        }
        /// <summary>
        /// ����������: ���� � ������� ��� ������ � ���� ���� ������ ����
        /// ����� ������ �� ������  
        /// </summary>
        /// <param name="prepId"></param>
        /// <param name="_daynum"></param>
        /// <param name="curLesson"></param>
        /// <param name="useEvenWeeks"></param>
        /// <param name="EvenWeek"></param>
        /// <returns></returns>
        internal string CoefHome(string prepId, int _daynum, int curLesson, bool useEvenWeeks, bool EvenWeek)
        {
            string coefResult = "";
            string query = "SELECT DISTINCT schedule.id as id FROM schedule WHERE idPrepod='" + prepId + "' AND numDayOfWeek='" + _daynum + "' ";
            if (useEvenWeeks)
            {
                query = query + " AND isEven='" + Convert.ToInt32(EvenWeek) + "'";
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                if (dataReader.Read())
                {

                    coefResult = "[На работе]";
                    //toreturn.Add(specId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }
                else
                {
                    coefResult = "[Дома]";
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return coefResult;
            }
            else
            {
                return coefResult;
            }

            
            
            
            return coefResult;

        }
        /// <summary>
        /// ������ � 
        /// </summary>
        /// <param name="prepId"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        internal List<string> GetReplacementsInMonth(string prepId, int idKlass=0)
        {
            var yr = DateTime.Today.Year;
            var mth = DateTime.Today.Month;
            var firstDayOfMonth = new DateTime(yr, mth, 1);
            string fdm = firstDayOfMonth.ToString("yyyy-MM-dd");
            
            string query = "SELECT DISTINCT Otchet.id as id FROM Otchet WHERE idPrepod='" + prepId + "' AND DateReplace >='" + fdm + "' ";
            if (idKlass != 0)
            {
                query = query + " AND idKlass='" + idKlass.ToString() + "' ";
            }
            List<string> result = new List<string>();
            
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    result.Add( dataReader["id"].ToString() );
                    //toreturn.Add(specId);
                    //list[0].Add("id="+dataReader["id"] + "");
                    //list[1].Add("FioFull="+dataReader["FioFull"] + "");
                    //list[2].Add("MobPhoneNumber="+dataReader["MobPhoneNumber"] + "");
                }
                

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return result;
            }
            else
            {
                return result;
            }
            //DateTime monthBegin = DateTime.Now;
            //throw new NotImplementedException();
        }

        internal void InsertOtchet(int prepodId, string idKlass, string isSubGroup, string numSubGroup, int _PrepodId, string now, int _daynum, int specId, int roomId)
        {
            //`id` bigint NOT NULL AUTO_INCREMENT,
            //`idPrepod` bigint NOT NULL,
            //`count` bigint NOT NULL,
            //`idKlass` bigint NOT NULL,
            //`isSubGroup` bit NOT NULL,
            //`numSubGroup` bigint,
            //`idReplacedPrepod` bigint NOT NULL,
            //`DateReplace` DATETIME,
            //`numDayOfWeek` bigint,
            string query = "";
            query = query + "INSERT INTO Otchet (idPrepod, count, idKlass, isSubGroup, numSubGroup, idReplacedPrepod, DateReplace, numDayOfWeek, idSpec , idRoom) VALUES";


            query = query + " ('" + prepodId + "', '1', '" + idKlass + "', '" + isSubGroup + "',  '" + numSubGroup + "', '" + _PrepodId + "' , '" + now + "' , '" + _daynum + "' " + " , '" + specId + "' , '" + roomId + "' );";

            query = query + "	";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        internal BindingSource SelectOtchetToGrid(string dateBegin, string dateEnd, string idSpec, string idPrepod, string idKlasses, string idPrepod1)
        {
            string query = "SELECT idPrepod,idKlass,idReplacedPrepod,DateReplace,numDayOfWeek, CONCAT(klasses.name,' (',klasses.yearofstudy,')')  AS klassnameyear,  ";
            //string query = "SELECT schedule.id, idKlass, idPrepod, idRoom, isSubGroup, numDayOfWeek, nameDayOfWeek, lessonNumber, numSubGroup, isEven, isPair, ";
            query = query + " prepods.FioFull AS prepodFIO, p2.FioFull AS replacedFIO, CONCAT(specializations.name,' (',specializations.course,' ',specializations.semester,')') as SpecName, rooms.name as RoomName ";
            query = query + " FROM Otchet LEFT JOIN klasses on Otchet.idKlass=klasses.id LEFT JOIN prepods on Otchet.idPrepod=prepods.id  LEFT JOIN prepods AS p2 on Otchet.idReplacedPrepod=p2.id  ";
            query = query + " LEFT JOIN specializations on specializations.id = Otchet.idSpec LEFT JOIN rooms on rooms.id = Otchet.idRoom  ";
            bool wasWhere = false;
            if (dateBegin != "" && dateEnd != "")
            {
                query = query + " WHERE DateReplace>='" + dateBegin + "' AND DateReplace<='" + dateEnd + "' ";
                wasWhere = true;
            }
            if (idSpec != "")
            {
                if (wasWhere)
                {
                    query = query + "  AND Otchet.idSpec='" + idSpec + "' ";
                }
                else
                {
                    query = query + " WHERE Otchet.idSpec='" + idSpec + "'  ";
                    wasWhere = true;
                }
            }

            if (idPrepod != "")
            {
                if (wasWhere)
                {
                    query = query + "  AND Otchet.idPrepod='" + idPrepod + "' ";
                }
                else
                {
                    query = query + " WHERE Otchet.idPrepod='" + idPrepod + "'  ";
                    wasWhere = true;
                }
            }

            if (idKlasses != "")
            {
                if (wasWhere)
                {
                    query = query + "  AND Otchet.idKlass='" + idKlasses + "' ";
                }
                else
                {
                    query = query + " WHERE Otchet.idKlass='" + idKlasses + "'  ";
                    wasWhere = true;
                }
            }

            if (idPrepod1 != "")
            {
                if (wasWhere)
                {
                    query = query + "  AND Otchet.idReplacedPrepod='" + idPrepod1 + "' ";
                }
                else
                {
                    query = query + " WHERE Otchet.idReplacedPrepod='" + idPrepod1 + "'  ";
                    wasWhere = true;
                }
            }

            query = query + " ORDER BY Otchet.DateReplace";
            return SelectQuery(query);
        }
    }
}
