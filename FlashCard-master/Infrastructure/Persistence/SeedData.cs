using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class SeedData
    {
        public static void Initialize(FlashCardContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any()) return;

            context.User.AddRange(new List<User>{
                new User {
                    ID = "root",
                    passwd = "admin",
                    email = "FlashcardSP@gmail.com",
                    createdDay = System.DateTime.Today.ToString("dd-MM-yyyy"),
                    role = "Thành viên",
                    avatar = "/resources/images/user/avt_hidden.jpg",
                    contry = "Việt Nam",
                    status = 1,
                },
            });

            context.SaveChanges();
        }
    }
}