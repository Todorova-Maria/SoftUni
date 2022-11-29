using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _02.VillainNames
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] minionInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] villainInfo = Console.ReadLine().Split(": ").ToArray();

            string villainName = villainInfo[1];

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            string result = GetMinionId(sqlConnection, minionInfo, villainName);
            Console.WriteLine(result);

       
            sqlConnection.Close();
        }

        private static string GetVillainNameWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string query = @"SELECT[v].[Name], COUNT ([mv].[MinionId]) 
                                AS[MinionsCount]
                                FROM[Villains] AS[v]
                                LEFT JOIN[MinionsVillains] AS[mv]
                                ON[v].Id = [mv].[VillainId]
                                GROUP BY[v].[Name]
                                            HAVING COUNT([mv].[MinionId]) > 3
                                ORDER BY[MinionsCount] DESC";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return sb.ToString().TrimEnd();


        }

        private static string GetVillainNamesWithMinions(SqlConnection sqlConnection, int id)
        {
            var sb = new StringBuilder();
            var villainNameQuery = @"SELECT [Name]
                                            FROM [Villains]
                                            WHERE [Id] = @villainId";

            SqlCommand getVillainNameCommand = new SqlCommand(villainNameQuery, sqlConnection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", id);

            var villainName = (string)getVillainNameCommand.ExecuteScalar();

            if (villainName == null)
            {
                return $"No villain with ID {id} exists in the database.";
            }

            var mininonQuery = @"SELECT [m].[Name], [m].[Age]
                                    FROM [MinionsVillains] AS [mv]
                                    LEFT JOIN [Minions] AS [m]
                                    ON [mv].[MinionId] = [m].[Id]
                                    WHERE [mv].[VillainId] = @villainId
                                  ORDER BY [m].[Name]";

            SqlCommand getMinionsOfaVillain = new SqlCommand(mininonQuery, sqlConnection);
            getMinionsOfaVillain.Parameters.AddWithValue("@villainId", id);

            using var minions = getMinionsOfaVillain.ExecuteReader();
            var count = 0;

            sb.AppendLine(villainName);

            while (minions.Read())
            {
                count++;
                sb.AppendLine($"{count}. {minions["Name"]} {minions["Age"]}");
            }
            if (count == 0)
            {
                sb.AppendLine("(no minions)");
            }
            return sb.ToString().TrimEnd();
        }

        private static string GetMinionId(SqlConnection sqlConnection, string[] minionInfo, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

       


            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
               int townId = GetTownId(sqlConnection, minionTown, sqlTransaction, sb);
               int villainId = GetVillainId(sqlConnection, villainName, sqlTransaction, sb);
               int minionId = GetMinionId(sqlConnection, minionName
                    , minionAge, townId, sqlTransaction, sb);

                string insertServant = @"INSERT INTO [MinionsVilliains] 
		                                                            VALUES  
		                                                                  ('@minionId', '@villainId')";

                SqlCommand insertServantCmd = new SqlCommand(insertServant, sqlConnection, sqlTransaction);
                insertServantCmd.Parameters.AddWithValue("@minionId", minionId);
                insertServantCmd.Parameters.AddWithValue("@villainId", villainId);
                insertServantCmd.ExecuteNonQuery();

                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
            }

            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }
            return sb.ToString().TrimEnd();
        }

       
        
        
        // Methods for Task 03 (GetMinionId)
        private static int GetMinionId(SqlConnection sqlConnection, string minionName 
            , int minionAge, int TownId, SqlTransaction sqlTransaction, StringBuilder sb)
        {
            string addMinionQuery = @"INSERT INTO [Minions] ([Name, [Age], [TownId])
                                                                       VALUES
                                                               ('@minionName', '@minionAge', '@townId')";


            SqlCommand addMinionCommand = new SqlCommand(addMinionQuery, sqlConnection, sqlTransaction);
            addMinionCommand.Parameters.AddWithValue("@minionName", minionName);
            addMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
            addMinionCommand.Parameters.AddWithValue("@townId", TownId);

            object minionObj = addMinionCommand.ExecuteScalar();

            string IdMinion = @"SELECT [Id] 
	                              FROM [Minions] 
		                             WHERE [Name] = '@minionName' AND [TownId] = '@TownId' AND [Age] = '@minionAge'";

            SqlCommand getMinionId = new SqlCommand(IdMinion, sqlConnection, sqlTransaction);
            getMinionId.Parameters.AddWithValue("@minionName", minionName);
            getMinionId.Parameters.AddWithValue("@minionAge", minionAge);
            getMinionId.Parameters.AddWithValue("@townId", TownId);

            int minionId = (int)getMinionId.ExecuteScalar();

            return minionId;
        }

        private static int GetVillainId(SqlConnection sqlConnection, string villainName, SqlTransaction sqlTransaction, StringBuilder sb)
        {
            string villain = @"SELECT [Id] 
			                    FROM [Villains] 
				                    WHERE[Name] = '@villainName'"; 
             
            SqlCommand villainCommand = new SqlCommand(villain,sqlConnection, sqlTransaction);
            villainCommand.Parameters.AddWithValue("@villainName", villainName);

            object villainObj = villainCommand.ExecuteScalar(); 
             
            if(villainObj == null)
            {
                string evilnessFactorQuery = @"SELECT [Id] 
			                                        FROM[EvilnessFactors] 
				                                                    WHERE [Name] = 'Evil'";
                SqlCommand evilessFactorCmd = new SqlCommand(evilnessFactorQuery, sqlConnection, sqlTransaction);
                int evilnessFactorId = (int)evilessFactorCmd.ExecuteScalar(); 



                string insertVillain = @"INSERT INTO [Villains] ([Name], [EvilnessFactorId]) 
					                                                            VALUES  
					                                                         ('@newVillain', '@evilnessFactorId')";

                SqlCommand addVillain = new SqlCommand(insertVillain, sqlConnection, sqlTransaction);
                addVillain.Parameters.AddWithValue("@newVillain", villainName);
                addVillain.Parameters.AddWithValue("@evilnessFactorId", evilnessFactorId); 

                addVillain.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");

                villainObj = villainCommand.ExecuteScalar();
            }
            return (int)villainObj;
        }

        private static int GetTownId(SqlConnection sqlConnection, string minionTown, SqlTransaction sqlTransaction, StringBuilder sb) {
            
            string townQuery = @"SELECT [Id]
		                            FROM [Towns]
		                          WHERE [Name] = @townName";

            SqlCommand townIdCommand = new SqlCommand(townQuery, sqlConnection, sqlTransaction);
            townIdCommand.Parameters.AddWithValue("@townName", minionTown);

            object townIdObj = townIdCommand.ExecuteScalar();

            if (townIdObj == null)
            {
                string addTownQuery = @"INSERT INTO [Towns]([Name])
		                                        VALUES 
		                                        ('@townName')";

                SqlCommand addTownCommand = new SqlCommand(addTownQuery, sqlConnection, sqlTransaction);
                addTownCommand.Parameters.AddWithValue("@townName", minionTown);

                addTownCommand.ExecuteNonQuery();
                sb.AppendLine($"Town {minionTown} was added to the database.");

                townIdObj = townIdCommand.ExecuteScalar();
            }
            return (int)townIdObj;
        }
    }
} 

