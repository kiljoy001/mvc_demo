using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace mvc_demo.Models
{//DropCreateDatabaseAlways recreates db for the first time. Context is the name of the db
    public class photoInit: DropCreateDatabaseAlways<photoShareContext>
    {
            //This method puts sample data into the database
            protected override void Seed(photoShareContext context)
            {
                base.Seed(context);

                //Create some photos
                var photos = new List<Photo>
            {
                new Photo {
                    Title = "A Lovely Flower",
                    Description = "I am a flower lover!",
                    UserName = "Karen",
                    PhotoFile = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo {
                    Title = "Whale Watching",
                    Description = "Look what we saw today!",
                    UserName = "Bill",
                    PhotoFile = getFileBytes("\\Images\\HumbackWhale.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                },
                new Photo {
                    Title = "While Snorkeling in Hawaii",
                    Description = "This guy was swimming with us!",
                    UserName = "Sue",
                    PhotoFile = getFileBytes("\\Images\\SeaTurtle.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today
                }
            }; //add to database
                photos.ForEach(s => context.Photos.Add(s));
                context.SaveChanges();

                //Create some comments
                var comments = new List<Comment>
            {
                new Comment {
                    PhotoID = 1,
                    UserName = "Bert",
                    Subject = "Nice Flower",
                    Body = "Did you grow this in your backyard?"
                },
                new Comment {
                    PhotoID = 2,
                    UserName = "Sue",
                    Subject = "So?",
                    Body = "I see these everyday..."
                },
                new Comment {
                    PhotoID = 2,
                    UserName = "Fred",
                    Subject = "Jealous",
                    Body = "Wow, that looks great!"
                }
            };
                comments.ForEach(s => context.Comments.Add(s));
                context.SaveChanges();
            }

            //This gets a byte array for a file at the path specified
            //The path is relative to the route of the web site
            //It is used to seed images
            private byte[] getFileBytes(string path)
            {
                FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return fileBytes;
            }

        }
    }
