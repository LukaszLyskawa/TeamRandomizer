using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileHelper
{
    public class TextFile
    {
        public void WriteFile<T>(IList<T> objectsToWrite,IList<FieldInfo>fieldsToWrite,string path,int teamSize=5)
        {
            var linesToWrite = new List<string>();
            var type = typeof (T);

            var i = 0;
            var teamCount = 1;
            var reserveBench = false;
            var maxTeamCount = Math.Floor((double) (objectsToWrite.Count/teamSize));
            foreach (var objectToWrite in objectsToWrite)
            {
                foreach (var field in fieldsToWrite)
                {
                    if (i%teamSize == 0 && !reserveBench)
                    {
                        if (teamCount > maxTeamCount)
                        {
                            linesToWrite.Add("Reserve bench");
                            reserveBench = true;
                        }
                        linesToWrite.Add("Team "+ teamCount);
                        teamCount++;
                    }
                    linesToWrite.Add(field.GetValue(objectToWrite).ToString());
                    i++;
                }
            }
        }
    }
}
