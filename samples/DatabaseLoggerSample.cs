//--------------------------------------------------//
// Sample Code for BasixcLogger by basicx-StrgV     //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using BasicxLogger;
using BasicxLogger.Databases;

namespace Sample
{
    class DatabaseLoggerSample
    {
        public void DatabaseLoggingSample()
        {
            //To use the db logger you need to create an object of a supported database.
            //The db must exist but the table will be automatically create. Dont create it your self. 
            //Database classes are containd in the namespace: "BasicxLogger.Databases"
            MySqlDatabase mySqlDatabase = new MySqlDatabase("localhost", "sampleDB", "sampleTable", "user", "pw");

            //Then you can create a db logger. 
            DatabaseLogger dblogger = new DatabaseLogger(mySqlDatabase);

            //Logging works the same as with every other logger
            dblogger.Log("Sample message");

            //The table that is used for logging contains the following collumns:
            // - entyId : This collumn is the primary key of the table and uses auto increment
            // - messageId : The messageId is NOT the primary key because it can be deactivated
            // - messageTimestamp
            // - tag
            // - message
        }
    }
}
