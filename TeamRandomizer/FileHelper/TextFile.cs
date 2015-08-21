using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FileHelper
{
    public static class TextFile
    {
        public static bool WriteFile<T>(IList<T> objectsToWrite,IList<PropertyInfo>fieldsToWrite,string path,int teamSize=5)
        {
            if (teamSize <= 0)
            {
                teamSize = 5;
            }
            var linesToWrite = new List<string>();
            var i = 0;
            var teamCount = 1;
            var reserveBench = false;

            var maxTeamCount =  ((double)objectsToWrite.Count/teamSize);
            if (maxTeamCount > Math.Floor(maxTeamCount))
            {
                //maxTeamCount -= 1;
            }
            

            foreach (var objectToWrite in objectsToWrite)
            {


                if (i % teamSize == 0 && !reserveBench)
                {
                    if (teamCount > maxTeamCount)
                    {
                        linesToWrite.Add(Environment.NewLine+"Reserve bench");

                        reserveBench = true;
                    }
                    else
                    {
                        linesToWrite.Add(Environment.NewLine+"Team " + teamCount);
                        teamCount++;
                    }                    
                }


                var line= fieldsToWrite.Aggregate("", (current, field) => current + (field.GetValue(objectToWrite) + " "));

                linesToWrite.Add(line);

                i++;


            }
            try
            {
                using (var stream = new StreamWriter(path))
                {
                    foreach (var line in linesToWrite)
                    {
                        stream.WriteLine(line);
                    }
                }
            }
            catch (AccessViolationException e)
            {
                return false;
            }
            return true;


        }
    }
}
