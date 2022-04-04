using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToe
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        readonly string connectionString = "Server=localhost;Database=TicTacToeDb;Trusted_Connection=True;";

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult InnerLogic(string allData, Int64 myid)
        {
            //int myid = allData[0] - '0'; //char to int
            int[] box = new int[9];
            for (int i = 0; i < 9; ++i) {
                switch (allData[i + 1])
                {
                    case 'X':
                        box[i] = 1;
                        break;
                    case '0':
                        box[i] = 2;
                        break;
                    case 'n':
                        box[i] = 0;
                        break;
                    default:
                        box[i] = -3;
                        break;
                }
            }
            int myflag = allData[10] - '0';
            int win = -1;
            string result_str = "";

            using (DbConnection db = new SqlConnection(connectionString))
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (box[i] * box[i + 3] * box[i + 6] == 1)
                    {
                        win = 1;
                        result_str = "X won";
                    }
                    if (box[i] * box[i + 3] * box[i + 6] == 8)
                    {
                        win = 2;
                        result_str = "0 won";
                    }
                }
                for (int j = 0; j < 3; ++j)
                {
                    if (box[3 * j] * box[3 * j + 1] * box[3 * j + 2] == 1)
                    {
                        win = 1;
                        result_str = "X won";
                    }
                    if (box[3 * j] * box[3 * j + 1] * box[3 * j + 2] == 8)
                    {
                        win = 2;
                        result_str = "0 won";
                    }
                }
                if (box[0] * box[4] * box[8] == 1 || box[2] * box[4] * box[6] == 1)
                {
                    win = 1;
                    result_str = "X won";
                }
                if (box[0] * box[4] * box[8] == 8 || box[2] * box[4] * box[6] == 8)
                {
                    win = 2;
                    result_str = "0 won";
                }
                //Match Tie?
                int temp_result = 1;
                for (int i = 0; i < 9; ++i) {
                    temp_result *= box[i];
                }
                if (temp_result != 0 && result_str == "") {
                    win = 0;
                    result_str = "Match tie";
                }

                //Match not finished.
                if (win >= 0)
                {
                    Console.WriteLine(myid);
                    //Console.Read();
                    dynamic cmdQuery = db.Query<dynamic>(string.Format("INSERT INTO dbo.TicTacToeMoves values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10});",
                        myid, box[0], box[1], box[2], box[3], box[4], box[5], box[6], box[7], box[8], win));
                }
                else
                {
                    dynamic cmdQuery = db.Query<dynamic>(string.Format("INSERT INTO [dbo].[TicTacToeMoves] values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, NULL);",
                        myid, box[0], box[1], box[2], box[3], box[4], box[5], box[6], box[7], box[8]));
                }

                if (result_str == "")
                {
                    result_str = "Continue";
                }

                return Ok(result_str);
            }
        }

        public IActionResult OuterLogic(string allData, Int64 myid)
        {
            int[] box = new int[9];
            for (int i = 0; i < 9; ++i)
            {
                switch (allData[i + 1])
                {
                    case 'X':
                        box[i] = 1;
                        break;
                    case '0':
                        box[i] = 2;
                        break;
                    case 'n':
                        box[i] = 0;
                        break;
                    default:
                        box[i] = -3;
                        break;
                }
            }
            //int myflag = allData[10] - '0';
            //int win = -1;
            string returnData = "";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                //SqlCommand cmd = db.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                //db.ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                cmd.Connection = db;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addMove";

                cmd.Parameters.AddWithValue("@Game_id", myid);
                cmd.Parameters.AddWithValue("@box1", box[0]);
                cmd.Parameters.AddWithValue("@box2", box[1]);
                cmd.Parameters.AddWithValue("@box3", box[2]);
                cmd.Parameters.AddWithValue("@box4", box[3]);
                cmd.Parameters.AddWithValue("@box5", box[4]);
                cmd.Parameters.AddWithValue("@box6", box[5]);
                cmd.Parameters.AddWithValue("@box7", box[6]);
                cmd.Parameters.AddWithValue("@box8", box[7]);
                cmd.Parameters.AddWithValue("@box9", box[8]);

                cmd.Parameters.Add("@resultData", SqlDbType.NVarChar, 30);
                cmd.Parameters["@resultData"].Direction = ParameterDirection.Output;

                cmd.Connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    //returnData = Convert.ToString(cmd.Parameters["@resultData"].Value);
                    returnData = (string) (cmd.Parameters["@resultData"].Value);
                }
                catch (Exception ex) {
                    throw (ex);
                }
                finally
                { 
                    cmd.Connection.Close();
                }
            }
            return Ok(returnData);
        }

        public IActionResult RunReport()
        {
            //TODO: run the report here or work with reportViewer
            return Ok();
        }

    }
}
