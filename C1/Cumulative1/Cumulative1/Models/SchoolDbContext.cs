using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cumulative1.Model
{
    public class SchoolDbContext : DbContext
    {
        // Constructor for DbContext
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        // DbSet to represent the Teachers table in the database
        public DbSet<Teacher> Teachers { get; set; }

        // Database connection settings
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } } // No password for XAMPP
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } } // Default XAMPP port

        // Build the connection string
        protected static string ConnectionString
        {
            get
            {
                return $"server={Server};user={User};database={Database};port={Port};password={Password};convert zero datetime=True";
            }
        }

        /// <summary>
        /// Returns a connection to the school database.
        /// </summary>
        /// <returns>A MySqlConnection object to interact with the database.</returns>
        public MySqlConnection AccessDatabase()
        {
            // Instantiate and return a new MySqlConnection object
            return new MySqlConnection(ConnectionString);
        }
    }
}
