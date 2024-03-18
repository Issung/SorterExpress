using SorterExpress.Data.DbContext;
using SorterExpress.Data.Model;
using System;
using System.Linq;

namespace SorterExpress.Models
{
    public static class Db
    {
        public static AutoClassificationWeights GetAutoClassificationWeights(
            string path,
            Func<string, AutoClassificationWeights> factory
        )
        {
            using (var db = Designer.CreateDbContext())
            {
                var fileData = db.FileData.FirstOrDefault(fd => fd.Path == path);

                if (fileData == null)
                { 
                    fileData = new(path);
                    db.FileData.Add(fileData);
                }

                if (fileData.AutoClassificationWeights == null)
                {
                    fileData.AutoClassificationWeights = factory(path);
                    db.SaveChanges();
                }

                return fileData.AutoClassificationWeights;
            }
        }
    }
}
