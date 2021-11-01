using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PhotoApp.Models;
using System.Threading.Tasks;

namespace PhotoApp.Controllers
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;

        public Database(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Photo>().Wait();
        }

        // Get All Videos
        public Task<List<Photo>> getListVideos()
        {
            return db.Table<Photo>().ToListAsync();
        }

        // Get Video by Code
        public Task<Photo> getVideoByCode(int codeParam)
        {
            return db.Table<Photo>()
                .Where(i => i.code == codeParam)
                .FirstOrDefaultAsync();
        }

        // Create person
        public Task<int> saveVideo(Photo photo)
        {
            if (photo.code != 0)
            {
                return db.UpdateAsync(photo);
            }
            else
            {
                return db.InsertAsync(photo);
            }

        }

        public Task<int> deleteVideo(Photo photo)
        {
            return db.DeleteAsync(photo);
        }
    }
}
